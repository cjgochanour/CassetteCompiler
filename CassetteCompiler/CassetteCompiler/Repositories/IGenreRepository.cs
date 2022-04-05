﻿using System.Collections.Generic;
using CassetteCompiler.Models;
namespace CassetteCompiler.Repositories
{
    public interface IGenreRepository
    {
        List<Genre> GetAll();
    }
}
