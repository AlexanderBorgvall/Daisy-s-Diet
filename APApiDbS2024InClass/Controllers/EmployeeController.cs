using APApiDbS2024InClass.DataRepository;
using APApiDbS2024InClass.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace APApiDbS2024InClass.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        private Repository Repository { get; }

        public EmployeeController()
        {
            Repository = new Repository();
        }

        // GET: api/employee
        [HttpGet]
        public ActionResult Get()
        {
            return Ok(Repository.GetEmployees());
        }

        // GET api/employee/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Employee employee = Repository.GetEmployeeById(id);
            if (employee == null)
                return NotFound($"Employee with id {id} not found");

            return Ok(employee);
        }

       
        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee info not correct");
            }

            bool status = Repository.InsertEmployee(employee);
            if (status)
            {
                return Ok();
            }

            return BadRequest();
        }

        // PUT api/values/5
        [HttpPut()]
        public ActionResult Put([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest("Employee info not correct");
            }

            Employee existingEmployee = Repository.GetEmployeeById(employee.ID);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with id {employee.ID} not found");
            }

            bool status = Repository.UpdateEmployee(employee);
            if (status)
            {
                return Ok();
            }

            return BadRequest("Something went wrong");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Employee existingEmployee = Repository.GetEmployeeById(id);
            if (existingEmployee == null)
            {
                return NotFound($"Employee with id {id} not found");
            }

            bool status = Repository.DeleteEmployee(id);
            if (status)
            {
                return NoContent();
            }

            return BadRequest($"Unable to delete employee with id {id}");
        }
    }
}

