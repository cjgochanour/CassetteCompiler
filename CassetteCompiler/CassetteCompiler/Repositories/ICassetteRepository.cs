using System.Collections.Generic;
using CassetteCompiler.Models;

namespace CassetteCompiler.Repositories
{
    public interface ICassetteRepository
    {
        public List<Cassette> GetAllCassettes();
        public List<Cassette> GetByUserId(int id);
        Cassette GetById(int id);
    }
}
