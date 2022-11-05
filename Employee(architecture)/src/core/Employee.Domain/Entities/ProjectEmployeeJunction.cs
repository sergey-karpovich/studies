namespace EmployeeAPI.Domain.Entities
{
    public class ProjectEmployeeJunction
    {
        //public long Id { get; set; }
        public long ProjectId { get; set; }
        //public Project? Project { get; set; }
        public long EmployeeId { get; set; }
        // public Employee? Employee { get; set; }
        public DateTime DateJoined { get; set; }
    }
}
