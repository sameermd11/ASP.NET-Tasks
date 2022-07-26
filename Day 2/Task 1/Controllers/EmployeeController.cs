using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeManager context = new EmployeeManager();
        public IActionResult Index()
        {
            List<Employee> employees = context.GetAllDetails();
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            Employee obj = context.GetEmployeeByID(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = context.GetEmployeeByID(id);
            return View(obj);
        }


        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            if (ModelState.IsValid == true)
            {
                context.UpdateDetails(obj);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RequestType = Request.Method;
                ViewBag.ErrorMessage = "Invalid Data";
                return View();
            }            
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj=context.GetEmployeeByID(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            context.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            if (ModelState.IsValid == true)
            {
                context.AddEmployee(obj);
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.RequestType = Request.Method;
                ViewBag.ErrorMessage = "Invalid Data";
                return View();
            }
        }
    }
}
