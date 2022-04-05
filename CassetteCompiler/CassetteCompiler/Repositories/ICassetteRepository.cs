using System.Collections.Generic;
using CassetteCompiler.Models;

namespace CassetteCompiler.Repositories
{
    public interface ICassetteRepository
    {
        List<Cassette> GetAllCassettes();
        List<Cassette> GetByUserId(int id);
        Cassette GetById(int id);
        void AddCassette(Cassette cassette);
        void DeleteCassette(int id);
    }
}
