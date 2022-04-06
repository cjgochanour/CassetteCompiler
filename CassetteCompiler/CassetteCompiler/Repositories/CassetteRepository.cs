using CassetteCompiler.Models;
using CassetteCompiler.Models.ViewModels;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;

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
                                        FROM Cassette c";

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
                                Year = !reader.IsDBNull(reader.GetOrdinal("Year")) ? reader.GetInt32(reader.GetOrdinal("Year")) : 0,
                                Notes = !reader.IsDBNull(reader.GetOrdinal("Notes")) ? reader.GetString(reader.GetOrdinal("Notes")) : null,
                                Genres = new List<Genre>()
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

                    cmd.CommandText = @"SELECT c.Id, c.UserId, c.Artist, c.Album, c.Year, c.Notes
                                        FROM Cassette c
                                        WHERE c.UserId = @id";

                    cmd.Parameters.AddWithValue("@id", id);

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
                                Year = !reader.IsDBNull(reader.GetOrdinal("Year")) ? reader.GetInt32(reader.GetOrdinal("Year")) : 0,
                                Notes = !reader.IsDBNull(reader.GetOrdinal("Notes")) ? reader.GetString(reader.GetOrdinal("Notes")) : null,
                                Genres = new List<Genre>()
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
                    cmd.CommandText = @"SELECT c.Id AS CassetteId, c.UserId, c.Artist, c.Album, c.Year, c.Notes, g.Id AS GenreId, g.Name AS GenreName
                                        FROM Cassette c
                                        LEFT JOIN CassetteGenre cg ON cg.CassetteId = c.Id
                                        LEFT JOIN Genre g ON g.Id = cg.GenreId
                                        WHERE c.Id = @id";

                    cmd.Parameters.AddWithValue("@id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        Cassette cassette = null;
                        while (reader.Read())
                        {
                            if (cassette == null)
                            {
                                cassette = new Cassette()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("CassetteId")),
                                    Artist = reader.GetString(reader.GetOrdinal("Artist")),
                                    Album = reader.GetString(reader.GetOrdinal("Album")),
                                    Year = !reader.IsDBNull(reader.GetOrdinal("Year")) ? reader.GetInt32(reader.GetOrdinal("Year")) : 0,
                                    Notes = !reader.IsDBNull(reader.GetOrdinal("Notes")) ? reader.GetString(reader.GetOrdinal("Notes")) : null,
                                    Genres = new List<Genre>()
                                };
                            }
                            if (!reader.IsDBNull(reader.GetOrdinal("GenreId")))
                            {
                                cassette.Genres.Add(new Genre()
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("GenreId")),
                                    Name = reader.GetString(reader.GetOrdinal("GenreName")),
                                });
                            }
                        }
                        return cassette;
                    }
                }
            }
        }
        public void AddCassette(Cassette cassette)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"INSERT INTO Cassette (UserId, Artist, Album, Year, Notes)
                                        OUTPUT INSERTED.ID
                                        VALUES (@userId, @artist, @album, @year, @notes)";

                    cmd.Parameters.AddWithValue("@userId", cassette.UserId);
                    cmd.Parameters.AddWithValue("@artist", cassette.Artist);
                    cmd.Parameters.AddWithValue("@album", cassette.Album);
                    cmd.Parameters.AddWithValue("@year", cassette.Year == 0 ? DBNull.Value : cassette.Year);
                    cmd.Parameters.AddWithValue("@notes", cassette.Notes == null ? DBNull.Value : cassette.Notes);

                    int id = (int)cmd.ExecuteScalar();

                    cassette.Id = id;
                }
            }
        }
        public void DeleteCassette(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"DELETE FROM Cassette
                                        WHERE Id = @id";
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
        public void UpdateCassetteWithGenres(CassetteFormViewModel cfvm)
        {
            using (SqlConnection con = Connection)
            {
                con.Open();
                using (SqlCommand cmd = con.CreateCommand())
                {
                    cmd.CommandText += @"UPDATE Cassette
                                        SET
                                            Artist = @artist,
                                            Album = @album,
                                            Year = @year,
                                            Notes = @notes
                                        WHERE Id = @id;
                                        DELETE FROM CassetteGenre
                                        WHERE CassetteId = @id;";
                    cmd.Parameters.AddWithValue("@artist", cfvm.Cassette.Artist);
                    cmd.Parameters.AddWithValue("@album", cfvm.Cassette.Album);
                    cmd.Parameters.AddWithValue("@year", cfvm.Cassette.Year);
                    cmd.Parameters.AddWithValue("@notes", cfvm.Cassette.Notes);

                    if (cfvm.GenreIds.Count > 0)
                    {
                        int index = 0;
                        foreach (int id in cfvm.GenreIds)
                        {
                            index++;
                            cmd.CommandText += @$"INSERT INTO CassetteGenre (CassetteId, GenreId)
                                              VALUES (@id, @genreId{index});";
                            cmd.Parameters.AddWithValue(@$"@genreId{index}", id);
                        }
                    }
                    cmd.Parameters.AddWithValue("@id", cfvm.Cassette.Id);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
