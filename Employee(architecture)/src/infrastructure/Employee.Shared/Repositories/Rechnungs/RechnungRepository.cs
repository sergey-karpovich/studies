using AutoMapper;
using EmployeeAPI.Data.Contexts;
using EmployeeAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Repositories.Rechnungs
{
    public class RechnungRepository
    {
        private CompanyContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<RechnungRepository> _logger;

        public RechnungRepository(CompanyContext context, IMapper mapper, ILogger<RechnungRepository> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        private List<DeveloperProject> _developerProjects;
        private List<Tarif> _tarifList;
        private List<Client> _clientsWithProject;


        public List<Rechnung> CreateAllRechnungs(DateTime startDate, DateTime endDate)
        {
            _developerProjects = GetDeveloperProjectsByDate(startDate, endDate);
            _tarifList = GetTarifs();
            _clientsWithProject = new List<Client>();

            // from _developerProjects select unique ClientId

            List<Rechnung> allRechnungs = new List<Rechnung>();
             

            foreach(Client client in _clientsWithProject)
            {
                // create folder foreach client

                // create list Rechnungs

                // create file foreach Rechnung  in list 



                foreach(Project project in client.Project)
                {
                    var rechnung = CreateRechnung(project);

                    allRechnungs.Add(rechnung);
                }
            }

            // return to vue
            return allRechnungs;
        }

        public List<DeveloperProject> GetDeveloperProjectsByDate(DateTime startDate, DateTime endDate)
        {
            var developerProject = _context.DeveloperProject
                .Where(dp=>dp.StartDate<=startDate && dp.EndDate<=endDate)
                .Include(dp => dp.Project).ThenInclude(p => p.Client)
                .Include(dp => dp.Developer)
                .Include(dp => dp.Tarif)
                .ToList();

            return new List<DeveloperProject>();
        }

        public Rechnung CreateRechnung(Project project)
        {            
            var rechnungPositionList = new List<RechnungPosition>();

            foreach (var tarif in _tarifList)
            {
                var rechnungPosition = CreateRechnungPosition();
                rechnungPositionList.Add(rechnungPosition);
            }

            return new Rechnung { };
        }


        public RechnungPosition CreateRechnungPosition()
        {

            return new RechnungPosition();
        }

        public List<Tarif> GetTarifs()
        {
            List<Tarif> tarifList = new List<Tarif>();
            foreach (var entity in _developerProjects)
            {
                tarifList.Add(entity.Tarif);
            }
            // select unique
            return tarifList;
        }

    }
}
