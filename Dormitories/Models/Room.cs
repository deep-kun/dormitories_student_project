using System.Collections.Generic;

namespace Dormitories.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int TotalPlaces { get; set; }
        public int FreePlaces { get; set; }
        public Faculty Faculty { get; set; }
        public Floor Floor { get; set; }
        public Block Block { get; set; }
        public string Name { get; set; }
        public List<Student> Students { get; set; }
    }
}