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
    [Produces("application/json")]
    public class BookController : Controller
    {
        // GET: api/books
        [HttpGet]
        [Route("api/books")]
        public List<Book> GetBooks()
        {
            Book b = new Book() { Id = 1, Available = true, Language = "English", Name = "Dracula", Year = 2000, Author = new Author() { ID = 1, Name = "Bram", Surname = "Stoker", FullName = "Bram Stoker", Nationality = "English", Books = "Dracula" } };  //"Bram Stoker Bram Stoker Bram Stoker Bram Stoker Bram Stoker Bram Stoker Bram Stoker Bram Stoker Bram Stoker Bram Stoker Bram Stoker Bram Stoker" };

            List<Book> books = new List<Book>(new Book[] {b});

            return books;
        }
    }
}