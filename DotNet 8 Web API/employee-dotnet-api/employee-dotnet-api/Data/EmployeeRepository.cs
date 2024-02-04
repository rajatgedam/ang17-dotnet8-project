using Microsoft.EntityFrameworkCore;

namespace employee_dotnet_api.Data
{
  public class EmployeeRepository
  {
    private readonly AppDbContext _appDbContext;
    public EmployeeRepository(AppDbContext appDbContext) {
      _appDbContext = appDbContext;
    }

    public async Task AddEmployeeAsync(Employee employee) {
        await _appDbContext.Set<Employee>().AddAsync(employee);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<Employee>> GetEmployeeListAsync()
    {
      //await _appDbContext.Set<Employee>().ToList();
      return await _appDbContext.Employees.ToListAsync();
    }


    public async Task<Employee> GetEmployeeByIdAsync(int id) {
      return await _appDbContext.Employees.FindAsync(id);
    }

    public async Task UpdateEmployeeByIdAsync(int id, Employee model) {
      var employee = await _appDbContext.Employees.FindAsync(id);
      if (employee == null)
      {
        throw new Exception("Employee does not exist!");
      }
      employee.Name= model.Name;
      //Email is read only, user cannot change email
      //employee.Email= model.Email;
      employee.Age = model.Age;
      employee.Phone= model.Phone;
      employee.Salary= model.Salary;
      await _appDbContext.SaveChangesAsync();


    }

    public async Task DeleteEmployeeAsync(int id)
    {
      var employee = await _appDbContext.Employees.FindAsync(id);
      if (employee == null)
      {
        throw new Exception("Employee does not exist!");
      }
      _appDbContext.Employees.Remove(employee);
      await _appDbContext.SaveChangesAsync();

    }


  }
}
