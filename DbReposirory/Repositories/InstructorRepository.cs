using DbReposirory.Interfaces;
using DbReposirory.Models;

namespace DbReposirory.Repositories
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _appDbContext;

        public InstructorRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Instructor> GetAll ()
        {
            return _appDbContext.Instructors.ToList ();
        }

        public Instructor? GetByCode (string code)
        {
            return _appDbContext.Instructors.FirstOrDefault(I => I.InstructorCode == code);
        }

        public List<Instructor> GetExperts(int minExperience)
        {
            return _appDbContext.Instructors.Where(i => i.YearsOfExperience >= minExperience).ToList();
        }

        public bool AddInstructor (Instructor newInstructor)
        {
            _appDbContext.Instructors.Add(newInstructor);
            return (_appDbContext.SaveChanges() > 0);
        }

        public bool UpdateInstructor(Instructor updated, Instructor target)
        {
            target.FullName = updated.FullName;
            target.Email = updated.Email;
            target.YearsOfExperience = updated.YearsOfExperience;
            target.Bio = updated.Bio;

            return (_appDbContext.SaveChanges() > 0);
        }

        public bool DeleteInstructor(Instructor target)
        {
            _appDbContext.Instructors.Remove(target);
            return (_appDbContext.SaveChanges() > 0);
        }
    }
}
