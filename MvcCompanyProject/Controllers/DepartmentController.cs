using Microsoft.AspNetCore.Mvc;
using MvcCompanyProject.Models;
using System.Linq;

namespace MvcCompanyProject.Controllers
{
    public class DepartmentController : Controller
    {
        Context c = new Context();
        public IActionResult Index()
        {
            return View(c.Departments.ToList());
        }
        public IActionResult NewDepartment()
        {
            return View();
        }
        [HttpPost]
        public IActionResult NewDepartment(Department d)
        {
            var add = c.Departments.Where(x => x.DepartmentName == d.DepartmentName).FirstOrDefault();

            if (add == null)
            {
                c.Departments.Add(d);
                c.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult DeleteDepartment(int id)
        {
            var find = c.Departments.Find(id);

            if (find != null)
            {
                c.Departments.Remove(find);
                c.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult FindDepartment(int id)
        {
            return View(c.Departments.Find(id));
        }

        public IActionResult UpdateDepartment(int id)
        {
            return View(c.Departments.Find(id));
        }
        [HttpPost]
        public IActionResult UpdateDepartment(Department d)
        {
            var check = c.Departments.Find(d.DepartmentId);

            if (check != null)
            {
                check.DepartmentName = d.DepartmentName;
                c.SaveChanges();
            }

            return RedirectToAction("Index");
        }
        public IActionResult DetailsDepartment(int id)
        {
            var emp = c.Employees.Where(x => x.DepartmentId == id).ToList();
            var detdep = c.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.depdet = detdep;

            return View(emp);
        }
    }
}
