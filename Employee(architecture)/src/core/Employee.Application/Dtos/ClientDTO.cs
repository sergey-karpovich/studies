using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Application.Dtos
{
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public int? AddressId { get; set; }
        public List<ProjectDTO>? ProjectDTOList { get; set; }
    }
}
