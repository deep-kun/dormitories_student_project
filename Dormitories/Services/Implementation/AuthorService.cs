using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;
using Dormitories.Loggers;
using System.Linq;

namespace Dormitories.Services.Implementation
{
    public class AuthorService
    {
        private readonly IDbConnection _dbConnection;
        //private readonly BookService _bookService;
        private readonly ILogger _logger;

        public AuthorService()
        {
            _dbConnection = DBAccess.GetDbConnection();
            //_bookService = new BookService();
            _logger = new FileLogger();
        }

        public List<Author> GetAuthors()
        {
            _logger.LogInfo("Getting Authors");

            var query = "SELECT * FROM [Authors]";
            var Authors = new List<Author>();

            using (var reader = _dbConnection.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    Authors.Add(new Author()
                    {
                        ID = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Fullname = reader["Name"].ToString() + " " + reader["Surname"].ToString(),
                        Nationality = reader["Nationality"].ToString(),
                        //Books = get booknames
                        //Books = string.Join(", ", GetBooksOfAythor(Convert.ToInt32(reader["Id"])).Select(x => x.Name))
                    });
                }
            }

            foreach(Author a in Authors)
            {
                a.Books = string.Join(", ", GetBooksOfAythor(a.ID).Select(x => x.Name));
            }

            return Authors;
        }

        public List<Book> GetBooksOfAythor(int authorId)
        {
            _logger.LogInfo("Getting Books of Author");

            //var res = _dbConnection
            //    .Query<Faculty>("SELECT * FROM [Books] WHERE [AuthorId] = " + authorId.ToString())
            //    .SingleOrDefault();


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

        public bool InsertAuthor(Author Author)
        {
            _logger.LogInfo($"Inserting Author '{Author.Name}'");

            var rowsAffected = _dbConnection.Execute(@"INSERT INTO [Authors]([Name],[Surname],[Nationality])
                                        VALUES(@AuthorName,@AuthorSurname,@AuthorNationality)", new
            {
                AuthorName = Author.Name,
                AuthorSurname = Author.Surname,
                AuthorNationality =  Author.Nationality
            });

            return rowsAffected > 0;
        }

        public Author GetAuthorById(int id)
        {
            _logger.LogInfo($"Getting Author by Id {id}");


            var res = _dbConnection
                .Query<Author>("SELECT * FROM [Authors] WHERE [Id] = " + id.ToString())
                .SingleOrDefault();

            return res;

            var query = "SELECT * FROM [Authors] WHERE [Id] = @IdParameter";
            var Author = new Author();

            using (var reader = _dbConnection.ExecuteReader(query, new { IdParameter = id }))
            {
                while (reader.Read())
                {
                    Author = new Author()
                    {
                        ID = Convert.ToInt32(reader["Id"]),
                        Name = reader["Name"].ToString(),
                        Surname = reader["Surname"].ToString(),
                        Fullname = reader["Name"].ToString() + " " + reader["Surname"].ToString(),
                        Nationality = reader["Nationality"].ToString(),
                    };
                }
            }

            return Author;
        }

    }
}
