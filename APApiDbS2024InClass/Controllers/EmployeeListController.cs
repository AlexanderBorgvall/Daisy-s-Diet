using APApiDbS2024InClass.DataRepository;
using APApiDbS2024InClass.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APApiDbS2024InClass.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeListController : Controller
    {
        private Repository Repository { get; }

        public EmployeeListController()
        {
            Repository = new Repository();
        }

        // GET: api/employee
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Employee employee = Repository.GetEmployeeById(id);
            if (employee == null) { return BadRequest("Provided ID does not exist");}
            List<TimeRegistration> registrations = Repository.GetTimeregistrationsById(id);
            return Ok(new { EmployeeName = employee.EmployeeName, registrations});
        }
    }
}

       