using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public interface IGenericService<T,TDTO>
    {
        ServiceResponse<List<TDTO>> GetAll();
        ServiceResponse<TDTO> GetById(int id);
        ServiceResponse<bool> Create(TDTO item);
        ServiceResponse<bool> Delete(int itemId);
        ServiceResponse<bool> Update(int itemId, TDTO item);
    }
}
