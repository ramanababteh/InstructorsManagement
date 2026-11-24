using DbReposirory.Models;

namespace DbReposirory.Interfaces
{
    public interface IInstructorRepository
    {
        public List<Instructor> GetAll();
        public Instructor GetByCode(string code);
        public List<Instructor> GetExperts();
        public string GetEmail(string code);
        public bool AddInstructor(Instructor instructor);
        public bool UpdateInstructor(Instructor instructor);
        public bool DeleteInstructor(string code);
    }
}
