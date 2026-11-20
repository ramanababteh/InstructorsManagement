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

        [HttpPost]
        public IActionResult AddInstructor (Instructor newInstructor)
        {
            if (_instructorRepository.AddInstructor(newInstructor)) { return Ok("Instructor Added."); }
            else { return BadRequest("Something went Wrong, try again."); }
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
