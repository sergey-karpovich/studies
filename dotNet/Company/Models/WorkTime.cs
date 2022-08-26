
namespace Company.Models{
    public class WorkTime{
        public long Id { get; set; }
        public int? numMonth { get; set; }
        public int? hours { get; set; }
        public decimal? lastRate { get; set; }
        public decimal? money{ get; set; }
        public long? EmployeeId{get;set;}
        public Employee? Employee { get; set; }
    }
}