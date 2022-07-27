using System.Data.SqlClient;
using izaque_d3_avaliacao.Interfaces;
using izaque_d3_avaliacao.Models;

namespace izaque_d3_avaliacao.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private readonly string ConexionString = "Data source=DESKTOP-U6ETJHJ\\SQLEXPRESS; initial catalog=izaque_d3_avaliacao; user id=sa; pwd=123456;";

        public void Create(User user)
        {

            using (SqlConnection con = new(ConexionString))
            {
                string queryInsert = "INSERT INTO Users (IdUser, Name, Email, Password) VALUES (@IdUser, @Name, @Email, @Password)";

                using (SqlCommand cmd = new(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@IdUser", user.IdUser);
                    cmd.Parameters.AddWithValue("@Name", user.Name);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
