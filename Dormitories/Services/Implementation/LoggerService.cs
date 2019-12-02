using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Dormitories.Authentication;
using Dormitories.Models;

namespace Dormitories.Services.Implementation
{
    public class LoggerService : ILoggerService
    {
        private readonly IDbConnection _dbConnection;

        public LoggerService()
        {
            _dbConnection = DBAccess.GetDbConnection();
        }

        public List<Log> GetLogs()
        {
            return _dbConnection
                .Query<Log>("SELECT * FROM [Log]")
                .ToList();
        }

        public bool InsertLogWithObject(Log log)
        {
            var rowsAffected = _dbConnection.Execute(@"INSERT INTO [Log]([Type], [URL], [Username], [Object],[DateTime]) 
                                        VALUES(@TypeParameter, @URLParameter, @UsernameParameter, @ObjectParameter,GETDATE())", new
            {
                TypeParameter = log.Type,
                URLParameter = log.Url,
                UsernameParameter = log.Username,
                ObjectParameter = log.Object
            });

            return rowsAffected > 0;
        }

        public bool InsertLogWithoutObject(Log log)
        {
            var rowsAffected = _dbConnection.Execute(@"INSERT INTO [Log]([Type], [URL], [Username],[DateTime]) 
                                        VALUES(@TypeParameter, @URLParameter, @UsernameParameter,GETDATE())", new
            {
                TypeParameter = log.Type,
                URLParameter = log.Url,
                UsernameParameter = log.Username
            });

            return rowsAffected > 0;
        }
    }
}