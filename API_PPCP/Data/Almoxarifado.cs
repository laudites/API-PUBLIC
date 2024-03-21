using API_BANCODEDADOS.Models;
using System.Data.SqlClient;

namespace API_BANCODEDADOS.Data
{
    public class Almoxarifado
    {
        string sqlConnectionString = @"Data Source = SERVIDOR; Initial Catalog = BANCODEDADOS; Persist Security Info = True; User ID = BANCODEDADOS; Password = SENHA";
        public string CadastrarEmbalagemPrimaria(AlmoxarifadoModel.cadastrarEmbalagemPrimaria EmbalagemPrimaria)
        {
            try
            {
                string query = "INSERT INTO EmbalagemPrimaria(codProduto,usuario,tipoEmbalagem,fechamentoCarga,protecaoIndividual,projetadoEmpilhar,comprimento,largura,altura,qtEmbalagemPrimaria,taraEmbalagem,pesoBrutoEmbalagem) \n" +
                                "VALUES (@codProduto,@usuario,@tipoEmbalagem,@fechamentoCarga,@protecaoIndividual,@projetadoEmpilhar,@comprimento,@largura,@altura,@qtEmbalagemPrimaria,@taraEmbalagem,@pesoBrutoEmbalagem)";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", EmbalagemPrimaria.codProduto);
                    command.Parameters.AddWithValue("@usuario", EmbalagemPrimaria.usuario);
                    command.Parameters.AddWithValue("@tipoEmbalagem", EmbalagemPrimaria.tipoEmbalagem);
                    command.Parameters.AddWithValue("@fechamentoCarga", EmbalagemPrimaria.fechamentoCarga);
                    command.Parameters.AddWithValue("@protecaoIndividual", EmbalagemPrimaria.protecaoIndividual);
                    command.Parameters.AddWithValue("@projetadoEmpilhar", EmbalagemPrimaria.projetadoEmpilhar);
                    command.Parameters.AddWithValue("@comprimento", EmbalagemPrimaria.comprimento);
                    command.Parameters.AddWithValue("@largura", EmbalagemPrimaria.largura);
                    command.Parameters.AddWithValue("@altura", EmbalagemPrimaria.altura);
                    command.Parameters.AddWithValue("@qtEmbalagemPrimaria", EmbalagemPrimaria.qtEmbalagemPrimaria);
                    command.Parameters.AddWithValue("@taraEmbalagem", EmbalagemPrimaria.taraEmbalagem);
                    command.Parameters.AddWithValue("@pesoBrutoEmbalagem", EmbalagemPrimaria.pesoBrutoEmbalagem);
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

        public int DeletarEmbalagemPrimaria(int produto)
        {
            try
            {
                string query = "delete from EmbalagemPrimaria where codProduto = @codProduto";
                int linhasDeletadas = 0;
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);

                    connection.Open();
                    linhasDeletadas = command.ExecuteNonQuery();
                }

                return linhasDeletadas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string CadastrarEmbalagemSecundaria(AlmoxarifadoModel.cadastrarEmbalagemSecundaria EmbalagemSecundaria)
        {
            try
            {
                string query = "INSERT INTO dbo.EmbalagemSecundaria (codProduto,usuario,tipoEmbalagem,tipoEmbalagemCaixaPalete,nEntradaEmbalagem,alturaGarfo,larguraGarfo,fechamentoCarga,disponibilidadeEmbalagem,projetadoParaEmpilhar,comprimento,altura,largura,qtPecasEmbalaSecundaria,qtEmbalaPrimaria,Peso) \n" +
                    "VALUES (@codProduto,@usuario,@tipoEmbalagem,@tipoEmbalagemCaixaPalete,@nEntradaEmbalagem,@alturaGarfo,@larguraGarfo,@fechamentoCarga,@disponibilidadeEmbalagem,@projetadoParaEmpilhar,@comprimento,@altura,@largura,@qtPecasEmbalaSecundaria,@qtEmbalaPrimaria,@Peso)";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", EmbalagemSecundaria.codProduto);
                    command.Parameters.AddWithValue("@usuario", EmbalagemSecundaria.usuario);
                    command.Parameters.AddWithValue("@tipoEmbalagem", EmbalagemSecundaria.tipoEmbalagem);
                    command.Parameters.AddWithValue("@tipoEmbalagemCaixaPalete", EmbalagemSecundaria.tipoEmbalagemCaixaPalete);
                    command.Parameters.AddWithValue("@nEntradaEmbalagem", EmbalagemSecundaria.nEntradaEmbalagem);
                    command.Parameters.AddWithValue("@alturaGarfo", EmbalagemSecundaria.alturaGarfo);
                    command.Parameters.AddWithValue("@larguraGarfo", EmbalagemSecundaria.larguraGarfo);
                    command.Parameters.AddWithValue("@fechamentoCarga", EmbalagemSecundaria.fechamentoCarga);
                    command.Parameters.AddWithValue("@disponibilidadeEmbalagem", EmbalagemSecundaria.disponibilidadeEmbalagem);
                    command.Parameters.AddWithValue("@projetadoParaEmpilhar", EmbalagemSecundaria.projetadoParaEmpilhar);
                    command.Parameters.AddWithValue("@comprimento", EmbalagemSecundaria.comprimento);
                    command.Parameters.AddWithValue("@altura", EmbalagemSecundaria.altura);
                    command.Parameters.AddWithValue("@largura", EmbalagemSecundaria.largura);
                    command.Parameters.AddWithValue("@qtPecasEmbalaSecundaria", EmbalagemSecundaria.qtPecasEmbalaSecundaria);
                    command.Parameters.AddWithValue("@qtEmbalaPrimaria", EmbalagemSecundaria.qtEmbalaPrimaria);
                    command.Parameters.AddWithValue("@Peso", EmbalagemSecundaria.Peso);
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

        public int DeletarEmbalagemSecundaria(int produto)
        {
            try
            {
                string query = "delete from EmbalagemSecundaria where codProduto = @codProduto";
                int linhasDeletadas = 0;
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);

                    connection.Open();
                    linhasDeletadas = command.ExecuteNonQuery();
                }

                return linhasDeletadas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string CadastrarArmazenagemAlmoxarife(AlmoxarifadoModel.cadastrarArmazenagemAlmoxarife ArmazenagemAlmoxarife)
        {
            try
            {
                string query = "INSERT INTO ArmazenagemAlmoxarife(codProduto,usuario,localizacaoFixa,comprimento,largura,altura,capacidadeMax,almoxarifado,localizacao,comentario) \n" +
                    "VALUES (@codProduto,@usuario,@localizacaoFixa,@comprimento,@largura,@altura,@capacidadeMax,@almoxarifado,@localizacao,@comentario)";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", ArmazenagemAlmoxarife.codProduto);
                    command.Parameters.AddWithValue("@usuario", ArmazenagemAlmoxarife.usuario);
                    command.Parameters.AddWithValue("@localizacaoFixa", ArmazenagemAlmoxarife.localizacaoFixa);
                    command.Parameters.AddWithValue("@comprimento", ArmazenagemAlmoxarife.comprimento);
                    command.Parameters.AddWithValue("@largura", ArmazenagemAlmoxarife.largura);
                    command.Parameters.AddWithValue("@altura", ArmazenagemAlmoxarife.altura);
                    command.Parameters.AddWithValue("@capacidadeMax", ArmazenagemAlmoxarife.capacidadeMax);
                    command.Parameters.AddWithValue("@almoxarifado", ArmazenagemAlmoxarife.almoxarifado);
                    command.Parameters.AddWithValue("@localizacao", ArmazenagemAlmoxarife.localizacao);
                    command.Parameters.AddWithValue("@comentario", ArmazenagemAlmoxarife.comentario);
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

        public int DeletarArmazenagemAlmoxarife(int produto)
        {
            try
            {
                string query = "delete from ArmazenagemAlmoxarife where codProduto = @codProduto";
                int linhasDeletadas = 0;
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);

                    connection.Open();
                    linhasDeletadas = command.ExecuteNonQuery();
                }

                return linhasDeletadas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string CadastrarAbastecimentoProducaoKB(AlmoxarifadoModel.cadastrarAbastecimentoProducaoKB AbastecimentoProducaoKB)
        {
            try
            {
                string query = "INSERT INTO dbo.AbastecimentoProducaoKB (codProduto,usuario,abastecimentoKanban,equipamentoNecessario,nCartao,qtdPecas,localEntrega,linha,nCartao2,qtdPecas2,localEntrega2,linha2,nCartao3,qtdPecas3,localEntrega3,linha3,nCartao4,qtdPecas4,localEntrega4,linha4) \n" +
                    "VALUES (@codProduto,@usuario,@abastecimentoKanban,@equipamentoNecessario,@nCartao,@qtdPecas,@localEntrega,@linha,@nCartao2,@qtdPecas2,@localEntrega2,@linha2,@nCartao3,@qtdPecas3,@localEntrega3,@linha3,@nCartao4,@qtdPecas4,@localEntrega4,@linha4)";
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", AbastecimentoProducaoKB.codProduto);
                    command.Parameters.AddWithValue("@usuario", AbastecimentoProducaoKB.usuario);
                    command.Parameters.AddWithValue("@abastecimentoKanban", AbastecimentoProducaoKB.abastecimentoKanban);
                    command.Parameters.AddWithValue("@equipamentoNecessario", AbastecimentoProducaoKB.equipamentoNecessario);
                    command.Parameters.AddWithValue("@nCartao", AbastecimentoProducaoKB.nCartao);
                    command.Parameters.AddWithValue("@qtdPecas", AbastecimentoProducaoKB.qtdPecas);
                    command.Parameters.AddWithValue("@localEntrega", AbastecimentoProducaoKB.localEntrega);
                    command.Parameters.AddWithValue("@linha", AbastecimentoProducaoKB.linha);
                    command.Parameters.AddWithValue("@nCartao2", AbastecimentoProducaoKB.nCartao2);
                    command.Parameters.AddWithValue("@qtdPecas2", AbastecimentoProducaoKB.qtdPecas2);
                    command.Parameters.AddWithValue("@localEntrega2", AbastecimentoProducaoKB.localEntrega2);
                    command.Parameters.AddWithValue("@linha2", AbastecimentoProducaoKB.linha2);
                    command.Parameters.AddWithValue("@nCartao3", AbastecimentoProducaoKB.nCartao3);
                    command.Parameters.AddWithValue("@qtdPecas3", AbastecimentoProducaoKB.qtdPecas3);
                    command.Parameters.AddWithValue("@localEntrega3", AbastecimentoProducaoKB.localEntrega3);
                    command.Parameters.AddWithValue("@linha3", AbastecimentoProducaoKB.linha3);
                    command.Parameters.AddWithValue("@nCartao4", AbastecimentoProducaoKB.nCartao4);
                    command.Parameters.AddWithValue("@qtdPecas4", AbastecimentoProducaoKB.qtdPecas4);
                    command.Parameters.AddWithValue("@localEntrega4", AbastecimentoProducaoKB.localEntrega4);
                    command.Parameters.AddWithValue("@linha4", AbastecimentoProducaoKB.linha4);

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

        public int DeletarAbastecimentoProducaoKB(int produto)
        {
            try
            {
                string query = "delete from AbastecimentoProducaoKB where codProduto = @codProduto";
                int linhasDeletadas = 0;
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);

                    connection.Open();
                    linhasDeletadas = command.ExecuteNonQuery();
                }

                return linhasDeletadas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public string CadastrarAbastecimentoProducaoCO(AlmoxarifadoModel.cadastrarAbastecimentoProducaoCO AbastecimentoProducaoCO)
        {
            try
            {
                string query = "INSERT INTO dbo.AbastecimentoProducaoCO (codProduto,usuario,contraOrdem,equipamentoNecessario,localEntrega,comentarios) \n" +
                    "VALUES (@codProduto,@usuario,@contraOrdem,@equipamentoNecessario,@localEntrega,@comentarios)";
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", AbastecimentoProducaoCO.codProduto);
                    command.Parameters.AddWithValue("@usuario", AbastecimentoProducaoCO.usuario);
                    command.Parameters.AddWithValue("@contraOrdem", AbastecimentoProducaoCO.contraOrdem);
                    command.Parameters.AddWithValue("@equipamentoNecessario", AbastecimentoProducaoCO.equipamentoNecessario);
                    command.Parameters.AddWithValue("@localEntrega", AbastecimentoProducaoCO.localEntrega);
                    command.Parameters.AddWithValue("@comentarios", AbastecimentoProducaoCO.comentarios);


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

        public int DeletarAbastecimentoProducaoCO(int produto)
        {
            try
            {
                string query = "delete from AbastecimentoProducaoCO where codProduto = @codProduto";
                int linhasDeletadas = 0;
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);

                    connection.Open();
                    linhasDeletadas = command.ExecuteNonQuery();
                }

                return linhasDeletadas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public List<AlmoxarifadoModel.cadastrarEmbalagemPrimaria> BuscarEmbalagemPrimaria(int EmbalagemPrimaria)
        {
            try
            {
                List<AlmoxarifadoModel.cadastrarEmbalagemPrimaria> dadosConsumo = new List<AlmoxarifadoModel.cadastrarEmbalagemPrimaria>();

                string query = "SELECT * FROM EmbalagemPrimaria WHERE codProduto = @codProduto";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", EmbalagemPrimaria);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AlmoxarifadoModel.cadastrarEmbalagemPrimaria dados = new AlmoxarifadoModel.cadastrarEmbalagemPrimaria
                            {
                                codProduto = reader.GetInt32(reader.GetOrdinal("codProduto")),
                                usuario = reader.GetString(reader.GetOrdinal("usuario")),
                                tipoEmbalagem = reader.GetString(reader.GetOrdinal("tipoEmbalagem")), // Aqui você está mapeando o campo "familia" para "tipoEmbalagem"
                                fechamentoCarga = reader.GetString(reader.GetOrdinal("fechamentoCarga")), // Aqui você está mapeando o campo "negocio" para "fechamentoCarga"
                                protecaoIndividual = reader.GetString(reader.GetOrdinal("protecaoIndividual")), // Como não tem um campo "protecaoIndividual", substitua pelo campo "xyz"
                                projetadoEmpilhar = reader.GetString(reader.GetOrdinal("projetadoEmpilhar")), // Aqui você está mapeando o campo "pontoReposicao" para "projetadoEmpilhar"
                                comprimento = reader.GetDouble(reader.GetOrdinal("comprimento")), // Você precisará adicionar um campo "comprimento" no seu modelo
                                largura = reader.GetDouble(reader.GetOrdinal("largura")), // Você precisará adicionar um campo "largura" no seu modelo
                                altura = reader.GetDouble(reader.GetOrdinal("altura")), // Você precisará adicionar um campo "altura" no seu modelo
                                qtEmbalagemPrimaria = reader.GetDouble(reader.GetOrdinal("qtEmbalagemPrimaria")), // Você precisará adicionar um campo "qtEmbalagemPrimaria" no seu modelo
                                taraEmbalagem = reader.GetString(reader.GetOrdinal("taraEmbalagem")), // Você precisará adicionar um campo "taraEmbalagem" no seu modelo
                                pesoBrutoEmbalagem = reader.GetDouble(reader.GetOrdinal("pesoBrutoEmbalagem")) // Você precisará adicionar um campo "pesoBrutoEmbalagem" no seu modelo

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

        public List<AlmoxarifadoModel.cadastrarEmbalagemSecundaria> BuscarEmbalagemSecundaria(int produto)
        {
            try
            {
                List<AlmoxarifadoModel.cadastrarEmbalagemSecundaria> dadosConsumo = new List<AlmoxarifadoModel.cadastrarEmbalagemSecundaria>();

                string query = "SELECT * FROM EmbalagemSecundaria WHERE codProduto = @codProduto";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AlmoxarifadoModel.cadastrarEmbalagemSecundaria dados = new AlmoxarifadoModel.cadastrarEmbalagemSecundaria
                            {
                                codProduto = reader.GetInt32(reader.GetOrdinal("codProduto")),
                                usuario = reader.GetString(reader.GetOrdinal("usuario")),
                                tipoEmbalagem = reader.GetString(reader.GetOrdinal("tipoEmbalagem")),
                                tipoEmbalagemCaixaPalete = reader.GetString(reader.GetOrdinal("tipoEmbalagemCaixaPalete")),
                                nEntradaEmbalagem = reader.GetString(reader.GetOrdinal("nEntradaEmbalagem")),
                                alturaGarfo = reader.GetDouble(reader.GetOrdinal("alturaGarfo")),
                                larguraGarfo = reader.GetDouble(reader.GetOrdinal("larguraGarfo")),
                                fechamentoCarga = reader.GetString(reader.GetOrdinal("fechamentoCarga")),
                                disponibilidadeEmbalagem = reader.GetString(reader.GetOrdinal("disponibilidadeEmbalagem")),
                                projetadoParaEmpilhar = reader.GetString(reader.GetOrdinal("projetadoParaEmpilhar")),
                                comprimento = reader.GetDouble(reader.GetOrdinal("comprimento")),
                                altura = reader.GetDouble(reader.GetOrdinal("altura")),
                                largura = reader.GetDouble(reader.GetOrdinal("largura")),

                                qtPecasEmbalaSecundaria = reader.GetDouble(reader.GetOrdinal("qtPecasEmbalaSecundaria")),
                                qtEmbalaPrimaria = reader.GetDouble(reader.GetOrdinal("qtEmbalaPrimaria")),
                                Peso = reader.GetDouble(reader.GetOrdinal("Peso"))

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

        public List<AlmoxarifadoModel.cadastrarArmazenagemAlmoxarife> BuscarArmazenagemAlmoxarife(int produto)
        {
            try
            {
                List<AlmoxarifadoModel.cadastrarArmazenagemAlmoxarife> dadosConsumo = new List<AlmoxarifadoModel.cadastrarArmazenagemAlmoxarife>();

                string query = "SELECT * FROM ArmazenagemAlmoxarife WHERE codProduto = @codProduto";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AlmoxarifadoModel.cadastrarArmazenagemAlmoxarife dados = new AlmoxarifadoModel.cadastrarArmazenagemAlmoxarife
                            {
                                codProduto = reader.GetInt32(reader.GetOrdinal("codProduto")),
                                usuario = reader.GetString(reader.GetOrdinal("usuario")),
                                localizacaoFixa = reader.GetBoolean(reader.GetOrdinal("localizacaoFixa")),
                                comprimento = reader.GetDouble(reader.GetOrdinal("comprimento")),
                                largura = reader.GetDouble(reader.GetOrdinal("largura")),
                                altura = reader.GetDouble(reader.GetOrdinal("altura")),
                                capacidadeMax = reader.GetString(reader.GetOrdinal("capacidadeMax")),
                                almoxarifado = reader.GetString(reader.GetOrdinal("almoxarifado")),
                                localizacao = reader.GetString(reader.GetOrdinal("localizacao")),
                                comentario = reader.GetString(reader.GetOrdinal("comentario"))

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

        public List<AlmoxarifadoModel.cadastrarAbastecimentoProducaoKB> BuscarAbastecimentoProducaoKB(int produto)
        {
            try
            {
                List<AlmoxarifadoModel.cadastrarAbastecimentoProducaoKB> dadosConsumo = new List<AlmoxarifadoModel.cadastrarAbastecimentoProducaoKB>();

                string query = "SELECT * FROM AbastecimentoProducaoKB WHERE codProduto = @codProduto";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AlmoxarifadoModel.cadastrarAbastecimentoProducaoKB dados = new AlmoxarifadoModel.cadastrarAbastecimentoProducaoKB
                            {
                                codProduto = reader.GetInt32(reader.GetOrdinal("codProduto")),
                                usuario = reader.GetString(reader.GetOrdinal("usuario")),
                                abastecimentoKanban = reader.GetBoolean(reader.GetOrdinal("abastecimentoKanban")),
                                equipamentoNecessario = reader.GetString(reader.GetOrdinal("equipamentoNecessario")),
                                nCartao = reader.GetInt32(reader.GetOrdinal("nCartao")),
                                qtdPecas = reader.GetDouble(reader.GetOrdinal("qtdPecas")),
                                localEntrega = reader.GetString(reader.GetOrdinal("localEntrega")),
                                linha = reader.GetString(reader.GetOrdinal("linha")),
                                nCartao2 = reader.GetInt32(reader.GetOrdinal("nCartao2")),
                                qtdPecas2 = reader.GetDouble(reader.GetOrdinal("qtdPecas2")),
                                localEntrega2 = reader.GetString(reader.GetOrdinal("localEntrega2")),
                                linha2 = reader.GetString(reader.GetOrdinal("linha2")),
                                nCartao3 = reader.GetInt32(reader.GetOrdinal("nCartao3")),
                                qtdPecas3 = reader.GetDouble(reader.GetOrdinal("qtdPecas3")),
                                localEntrega3 = reader.GetString(reader.GetOrdinal("localEntrega3")),
                                linha3 = reader.GetString(reader.GetOrdinal("linha3")),
                                nCartao4 = reader.GetInt32(reader.GetOrdinal("nCartao4")),
                                qtdPecas4 = reader.GetDouble(reader.GetOrdinal("qtdPecas4")),
                                localEntrega4 = reader.GetString(reader.GetOrdinal("localEntrega4")),
                                linha4 = reader.GetString(reader.GetOrdinal("linha4"))

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

        public List<AlmoxarifadoModel.cadastrarAbastecimentoProducaoCO> BuscarAbastecimentoProducaoCO(int produto)
        {
            try
            {
                List<AlmoxarifadoModel.cadastrarAbastecimentoProducaoCO> dadosConsumo = new List<AlmoxarifadoModel.cadastrarAbastecimentoProducaoCO>();

                string query = "SELECT * FROM AbastecimentoProducaoCO WHERE codProduto = @codProduto";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            AlmoxarifadoModel.cadastrarAbastecimentoProducaoCO dados = new AlmoxarifadoModel.cadastrarAbastecimentoProducaoCO
                            {
                                codProduto = reader.GetInt32(reader.GetOrdinal("codProduto")),
                                usuario = reader.GetString(reader.GetOrdinal("usuario")),
                                contraOrdem = reader.GetBoolean(reader.GetOrdinal("contraOrdem")),
                                equipamentoNecessario = reader.GetString(reader.GetOrdinal("equipamentoNecessario")),
                                localEntrega = reader.GetString(reader.GetOrdinal("localEntrega")),
                                comentarios = reader.GetString(reader.GetOrdinal("comentarios"))

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
    }
}
