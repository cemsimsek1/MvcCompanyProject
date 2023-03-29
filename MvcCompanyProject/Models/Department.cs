using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcCompanyProject.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public IList<Employee> Employees { get; set; }
    }
}
