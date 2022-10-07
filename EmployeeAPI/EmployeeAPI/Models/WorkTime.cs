namespace EmployeeAPI.Models
{
    public class WorkTime
    {
        public long Id { get; set; }
        public int? NumMonth { get; set; }
        public int? Hours { get; set; }
        public decimal? LastRate { get; set; }
        public decimal? Money { get; set; }
        public long? EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
