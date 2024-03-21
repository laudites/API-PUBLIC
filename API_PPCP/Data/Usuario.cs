using API_BANCODEDADOS.Models;
using System.Data.SqlClient;

namespace API_BANCODEDADOS.Data
{
    public class Usuario
    {

        string sqlConnectionString = @"Data Source = SERVIDOR; Initial Catalog = BANCODEDADOS; Persist Security Info = True; User ID = BANCODEDADOS; Password = SENHA";

        public bool UsuarioExiste(string usuario)
        {
            string query = "SELECT COUNT(*) FROM [BANCODEDADOS].[dbo].[Usuario] WHERE Usuario = @usuario";

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);

                connection.Open();

                int count = (int)command.ExecuteScalar();

                return count > 0; // Retorna true se o usuário existe, false se não existe
            }
        }

        public string CreateUser(string usuario, string email, string senha)
        {
            string query = "insert into usuario (usuario,email, senha) values (@usuario,@email,@senha)";

            // Verifica se o usuário já existe
            if (UsuarioExiste(usuario))
            {              
                return "Usuario existente!";
            }

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@senha", senha);

                connection.Open();
                command.ExecuteNonQuery(); // Executa o comando de inserção no banco de dados                
            }
            return "Usuario criado!";
        }

        public string BuscarUsuario(string usuario)
        {
            string query = "SELECT [senha] FROM [BANCODEDADOS].[dbo].[Usuario] WHERE Usuario = @usuario";
            string senha = null;

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@usuario", usuario);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        senha = reader["senha"].ToString();
                    }
                }
            }

            return senha;
        }

    }
}
