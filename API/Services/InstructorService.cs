using API.DTOs;
using API.ServicesInterfaces;
using DbReposirory.Interfaces;
using DbReposirory.Models;
using Mapster;

namespace API.Services
{
    public class InstructorService : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorService(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public List<InstructorDto> GetAll()
        {
            var instructors = _instructorRepository.GetAll();
            return instructors.Adapt<List<InstructorDto>>();
        }

        public InstructorDto? GetByCode(string code)
        {
            var instructor = _instructorRepository.GetByCode(code);
            return instructor?.Adapt<InstructorDto>();
        }

        public List<InstructorDto> GetExperts(int minExperience)
        {
            var instructors = _instructorRepository.GetExperts(minExperience);
            return instructors.Adapt<List<InstructorDto>>();
        }

        public string? GetEmail(string code)
        {
            var targetInstructor = GetTarget(code);

            if (targetInstructor != null)
            {
                return targetInstructor.Email;
            }
            else { return null; }
        }

        public bool AddInstructor(InstructorDto dto)
        {
            var newInstructor = dto.Adapt<Instructor>();

            if (GetTarget(newInstructor.InstructorCode) == null)
            {
                return _instructorRepository.AddInstructor(newInstructor);
            }
            else { return false; }
        }

        public bool UpdateInstructor(InstructorDto dto)
        {
            var updatedInstructor = dto.Adapt<Instructor>();
            var targetInstructor = GetTarget(dto.InstructorCode);

            if (targetInstructor != null)
            {
                return _instructorRepository.UpdateInstructor(updatedInstructor, targetInstructor);
            }
            else { return false; }
        }

        public bool DeleteInstructor(string code)
        {
            var targetInstructor = GetTarget(code);

            if (targetInstructor != null)
            {
                return _instructorRepository.DeleteInstructor(targetInstructor);
            }
            else { return false; }
        }

        private Instructor? GetTarget(string code)
        {
            return _instructorRepository.GetByCode(code);
        }
    }
}
