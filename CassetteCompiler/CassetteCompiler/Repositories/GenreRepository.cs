using CassetteCompiler.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

namespace CassetteCompiler.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly IConfiguration _config;
        public GenreRepository(IConfiguration config)
        {
            _config = config;
        }
        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        public List<Genre> GetAll()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT Id, Name
                                        FROM Genre";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Genre> genres = new List<Genre>();
                        while (reader.Read())
                        {
                            genres.Add(new Genre()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Name = reader.GetString(reader.GetOrdinal("Name")),
                            });
                        }
                        return genres;
                    }
                }
            }
        }
        public void AddCassetteGenre(int cId, int gId)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO CassetteGenre (CassetteId, GenreId)
                                        VALUES @cId, @gId";
                    cmd.Parameters.AddWithValue("@cId", cId);
                    cmd.Parameters.AddWithValue("@gId", gId);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
