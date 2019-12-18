using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dormitories.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public int Year { get; set; }
        public bool Available { get; set; }
        public List<Author> Authors { get; set; }
    }
}
