using WebApplication5.Models;
namespace WebApplication5.Repositories
{
    public class EmployeeRepo : IEmployeeRepo
    {
        EmployeeDbContext _context;
        public EmployeeRepo(EmployeeDbContext context)
        {
            _context = context;
        }

        public List<Employee> GetAllEmployees()
        {
            List<Employee> empList = _context.employees.ToList();
            return empList;
        }

        public Employee GetEmployeeById(int id)
        {
            Employee emp = _context.employees.Find(id);
            return emp;
        }
        public void AddEmployee(Employee obj)
        {
            _context.employees.Add(obj);
            _context.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            Employee obj = _context.employees.Find(id);
            _context.employees.Remove(obj);
            _context.SaveChanges();
        }
        public void UpdateEmployee(Employee obj)
        {
            _context.employees.Update(obj);
            _context.SaveChanges();
        }
    }
}
