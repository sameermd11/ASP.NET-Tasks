using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
namespace WebApplication5.Models
{
    public class Employee
    {
        [Key]
        public int EmpNo { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int Salary { get; set; }
        public int DeptNo { get; set; }
    }

    public class EmployeeDbContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }
        public EmployeeDbContext(DbContextOptions<EmployeeDbContext> options)
        : base(options) { }
    }
}
