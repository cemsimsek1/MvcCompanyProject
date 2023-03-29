using System.ComponentModel.DataAnnotations;

namespace MvcCompanyProject.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public string EmployeeCity { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
    }
}
