using System.ComponentModel;

namespace CassetteCompiler.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [DisplayName("Genre")]
        public string Name { get; set; }
    }
}
