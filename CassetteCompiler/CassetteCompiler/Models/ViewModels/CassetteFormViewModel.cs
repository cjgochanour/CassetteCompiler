using System.Collections.Generic;
namespace CassetteCompiler.Models.ViewModels
{
    public class CassetteFormViewModel
    {
        public Cassette Cassette { get; set; }
        public List<Genre> Genres { get; set; }
        public List<int> GenreIds { get; set; }
    }
}
