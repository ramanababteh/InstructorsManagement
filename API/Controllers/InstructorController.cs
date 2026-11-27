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
        public IActionResult GetByCode (string code)
        {
            var instructor = _instructorService.GetByCode(code);

            if (instructor != null) { return Ok(instructor); }
            else { return NotFound("No Matching Instructor Code Found."); }
        }

        [HttpGet ("experts/{minExperience?}")]
        public IActionResult GetExperts (int minExperience = 10)
        {
            return Ok(_instructorService.GetExperts(minExperience));
        }

        [HttpGet("contact/{code}")]
        public IActionResult ContactInstructor (string code)
        {
            string? email = _instructorService.GetEmail(code);

            if (email != null) { return Ok(email); } 
            else { return NotFound("No available contact info for this Instructor."); }
        }

        [HttpPost]
        public IActionResult AddInstructor (InstructorDto newInstructor)
        {
            if (_instructorService.AddInstructor(newInstructor)) { return Created("Instructor Added.", newInstructor); }
            else { return Conflict("This Instructor Code is already in use."); }
        }

        [HttpPut]
        public IActionResult UpdateInstructor (InstructorDto updatedInstructor)
        {
            if (_instructorService.UpdateInstructor(updatedInstructor)) { return Ok("Data Updated."); }
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
