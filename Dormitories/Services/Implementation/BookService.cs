using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;
using Dormitories.Loggers;


namespace Dormitories.Services.Implementation
{
    public class BookService
    {
        private readonly IDbConnection _dbConnection;
        private readonly AuthorService _authorService;
        private readonly ILogger _logger;

        public BookService()
        {
            _dbConnection = DBAccess.GetDbConnection();
            _authorService = new AuthorService();
            _logger = new FileLogger();
        }

        public List<Book> GetBooks()
        {
            _logger.LogInfo("Getting Books");

            var query = "SELECT * FROM [Books]";
            var Books = new List<Book>();

            using (var reader = _dbConnection.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    Books.Add(new Book()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Year = Convert.ToInt32(reader["Year"]),
                        Language = reader["Language"].ToString(),
                        Available = Convert.ToBoolean(reader["Available"]),
                        Author = _authorService.GetAuthorById(Convert.ToInt32(reader["AuthorId"]))
                    });
                }
            }

            return Books;
        }

        public Book GetBookById(int id)
        {
            _logger.LogInfo($"Getting Book by Id {id}");

            var query = "SELECT * FROM [Books] WHERE [Id] = @IdParameter";
            var Book = new Book();

            using (var reader = _dbConnection.ExecuteReader(query, new { IdParameter = id }))
            {
                while (reader.Read())
                {
                    Book = new Book()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Year = Convert.ToInt32(reader["Year"]),
                        Language = reader["Language"].ToString(),
                        Available = Convert.ToBoolean(reader["Available"]),
                        Author = _authorService.GetAuthorById(Convert.ToInt32(reader["AuthorId"]))
                    };
                }
            }

            return Book;
        }

        public bool InsertBook(Book Book)
        {
            _logger.LogInfo($"Inserting Book '{Book.Name}'");

            var rowsAffected = _dbConnection.Execute(@"INSERT INTO [Books]([Name],[Year],[Language],[Available],[AuthorId])
                                                                 VALUES(@BookName,@BookYear,@BookLanguage,@BookAvailable,@BookAuthorID)", new
            {
                BookName = Book.Name,            
                BookYear = Book.Year,
                BookLanguage = Book.Language,
                BookAvailable = true,
                BookAuthorID = Book.Author.ID,
            });

            return rowsAffected > 0;
        }

        public List<Book> GetBooksOfAythor(int authorId)
        {
            _logger.LogInfo("Getting Books of Author");

            var query = "SELECT * FROM [Books] WHERE [AuthorId] = @IdParameter";
            var Books = new List<Book>();

            using (var reader = _dbConnection.ExecuteReader(query, new { IdParameter = authorId }))
            {
                while (reader.Read())
                {
                    Books.Add(new Book()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Year = Convert.ToInt32(reader["Year"]),
                        Language = reader["Language"].ToString(),
                        Available = Convert.ToBoolean(reader["Available"]),
                        //Author = _authorService.GetAuthorById(Convert.ToInt32(reader["AuthorId"]))
                    });
                }
            }

            return Books;
        }
    }
}
