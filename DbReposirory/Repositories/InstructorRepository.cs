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

        public Instructor GetByCode (string code)
        {
            return _appDbContext.Instructors.FirstOrDefault(I => I.InstructorCode == code);
        }

        public List<Instructor> GetExperts()
        {
            return _appDbContext.Instructors.Where(i => i.YearsOfExperience >= 10).ToList();
        }

        public bool AddInstructor (Instructor instructor)
        {
            var target = GetByCode(instructor.InstructorCode);

            if (target == null)
            {
                _appDbContext.Instructors.Add(instructor);
                return (_appDbContext.SaveChanges() > 0);
            }
            else { return false; }
        }

        public bool UpdateInstructor(Instructor instructor)
        {
            var target = GetByCode(instructor.InstructorCode);

            if (target != null)
            {
                target.FullName = instructor.FullName;
                target.Email = instructor.Email;
                target.YearsOfExperience = instructor.YearsOfExperience;
                target.Bio = instructor.Bio;

                return (_appDbContext.SaveChanges() > 0);
            }
            else { return false; }
        }

        public bool DeleteInstructor(string code)
        {
            var target = GetByCode(code);

            if (target != null)
            {
                _appDbContext.Instructors.Remove(target);
                return (_appDbContext.SaveChanges() > 0);
            }
            else { return false; }
        }
    }
}
