using DbReposirory.Models;

namespace DbReposirory.Interfaces
{
    public interface IInstructorRepository
    {
        public List<Instructor> GetAll();
        public Instructor? GetByCode(string code);
        public List<Instructor> GetExperts(int minExperience);
        public bool AddInstructor(Instructor newInstructor);
        public bool UpdateInstructor(Instructor updated, Instructor target);
        public bool DeleteInstructor(Instructor target);
    }
}
