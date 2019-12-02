using System.Collections.Generic;

namespace Dormitories.Models
{
    public class Dormitory
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public int Number { get; set; }
        public Administrator Comendant { get; set; }
        public List<Floor> Floors { get; set; }
    }
}