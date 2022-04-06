using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CassetteCompiler.Models
{
    public class Cassette
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Artist { get; set; }
        [Required]
        public string Album { get; set; }
        public int Year { get; set; }
        [MaxLength(500)]
        public string Notes { get; set; }
        [DisplayName("Genres")]
        public List<Genre> Genres { get; set; } 
    }
}
