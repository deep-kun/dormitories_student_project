namespace Dormitories.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Faculty Faculty { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StudentCardId { get; set; }
        public Group Group { get; set; }
        public Room Room { get; set; }
        public int StudyYear { get; set; }
        public StudentCategory StudentCategory { get; set; }
        public User User { get; set; }
    }
}