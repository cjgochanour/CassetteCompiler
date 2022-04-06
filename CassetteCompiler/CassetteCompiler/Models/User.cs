using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CassetteCompiler.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
