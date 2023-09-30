using System.Net;

namespace FirstProject.Models
{
    public class Employee
    {
        public Guid? Id { get; set; }
        public string EmployeeNo { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool Gender { get; set; } = true;
        public double Salary { get; set; }
        public bool IsPartTime { get; set; } = false;
        public string Address { get; set; }
        public string Phone { get; set; }
        public string CreditCard { get; set; }
        public string Description { get; set; 
    }
}
