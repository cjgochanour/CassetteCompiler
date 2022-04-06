using System.Collections.Generic;
using CassetteCompiler.Models;
using CassetteCompiler.Models.ViewModels;

namespace CassetteCompiler.Repositories
{
    public interface ICassetteRepository
    {
        List<Cassette> GetAllCassettes();
        List<Cassette> GetByUserId(int id);
        Cassette GetById(int id);
        void AddCassette(Cassette cassette);
        void DeleteCassette(int id);
        void UpdateCassetteWithGenres(CassetteFormViewModel cfvm);
    }
}
