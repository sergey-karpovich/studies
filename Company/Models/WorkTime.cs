
namespace Company.Models{
    public class WorkTime{
        private decimal salary;
        public long Id { get; set; }
        public int? numMonth { get; set; }
        public int? hours { get; set; }
        public decimal? lastRate { get; set; }
        public decimal? money
        { 
            get=>salary; 
            set=>salary=hours*lastRate??0; 
        }
        public long? EmployeeId{get;set;}
        public Employee? Employee{get;set; }
    }
}