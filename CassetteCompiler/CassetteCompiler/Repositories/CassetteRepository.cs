using CassetteCompiler.Models;
using System.Collections.Generic;

namespace CassetteCompiler.Repositories
{
    public class CassetteRepository
    {
        public List<Cassette> GetAllCassettes();
        public Cassette GetByUserId(int id);
    }
}
