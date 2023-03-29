using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcCompanyProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace MvcCompanyProject.Controllers
{
    [Authorize]
    public class EmployeeController : Controller
    {
        Context c = new Context();
        
        public IActionResult Index()
        {
            return View(c.Employees.Include(x => x.Department).ToList());
        }
        public IActionResult NewEmployee()
        {
            List<SelectListItem> values = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.vls = values;

            return View();
        }
        [HttpPost]
        public IActionResult NewEmployee(Employee e)
        {
            var deger = c.Departments.Where(x => x.DepartmentId == e.Department.DepartmentId).FirstOrDefault();
            e.Department = deger;

            var check = c.Employees.Where(x => x.EmployeeName == e.EmployeeName && x.EmployeeSurname == e.EmployeeSurname && x.EmployeeCity == e.EmployeeCity && x.Department == e.Department).FirstOrDefault();

            if (check == null)
            {
                c.Employees.Add(e);
                c.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult DeleteEmployee(int id)
        {
            var check = c.Employees.Find(id);

            if (check != null)
            {
                c.Employees.Remove(check);
                c.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult FindEmployee(int id)
        {
            List<SelectListItem> values = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString(),
                                           }).ToList();

            return View(c.Employees.Find(id));
        }
        public IActionResult UpdateEmployee(int id)
        {
            List<SelectListItem> values = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.vls = values;

            return View(c.Employees.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee e)
        {
            var deger = c.Departments.Where(x => x.DepartmentId == e.Department.DepartmentId).FirstOrDefault();
            e.Department = deger;

            var check = c.Employees.Find(e.EmployeeId);

            if (check != null)
            {
                check.EmployeeName = e.EmployeeName;
                check.EmployeeSurname = e.EmployeeSurname;
                check.EmployeeCity = e.EmployeeCity;
                check.Department = e.Department;
                c.SaveChanges();
            }

            return RedirectToAction("Index");
        }

    }
}
