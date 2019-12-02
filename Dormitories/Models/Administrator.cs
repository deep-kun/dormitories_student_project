namespace Dormitories.Models
{
    public class Administrator
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public Faculty Faculty { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public User User { get; set; }
    }
}