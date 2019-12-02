using System.Collections.Generic;

namespace Dormitories.Models
{
    public class Floor
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public Dormitory Dormitory { get; set; }
        public List<Block> Blocks { get; set; }
        public List<Room> Rooms { get; set; }
    }
}