using API.DTOs;
using API.ServicesInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorService _instructorService;
        public InstructorController(IInstructorService instructorService)
        {
            _instructorService = instructorService;
        }

        [HttpGet]
        public IActionResult GetAll ()
        {
            return Ok(_instructorService.GetAll());
        }

        [HttpGet("{code}")]
        public IActionResult GetById (string code)
        {
            var item = _instructorService.GetByCode(code);
            if (item != null) { return Ok(item); }
            else { return NotFound("No Matching Instructor Code Found."); }
        }

        [HttpGet ("ex")]
        public IActionResult GetExperts()
        {
            return Ok(_instructorService.GetExperts());
        }

        [HttpGet("contact/{code}")]
        public IActionResult ContactInstructor(string code)
        {
            string email = _instructorService.GetEmail(code);
            if (email != null) { return Ok(email); } 
            else { return NotFound("No available cotact info for this Instructor."); }
        }

        [HttpPost]
        public IActionResult AddInstructor (InstructorDto newInstructor)
        {
            if (_instructorService.AddInstructor(newInstructor)) { return Ok("Instructor Added."); }
            else { return Conflict("This Instructor Code is already in use."); }
        }

        [HttpPut]
        public IActionResult UpdateInstructor (InstructorDto newInstructor)
        {
            if (_instructorService.UpdateInstructor(newInstructor)) { return Ok("Data Updated."); }
            else { return NotFound("No Matching Instructor Code Found."); }
        }

        [HttpDelete ("{code}")]
        public IActionResult DeleteInstructor (string code)
        {
            if (_instructorService.DeleteInstructor(code)) { return Ok("Instructor Removed."); }
            else { return NotFound("No Matching Instructor Code Found."); }
        }
    }
}
