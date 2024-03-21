using API_BANCODEDADOS.Models;
using System.Data.SqlClient;

namespace API_BANCODEDADOS.Data
{
    public class Imagens
    {
        string sqlConnectionString = @"Data Source = SERVIDOR; Initial Catalog = BANCODEDADOS; Persist Security Info = True; User ID = BANCODEDADOS; Password = SENHA";

        public string CadastrarImagens(ImagensModel.CadastrarImagens imagem)
        {
            try
            {
                string query = "INSERT INTO Imagens(codProduto, usuario,telaReferencia, caminho) " +
                    "VALUES (@codProduto, @usuario,@telaReferencia, @caminho)";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", imagem.codProduto);
                    command.Parameters.AddWithValue("@usuario", imagem.usuario);
                    command.Parameters.AddWithValue("@telaReferencia", imagem.telaReferencia);
                    command.Parameters.AddWithValue("@caminho", imagem.caminho);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                return "Cadastrado com sucesso";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<ImagensModel.ImagemInfo> configImage()
        {
            List<ImagensModel.ImagemInfo> resultList = new List<ImagensModel.ImagemInfo>();

            try
            {
                string query = "SELECT nome, caminho FROM ConfigServer";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ImagensModel.ImagemInfo imagem = new ImagensModel.ImagemInfo
                        {
                            Nome = reader["nome"].ToString(),
                            Caminho = reader["caminho"].ToString()
                        };

                        resultList.Add(imagem);
                    }

                    reader.Close();
                }

                return resultList;
            }
            catch (Exception ex)
            {
                return new List<ImagensModel.ImagemInfo>();
            }
        }

        public List<ImagensModel.CadastrarImagens> ImageUrl(ImagensModel.CadastrarImagens infoImagens)
        {
            List<ImagensModel.CadastrarImagens> resultList = new List<ImagensModel.CadastrarImagens>();

            try
            {
                string query = "SELECT codProduto, usuario, telaReferencia, caminho FROM Imagens " +
                               "WHERE codProduto like @codProduto AND usuario like @usuario AND telaReferencia like @telaReferencia and caminho like @caminho";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", infoImagens.codProduto);
                    command.Parameters.AddWithValue("@usuario", infoImagens.usuario);
                    command.Parameters.AddWithValue("@telaReferencia", infoImagens.telaReferencia);
                    command.Parameters.AddWithValue("@caminho", infoImagens.caminho);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ImagensModel.CadastrarImagens imageInfo = new ImagensModel.CadastrarImagens
                            {
                                codProduto = reader.GetInt32(reader.GetOrdinal("codProduto")),
                                usuario = reader["usuario"].ToString(),
                                telaReferencia = reader["telaReferencia"].ToString(),
                                caminho = reader["caminho"].ToString()                            
                        };
                            resultList.Add(imageInfo);
                        }
                    }
                }

                return resultList;
            }
            catch (Exception ex)
            {
                // Tratar a exceção de maneira apropriada (por exemplo, logar o erro)
                return null;
            }
        }

        public string ObterRootServidor()
        {
            try
            {
                string query = "SELECT caminho FROM ConfigServer WHERE nome = 'Root_servidor'";
                string rootServidor = null; // Variável para armazenar o valor obtido da consulta

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();

                    // Execute a consulta e obtenha o resultado usando ExecuteScalar
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        rootServidor = result.ToString(); // Converte o resultado para string
                    }
                }

                return rootServidor; // Retorna o valor obtido da consulta
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public string ObterInfo(string info)
        {
            try
            {
                string query = "SELECT caminho FROM ConfigServer WHERE nome = @nome";
                string rootServidor = null; // Variável para armazenar o valor obtido da consulta

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@nome", info);
                    connection.Open();

                    // Execute a consulta e obtenha o resultado usando ExecuteScalar
                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        rootServidor = result.ToString(); // Converte o resultado para string
                    }
                }

                return rootServidor; // Retorna o valor obtido da consulta
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
