using System.Collections.Generic;

namespace Dormitories.Models
{
    public class Block
    {
        public int Id { get; set; }
        public Floor Floor { get; set; }
        public string Name { get; set; }
        public List<Room> Rooms { get; set; }
    }
}