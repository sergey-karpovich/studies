using AutoMapper;
using EmployeeAPI.Application.Dtos;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class AdditionalRepository
    {
        //private CompanyContext _context;
        //private readonly IMapper _mapper;
        //public AdditionalRepository(CompanyContext context,
        //    IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}
       
        //public Project AddProject(ProjectDTO projectDTO)
        //{
        //    var project = _mapper.Map<Project>(projectDTO);
        //    _context.Projects.Add(project);
        //    _context.SaveChanges();
        //    return project;
        //}
        
        //public List<Project> GetAllProject() => _context.Projects.ToList();

        //public void DeleteProject(int id)
        //{
        //    var project=_context.Projects.FirstOrDefault(p => p.Id == id);
        //    if(project!=null)
        //    {
        //        _context.Projects.Remove(project);
        //        _context.SaveChanges();
        //    }
        //} 
        //// // //
        //public Client AddClient(Client client)
        //{
        //    _context.Clients.Add(client);
        //    _context.SaveChanges();
        //    return client;
        //}

        //public List<Client> GetAllClient() => _context.Clients.ToList();

        //public void DeleteClient(int id)
        //{
        //    var client = _context.Clients.FirstOrDefault(p => p.Id == id);
        //    if (client != null)
        //    {
        //        _context.Clients.Remove(client);
        //        _context.SaveChanges();
        //    }
        //}

        //// // //
        //public Tarif AddTarif(Tarif tarif)
        //{
        //    _context.Tarifs.Add(tarif);
        //    _context.SaveChanges();
        //    return tarif;
        //}

        //public List<Tarif> GetAllTarifs() => _context.Tarifs.ToList();

        //public void DeleteTarif(int id)
        //{
        //    var tarif = _context.Tarifs.FirstOrDefault(p => p.Id == id);
        //    if (tarif != null)
        //    {
        //        _context.Tarifs.Remove(tarif);
        //        _context.SaveChanges();
        //    }
        //}

        //public Tarif UpdateTarif(int id, Tarif tarif)
        //{
        //    var _tarif = _context.Tarifs.FirstOrDefault(t=>t.Id==id);
        //    if(_tarif!=null)
        //    {
        //        _tarif.TarifType = tarif.TarifType;
        //        _tarif.StartDate = tarif.StartDate;
        //        _tarif.EndDate = tarif.EndDate;
        //        _tarif.TarifTypeId = tarif.TarifTypeId;
        //    }
        //    _context.SaveChanges();
        //    return _tarif;
        //}
    }
}
