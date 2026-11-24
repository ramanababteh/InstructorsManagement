using DbReposirory.Interfaces;
using DbReposirory.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InstructorController : ControllerBase
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorController(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        [HttpGet]
        public IActionResult GetAll ()
        {
            return Ok(_instructorRepository.GetAll());
        }

        [HttpGet("{code}")]
        public IActionResult GetById (string code)
        {
            var item = _instructorRepository.GetByCode(code);
            if (item != null) { return Ok(item); }
            else { return NotFound("No Matching Instructor Code Found."); }
        }

        [HttpGet ("ex")]
        public IActionResult GetExperts()
        {
            return Ok(_instructorRepository.GetExperts());
        }

        [HttpGet("contact{code}")]
        public IActionResult ContactInstructor(string code)
        { 
            if (code != null) { return Ok(_instructorRepository.GetEmail(code)); } 
            else { return NotFound("No available cotact info for this Instructor."); }
            }

        [HttpPost]
        public IActionResult AddInstructor (Instructor newInstructor)
        {
            if (_instructorRepository.AddInstructor(newInstructor)) { return Ok("Instructor Added."); }
            else { return BadRequest("This Instructor Code is already in use."); }
        }

        [HttpPut]
        public IActionResult UpdateInstructor (Instructor newInstructor)
        {
            if (_instructorRepository.UpdateInstructor(newInstructor)) { return Ok("Data Updated."); }
            else { return NotFound("No Matching Instructor Code Found."); }
        }

        [HttpDelete ("{code}")]
        public IActionResult DeleteInstructor (string code)
        {
            if (_instructorRepository.DeleteInstructor(code)) { return Ok("Instructor Removed."); }
            else { return NotFound("No Matching Instructor Code Found."); }
        }
    }
}
