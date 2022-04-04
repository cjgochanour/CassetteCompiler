using System.Collections.Generic;

namespace CassetteCompiler.Models
{
    public class Cassette
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Artist { get; set; }
        public string Album { get; set; }
        public int Year { get; set; }
        public string Notes { get; set; }
        public List<Genre> Genres { get; set; } 
    }
}
