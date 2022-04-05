using System.Collections.Generic;
using System.ComponentModel;

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
        [DisplayName("Genres")]
        public List<Genre> Genres { get; set; } 
    }
}
