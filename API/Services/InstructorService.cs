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

        public List<InstructorDto> GetExperts()
        {
            int minExperience = 10;
            var instructors = _instructorRepository.GetExperts(minExperience);
            return instructors.Adapt<List<InstructorDto>>();
        }

        public string? GetEmail(string code)
        {
            if (IsExistInstructor(code))
            {
                return _instructorRepository.GetEmail(code);
            }
            else { return null; }
        }

        public bool AddInstructor(InstructorDto dto)
        {
            if (!IsExistInstructor(dto.InstructorCode))
            {
                var instructor = dto.Adapt<Instructor>();
                return _instructorRepository.AddInstructor(instructor);
            }
            else { return false; }
        }

        public bool UpdateInstructor(InstructorDto dto)
        {
            if (IsExistInstructor(dto.InstructorCode))
            {
                var instructor = dto.Adapt<Instructor>();
                return _instructorRepository.UpdateInstructor(instructor);
            }
            else { return false; }
        }

        public bool DeleteInstructor(string code)
        {
            if (IsExistInstructor(code))
            {
                return _instructorRepository.DeleteInstructor(code);
            }
            else { return false; }
        }

        public bool IsExistInstructor(string code)
        {
            return _instructorRepository.GetByCode(code) != null;
        }
    }
}
