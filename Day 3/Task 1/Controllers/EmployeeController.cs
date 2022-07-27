using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Repositories;


namespace WebApplication5.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepo _repos;

        public EmployeeController(IEmployeeRepo repos)
        {
            _repos = repos;
        }

        public IActionResult Index()
        {
            List<Employee> empList=_repos.GetAllEmployees();
            return View(empList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _repos.AddEmployee(obj);
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            Employee obj = _repos.GetEmployeeById(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employee obj = _repos.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _repos.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Employee obj = _repos.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        public IActionResult DeleteConfirm(int id)
        {
            _repos.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
