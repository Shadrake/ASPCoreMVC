using ASPCoreMVC.Models;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ASPCoreMVC.DAL
{
    public class AnimalDAL
    {
        private readonly string connectionString;

        public AnimalDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<Animal> GetAll()
        {
            List<Animal> animales = new List<Animal>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = @"
                    SELECT a.IdAnimal, a.NombreAnimal, a.Raza, a.RIdTipoAnimal, a.FechaNacimiento,
                           t.IdTipoAnimal, t.TipoDescripcion
                    FROM dbo.Animal a
                    LEFT JOIN dbo.TipoAnimal t ON a.RIdTipoAnimal = t.IdTipoAnimal";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Animal a = new Animal
                        {
                            IdAnimal = (int)reader["IdAnimal"],
                            NombreAnimal = reader["NombreAnimal"].ToString(),
                            Raza = reader["Raza"].ToString(),
                            RIdTipoAnimal = (int)reader["RIdTipoAnimal"],
                            FechaNacimiento = reader["FechaNacimiento"] == DBNull.Value? null
                            : DateOnly.FromDateTime((DateTime)reader["FechaNacimiento"]),
                            RIdTipoAnimalNavigation = new TipoAnimal
                            {
                                IdTipoAnimal = reader["IdTipoAnimal"] == DBNull.Value ? 0 : (int)reader["IdTipoAnimal"],
                                TipoDescripcion = reader["TipoDescripcion"] == DBNull.Value ? "" : reader["TipoDescripcion"].ToString()
                            }
                        };

                        animales.Add(a);
                    }
                }
            }

            return animales;
        }
    }
}
