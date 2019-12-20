using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormitories.Models
{
    public class Author
    {
        public int ID { get; set; }
        public string Name { get; set; }
        
        public string Surname { get; set; }
        public string Fullname { get; set; }
        public string Nationality { get; set; }
        //public List<Book> Books { get; set; }
        public string Books { get; set; }
    }
}
