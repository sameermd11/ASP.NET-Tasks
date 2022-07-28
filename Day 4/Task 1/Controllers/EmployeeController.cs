using Microsoft.AspNetCore.Mvc;
using WebApplication5.Models;
using WebApplication5.Repositories;
using WebApplication5.Filters;

namespace WebApplication5.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepo _repos;
        private readonly ILogger<HomeController> _logger;

        public EmployeeController(IEmployeeRepo repos, ILogger<HomeController> logger)
        {
            _repos = repos;
            _logger = logger;
        }

        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Index()
        {
            _logger.LogInformation("Index Action is Processed");
            List<Employee> empList=_repos.GetAllEmployees();
            return View(empList);
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create()
        {
            _logger.LogInformation("Create Get Action is Processed");
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create(Employee obj)
        {
            _logger.LogInformation("Create Post Action is Processed");
            _repos.AddEmployee(obj);
            return RedirectToAction("Index");
        }

        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Details(int id)
        {
            _logger.LogInformation("Details Action is Processed");
            Employee obj = _repos.GetEmployeeById(id);
            return View(obj);
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(int id)
        {
            _logger.LogInformation("Edit Get Action is Processed");
            Employee obj = _repos.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(Employee obj)
        {
            _logger.LogInformation("Edit Post Action is Processed");
            _repos.UpdateEmployee(obj);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation("Delete Get Action is Processed");
            Employee obj = _repos.GetEmployeeById(id);
            return View(obj);
        }

        [HttpPost]
        [ActionName("Delete")]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult DeleteConfirm(int id)
        {
            _logger.LogInformation("Delete Post Action is Processed");
            _repos.DeleteEmployee(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult GetEmployeesByDeptNo(int deptNo)
        {
            _logger.LogInformation("Get Employees By Dept No  Get Action is Processed");
            return View();
        }

        [HttpPost]
        [ActionName("GetEmployeesByDeptNo")]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult GetEmployeesByDeptNoConfirm(int deptNo)
        {
            _logger.LogInformation("Get Employees By Dept No post Action is Processed");
            IEnumerable<Employee> empList = _repos.GetEmployeesByDeptNo(deptNo);
            ViewBag.RequestType = Request.Method;
            return View(empList);
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult GetEmployeesByJob()
        {
            _logger.LogInformation("Get Employees By Job Get Action is Processed");
            return View();
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult GetEmployeesByJob(string job)
        {
            _logger.LogInformation("Get Employees By Job Post Action is Processed");
            IEnumerable<Employee> empList=_repos.GetEmployeesByJob(job);
            return View(empList);
        }
    }
}
