using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Dormitories.Models;
using Dormitories.Services;
using Dormitories.Services.Implementation;

namespace Dormitories.Controllers
{
    public class AuthorController : Controller
    {
        // GET: api/authors
        [HttpGet]
        [Route("api/authors")]
        public List<Author> GetAuthors()
        {
            Author a = new Author() { ID = 1, Name = "Bram", Surname = "Stoker", Fullname = "Bram Stoker", Nationality = "English", Books = "Dracula" };
            Author b = new Author() { ID = 2, Name = "Brama", Surname = "Stokera", Fullname = "Brama Stokera", Nationality = "Englisha", Books = "Draculaaaa" };
            List<Author> Authors = new List<Author>(new Author[] { a, b });

            return Authors;
        }

        // INSERT: api/authors
        [HttpPost]
        [Route("api/authors")]
        public bool InsertAuthors([FromBody]Author author)
        {


            return true;
            
        }
    }
}