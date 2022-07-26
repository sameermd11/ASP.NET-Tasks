namespace WebApplication4.Models
{
    public class EmployeeManager
    {
        public static List<Employee> employees = new List<Employee>();
        public EmployeeManager()
        {
            employees = new List<Employee>()
            {
                new Employee(){EmpNo=101, Ename="Ankit", Job="Developer", Salary=20000, DeptNo=10},
                new Employee(){EmpNo=102, Ename="Arvind", Job="Manager", Salary=25000, DeptNo=10},
                new Employee(){EmpNo=103, Ename="Satvik", Job="Developer", Salary=18000, DeptNo=20},
                new Employee(){EmpNo=104, Ename="Kiran", Job="Manager", Salary=28000, DeptNo=20},
                new Employee(){EmpNo=105, Ename="Pavan", Job="Intern", Salary=8000, DeptNo=30},
            };
        }
        public List<Employee> GetAllDetails()
        {
            return employees;
        }
        public Employee GetEmployeeByID(int id)
        {
            return employees.Find(item => item.EmpNo == id);
        }
        public void AddEmployee(Employee obj)
        {
            employees.Add(obj);
        }
        public void UpdateDetails(Employee obj)
        {
            Employee obj1 = employees.Find(item => item.EmpNo == obj.EmpNo);
            employees.Remove(obj1);
            employees.Add(obj);
        }
        public void DeleteEmployee(int id)
        {
            Employee obj = employees.Find(item => item.EmpNo == id);
            employees.Remove(obj);
        }
    }
}
