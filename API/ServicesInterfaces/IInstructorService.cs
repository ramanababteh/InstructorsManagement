using API.DTOs;

namespace API.ServicesInterfaces
{
    public interface IInstructorService
    {
        public List<InstructorDto> GetAll();
        public InstructorDto? GetByCode(string code);
        public List<InstructorDto> GetExperts();
        public string? GetEmail(string code);
        public bool AddInstructor(InstructorDto dto);
        public bool UpdateInstructor(InstructorDto dto);
        public bool DeleteInstructor(string code);
        public bool IsExistInstructor(string code);
    }
}
