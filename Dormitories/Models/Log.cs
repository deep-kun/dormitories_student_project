using System;

namespace Dormitories.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
        public string Object { get; set; }
        public string DateTime { get; set; }
    }
}