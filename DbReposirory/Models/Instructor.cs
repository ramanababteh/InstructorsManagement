namespace DbReposirory.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string InstructorCode { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int YearsOfExperience { get; set; }
        public string? Bio { get; set; }
    }
}
