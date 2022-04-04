using CassetteCompiler.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CassetteCompiler.Repositories
{
    public class CassetteRepository : ICassetteRepository
    {
        private readonly IConfiguration _config;
        public CassetteRepository(IConfiguration config)
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
        public List<Cassette> GetAllCassettes()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Id, c.UserId, c.Artist, c.Album, c.Year, c.Notes
                                        FROM Cassette c
                                        LEFT JOIN Genre g ON g.CassetteId = c.Id
                                        LEFT JOIN User u ON u.Id = c.UserId";

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Cassette> cassettes = new List<Cassette>();
                        while (reader.Read())
                        {
                            cassettes.Add(new Cassette()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                UserId = reader.GetInt32(reader.GetOrdinal("UserId")),
                                Artist = reader.GetString(reader.GetOrdinal("Artist")),
                                Album = reader.GetString(reader.GetOrdinal("Album")),
                                Year = reader.GetInt32(reader.GetOrdinal("Year")),
                                Notes = reader.GetString(reader.GetOrdinal("Notes"))
                            });
                        }
                        return cassettes;
                    }
                }
            }
        }
        public List<Cassette> GetByUserId(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Id, c.Artist, c.Album, c.Year, c.Notes
                                        FROM Cassette c
                                        LEFT JOIN Genre g ON g.CassetteId = c.Id
                                        LEFT JOIN User u ON u.Id = c.UserId
                                        WHERE u.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        List<Cassette> cassettes = new List<Cassette>();
                        while (reader.Read())
                        {
                            cassettes.Add(new Cassette()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Artist = reader.GetString(reader.GetOrdinal("Artist")),
                                Album = reader.GetString(reader.GetOrdinal("Album")),
                                Year = reader.GetInt32(reader.GetOrdinal("Year")),
                                Notes = reader.GetString(reader.GetOrdinal("Notes"))
                            });
                        }
                        return cassettes;
                    }
                }
            }
        }
        public Cassette GetById(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"SELECT c.Id, c.UserId, c.Artist, c.Album, c.Year, c.Notes
                                        FROM Cassette c
                                        LEFT JOIN Genre g ON g.CassetteId = c.Id
                                        LEFT JOIN User u ON u.Id = c.UserId
                                        WHERE c.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Cassette()
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                Artist = reader.GetString(reader.GetOrdinal("Artist")),
                                Album = reader.GetString(reader.GetOrdinal("Album")),
                                Year = reader.GetInt32(reader.GetOrdinal("Year")),
                                Notes = reader.GetString(reader.GetOrdinal("Notes"))
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }
    }
}
