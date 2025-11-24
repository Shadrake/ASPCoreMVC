using ASPCoreMVC.Models;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace ASPCoreMVC.DAL
{
    public class TipoAnimalDAL
    {
        private readonly string connectionString;

        public TipoAnimalDAL(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public List<TipoAnimal> GetAll()
        {
            List<TipoAnimal> tipos = new List<TipoAnimal>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sql = "SELECT IdTipoAnimal, TipoDescripcion FROM dbo.TipoAnimal";

                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tipos.Add(new TipoAnimal
                        {
                            IdTipoAnimal = (int)reader["IdTipoAnimal"],
                            TipoDescripcion = reader["TipoDescripcion"].ToString()
                        });
                    }
                }
            }

            return tipos;
        }
    }
}
