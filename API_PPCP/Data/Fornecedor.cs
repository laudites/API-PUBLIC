using API_BANCODEDADOS.Models;
using System.Data.SqlClient;

namespace API_BANCODEDADOS.Data
{
    public class Fornecedor
    {
        string sqlConnectionString = @"Data Source = SERVIDOR; Initial Catalog = BANCODEDADOS; Persist Security Info = True; User ID = BANCODEDADOS; Password = SENHA";
        public string CadastrarFornecedor(FornecedorModel.cadastrarFornecedor fornecedor)
        {
            try
            {
                string query = "INSERT INTO DadosFornecedor(codFornecedor,fornecedor,usuario,cidade,uf,avaliacao,distancia,transportadora,tempo) \n" +
                    "Values (@codFornecedor,@fornecedor,@usuario,@cidade,@uf,@avaliacao,@distancia,@transportadora,@tempo)";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codFornecedor", fornecedor.codFornecedor);
                    command.Parameters.AddWithValue("@usuario", fornecedor.usuario);
                    command.Parameters.AddWithValue("@fornecedor", fornecedor.fornecedor);
                    command.Parameters.AddWithValue("@cidade", fornecedor.cidade);
                    command.Parameters.AddWithValue("@uf", fornecedor.uf);
                    command.Parameters.AddWithValue("@avaliacao", fornecedor.avaliacao);
                    command.Parameters.AddWithValue("@distancia", fornecedor.distancia);
                    command.Parameters.AddWithValue("@transportadora", fornecedor.transportadora);
                    command.Parameters.AddWithValue("@tempo", fornecedor.tempo);
                    connection.Open();
                    command.ExecuteNonQuery(); // Executa o comando de inserção no banco de dados
                }

                return "Cadastrado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<FornecedorModel.cadastrarFornecedor> BuscarDadosFornecedor(string produto)
        {
            try
            {
                List<FornecedorModel.cadastrarFornecedor> dadosConsumo = new List<FornecedorModel.cadastrarFornecedor>();

                string query = "SELECT * FROM DadosFornecedor WHERE codFornecedor like @codFornecedor";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codFornecedor", produto);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            FornecedorModel.cadastrarFornecedor dados = new FornecedorModel.cadastrarFornecedor
                            {
                                codFornecedor = reader["codFornecedor"] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("codFornecedor")),
                                fornecedor = reader["fornecedor"] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("fornecedor")),
                                usuario = reader["usuario"] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("usuario")),
                                cidade = reader["cidade"] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("cidade")),
                                uf = reader["uf"] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("uf")),
                                avaliacao = reader["avaliacao"] == DBNull.Value ? 0 : reader.GetInt32(reader.GetOrdinal("avaliacao")),
                                distancia = reader["distancia"] == DBNull.Value ? 0.0 : reader.GetDouble(reader.GetOrdinal("distancia")),
                                transportadora = reader["transportadora"] == DBNull.Value ? null : reader.GetString(reader.GetOrdinal("transportadora")),
                                tempo = reader["tempo"] == DBNull.Value ? 0.0 : reader.GetDouble(reader.GetOrdinal("tempo"))
                            };
                            dadosConsumo.Add(dados);
                        }
                    }
                }

                return dadosConsumo;
            }
            catch (Exception ex)
            {
                // Aqui seria melhor retornar um objeto que represente um erro ao invés de uma string
                throw new Exception("Erro ao buscar dados: " + ex.Message);
            }
        }

        public string DeletarDadosFornecedor(string produto)
        {
            try
            {
                string query = "delete from DadosFornecedor where codFornecedor = @codFornecedor";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codFornecedor", produto);

                    connection.Open();
                    command.ExecuteNonQuery(); // Executa o comando de inserção no banco de dados
                }

                return "Deletado com sucesso!";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


    }
}
