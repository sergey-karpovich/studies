using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packt.Shared;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace NorthwindService.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
         // использование статического потокобезопасного словарного   
           // поля для кэширования клиентов 
        private static ConcurrentDictionary<string ,Customer> customersCache;
        // использование поля экземпляра класса для контекста,     
        // поскольку он не должен кэшироваться из-за своего    
        // внутреннего кэширования 
        private Northwind db;
        public CustomerRepository(Northwind db)
        {
            this.db=db;
              // предварительная загрузка клиентов из базы данных в обычный  
              // словарь с CustomerID в качестве ключа, а затем      
               // преобразование в потокобезопасный ConcurrentDictionary 
            if (customersCache==null)
            {
                customersCache=new ConcurrentDictionary<string, Customer>(
                    db.Customers.ToDictionary(c=>c.CustomerID));
            }
        }
        public async Task<Customer> CreateAsync(Customer c)
        {
            //нормализация CustomerID  в верхнем регистре
            c.CustomerID=c.CustomerID.ToUpper();
            //добавление в базу данных с помощью EF Core
            EntityEntry<Customer>added=await db.Customers.AddAsync(c);
            int affected=await db.SaveChangesAsync();
            if(affected==1)
            {
                //если клиент новый, то добавление его в кэш, иначе
                //произойдет вызов метода UpdateCache
                return customersCache.AddOrUpdate(c.CustomerID, c, UpdateCache);
            }
            else return null;
        }

        private Customer UpdateCache(string id , Customer c)
        {
            Customer old;
            if(customersCache.TryGetValue(id,out old))
            {
                if(customersCache.TryUpdate(id,c,old))
                {
                    return c;
                }
            }
            return null;
        }

        public async Task<bool?> DeleteAsync(string id)
        {
           id=id.ToUpper();
           //удаление из базы данных 
           Customer c =db.Customers.Find(id);
           db.Customers.Remove(c);
           int affected=await db.SaveChangesAsync();
           if(affected==1)
           {
               //удаление из кэша
               return customersCache.TryRemove(id,out c);
           }
           else return null;
        }

        public Task<IEnumerable<Customer>> RetrieveAllAsync()
        {
            //извлечение из кэша для производительности
            return Task.Run<IEnumerable<Customer>>(
                ()=>customersCache.Values);            
        }

        public Task<Customer> RetrieveAsync(string id)
        {
            return Task.Run(()=>
            {
                //извлечение из кэша для производительности
                id=id.ToUpper();
                customersCache.TryGetValue(id, out Customer c);
                return c;
            });
        }

        public async Task<Customer> UpdateAsync(string id,Customer c)
        {
           //нормализация ID клиента
           id=id.ToUpper();
           c.CustomerID=c.CustomerID.ToUpper();
           //обновление в базу данных
           db.Customers.Update(c);
           int affected=await db.SaveChangesAsync();
           if(affected==1)
           {
               //обновление в кэше
               return UpdateCache(id,c);
           }
           return null;
           
        }
    }
}