using employee_dotnet_api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace employee_dotnet_api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class EmployeeController : ControllerBase
  {

    private readonly EmployeeRepository _employeeRepository;
    public EmployeeController(EmployeeRepository employeeRepository) {
      _employeeRepository = employeeRepository;
    }


    [HttpPost]
    public async Task<ActionResult> AddEmployee([FromBody] Employee model)
    {
      await _employeeRepository.AddEmployeeAsync(model);
      return Ok();
    }


    [HttpGet]
    public async Task<ActionResult> GetEmployeeList()
    {
      //await _employeeRepository.AddEmployee(model);
      //return Ok();
      var employeeList = await _employeeRepository.GetEmployeeListAsync();
      return Ok(employeeList);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetEmployeeById([FromRoute] int id) {
      var employee = await _employeeRepository.GetEmployeeByIdAsync(id);
      return Ok(employee);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmployee([FromRoute] int id, [FromBody] Employee model)
    {
      await _employeeRepository.UpdateEmployeeByIdAsync(id, model);
      return Ok();
    }

    [HttpDelete("{id}")]

    public async Task<ActionResult> DeleteEmployee([FromRoute] int id)
    {
       await _employeeRepository.DeleteEmployeeAsync(id);
      return Ok();
    }

  }
}
