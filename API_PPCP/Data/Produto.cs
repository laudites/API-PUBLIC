using System.Data.SqlClient;
using System.Collections.Generic;
using API_BANCODEDADOS.Models;

namespace API_BANCODEDADOS.Data
{
    public class Produto
    {
        string sqlConnectionString = @"Data Source = SERVIDOR; Initial Catalog = BANCODEDADOS; Persist Security Info = True; User ID = BANCODEDADOS; Password = SENHA";

        public List<Models.ProdutosModel.ListaProdutosCompletos> ListaProdutosCompletos()
        {
            var listaProdutos = new List<Models.ProdutosModel.ListaProdutosCompletos>();

            string query = "select Produto.codProduto, Produto.descricao from Produto " +
                           "left join AbastecimentoProducaoCO on Produto.codProduto = AbastecimentoProducaoCO.codProduto " +
                           "left join AbastecimentoProducaoKB on Produto.codProduto = AbastecimentoProducaoKB.codProduto " +
                           "where AbastecimentoProducaoCO.codProduto is not null or AbastecimentoProducaoKB.codProduto is not null";

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(); // Executa o comando de seleção no banco de dados

                while (reader.Read())
                {
                    // Lê os valores retornados pelo banco de dados
                    int codProduto = reader.GetInt32(0); // Supondo que o código do produto é um valor inteiro
                    string descricao = reader.GetString(1);

                    // Cria um objeto BuscarUsuario com os valores lidos e adiciona à lista
                    listaProdutos.Add(new ProdutosModel.ListaProdutosCompletos
                    {
                        codProduto = codProduto,
                        Descricao = descricao
                    });
                }

                reader.Close(); // Fecha o DataReader após ler os dados
            }

            return listaProdutos;
        }

        public List<Models.ProdutosModel.ListaProdutosImcompletos> ListaProdutosImcompletos()
        {
            var listaProdutos = new List<Models.ProdutosModel.ListaProdutosImcompletos>();

            string query = "create table #temp1 ( [codProduto] [int] NULL,	[descricao] [varchar](100) NULL,[tabela] [nvarchar](255) NULL,[prioridade] [int] NULL); \n" +
                                "with dados as ( \n" +
                                "SELECT 'AbastecimentoProducaoCO' AS Tabela, Produto.codProduto,Produto.descricao,1 AS Prioridade FROM AbastecimentoProducaoCO \n" +
                                "inner join Produto on Produto.codProduto = AbastecimentoProducaoCO.codProduto \n" +
                                "WHERE produto.codProduto like '%' \n" +
                                "UNION \n" +
                                "SELECT 'AbastecimentoProducaoKB' AS Tabela, Produto.codProduto,Produto.descricao, 2 AS Prioridade FROM AbastecimentoProducaoKB \n" +
                                "inner join Produto on Produto.codProduto = AbastecimentoProducaoKB.codProduto \n" +
                                "WHERE produto.codProduto like '%' \n" +
                                "UNION \n" +
                                "SELECT 'ArmazenagemAlmoxarife' AS Tabela, Produto.codProduto,Produto.descricao, 3 AS Prioridade FROM ArmazenagemAlmoxarife \n" +
                                "inner join Produto on Produto.codProduto = ArmazenagemAlmoxarife.codProduto \n" +
                                "WHERE Produto.codProduto like '%' \n" +
                                "UNION \n" +
                                "SELECT 'IdentificacaoProduto' AS Tabela, Produto.codProduto,Produto.descricao, 4 AS Prioridade FROM IdentificacaoProduto \n" +
                                "inner join Produto on Produto.codProduto = IdentificacaoProduto.codProduto \n" +
                                "WHERE Produto.codProduto like '%' \n" +
                                "UNION \n" +
                                "SELECT 'EmbalagemSecundaria' AS Tabela, Produto.codProduto,Produto.descricao, 5 AS Prioridade FROM EmbalagemSecundaria \n" +
                                "inner join Produto on Produto.codProduto = EmbalagemSecundaria.codProduto \n" +
                                "WHERE Produto.codProduto like '%' \n" +
                                "UNION \n" +
                                "SELECT 'EmbalagemPrimaria' AS Tabela, Produto.codProduto,Produto.descricao, 6 AS Prioridade FROM EmbalagemPrimaria \n" +
                                "inner join Produto on Produto.codProduto = EmbalagemPrimaria.codProduto \n" +
                                "WHERE Produto.codProduto like '%' \n" +
                                "UNION \n" +
                                "SELECT 'DadosItem' AS Tabela, Produto.codProduto,Produto.descricao, 7 AS Prioridade FROM DadosItem \n" +
                                "inner join Produto on Produto.codProduto = DadosItem.codProduto \n" +
                                "WHERE Produto.codProduto like '%' \n" +
                                "UNION \n" +
                                "SELECT 'DadosConsumo' AS Tabela, Produto.codProduto,Produto.descricao, 8 AS Prioridade FROM DadosConsumo \n" +
                                "inner join Produto on Produto.codProduto = DadosConsumo.codProduto \n" +
                                "WHERE Produto.codProduto like '%' \n" +
                                "UNION \n" +
                                "SELECT 'Produto' AS Tabela, codProduto, descricao, 10 AS Prioridade FROM Produto WHERE codProduto like '%') \n" +
                                "insert into #temp1  \n" +
                                "select codProduto, descricao, Tabela, Prioridade from dados ; \n" +
                                            "WITH CTE AS( \n" +
                                                "SELECT *, \n" +
                                                       "ROW_NUMBER() OVER(PARTITION BY codProduto ORDER BY prioridade asc) AS rn \n" +
                                                "FROM #temp1 ) \n" +
                                "delete FROM CTE WHERE rn > 1; \n" +
                                            "select codProduto,descricao,tabela from #temp1  where tabela not like 'AbastecimentoProducaoCO' and tabela not like 'AbastecimentoProducaoKB';";

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader(); // Executa o comando de seleção no banco de dados

                while (reader.Read())
                {
                    int codProduto = reader.GetInt32(0);
                    string descricao = reader.GetString(1);
                    string tabela = reader.GetString(2);


                    // Cria um objeto BuscarUsuario com os valores lidos e adiciona à lista
                    listaProdutos.Add(new ProdutosModel.ListaProdutosImcompletos
                    {
                        codProduto = codProduto,
                        Descricao = descricao,
                        Tabela = tabela
                    });
                }

                reader.Close(); // Fecha o DataReader após ler os dados
            }

            return listaProdutos;
        }

        public string CadastrarProduto(ProdutosModel.cadastrarProduto produto)
        {
            try
            {
                string query = "INSERT INTO Produto (codProduto, usuario, un, ncm, descricao,codFornecedor) VALUES (@codProduto, @usuario, @un, @ncm, @descricao,@codFornecedor)";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto.codProduto);
                    command.Parameters.AddWithValue("@usuario", produto.usuario);
                    command.Parameters.AddWithValue("@un", produto.un);
                    command.Parameters.AddWithValue("@ncm", produto.ncm);
                    command.Parameters.AddWithValue("@descricao", produto.descricao);
                    command.Parameters.AddWithValue("@codFornecedor", produto.codFornecedor);
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

        public int DeletarProduto(string produto)
        {
            try
            {
                string query = "delete from Produto where codProduto = @codProduto";
                int linhasDeletadas = 0;
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);
                   
                    connection.Open();
                    command.ExecuteNonQuery(); // Executa o comando de inserção no banco de dados
                }

                return linhasDeletadas;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public string CadastrarDadosConsumo(ProdutosModel.cadastrarDadosConsumo DadosConsumo)
        {
            try
            {
                string query = "INSERT INTO DadosConsumo (codProduto,usuario,sistemaOrdem,abc,xyz,pontoReposicao,estoqueSeguranca,loteEconomico,usoDiario) \n" +
                    "VALUES (@codProduto,@usuario,@sistemaOrdem,@abc,@xyz,@pontoReposicao,@estoqueSeguranca,@loteEconomico,@usoDiario)";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", DadosConsumo.codProduto);
                    command.Parameters.AddWithValue("@usuario", DadosConsumo.usuario);
                    command.Parameters.AddWithValue("@sistemaOrdem", DadosConsumo.sistemaOrdem);
                    command.Parameters.AddWithValue("@abc", DadosConsumo.abc);
                    command.Parameters.AddWithValue("@xyz", DadosConsumo.xyz);
                    command.Parameters.AddWithValue("@pontoReposicao", DadosConsumo.pontoReposicao);
                    command.Parameters.AddWithValue("@estoqueSeguranca", DadosConsumo.estoqueSeguranca);
                    command.Parameters.AddWithValue("@loteEconomico", DadosConsumo.loteEconomico);
                    command.Parameters.AddWithValue("@usoDiario", DadosConsumo.usoDiario);
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

        public int DeletarDadosConsumo(int produto)
        {
            try
            {
                string query = "delete from DadosConsumo where codProduto = @codProduto";
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
        public string CadastrarDadosItem(ProdutosModel.cadastrarDadosItem DadosItem)
        {
            try
            {
                string query = "INSERT INTO DadosItem (codProduto,usuario,familia,negocio,peso) \n" +
                    "VALUES (@codProduto,@usuario,@familia,@negocio,@peso);";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", DadosItem.codProduto);
                    command.Parameters.AddWithValue("@usuario", DadosItem.usuario);
                    command.Parameters.AddWithValue("@familia", DadosItem.familia);
                    command.Parameters.AddWithValue("@negocio", DadosItem.negocio);
                    command.Parameters.AddWithValue("@peso", DadosItem.peso);
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

        public int DeletarDadosItem(int produto)
        {
            try
            {
                string query = "delete from DadosItem where codProduto = @codProduto";
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

        public string CadastrarIdentificacaoProduto(ProdutosModel.cadastrarIdentificacaoProduto IdentificacaoProduto)
        {
            try
            {
                string query = "INSERT INTO dbo.IdentificacaoProduto (codProduto,usuario,dadosDestinatario,pesoBrutoLiq,nTotalVolumes,nPedidoCompra,codItemEletro,qtdPecasEmbalagem,descricaoBreveProduto,nFornecedorCadEletro,dataFornecimento,nLoteNotaFiscal,outros) \n" +
                    "VALUES (@codProduto,@usuario,@dadosDestinatario,@pesoBrutoLiq,@nTotalVolumes,@nPedidoCompra,@nPedidoCompra,@qtdPecasEmbalagem,@descricaoBreveProduto,@nFornecedorCadEletro,@dataFornecimento,@nLoteNotaFiscal,@outros)";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", IdentificacaoProduto.codProduto);
                    command.Parameters.AddWithValue("@usuario", IdentificacaoProduto.usuario);
                    command.Parameters.AddWithValue("@dadosDestinatario", IdentificacaoProduto.dadosDestinatario);
                    command.Parameters.AddWithValue("@pesoBrutoLiq", IdentificacaoProduto.pesoBrutoLiq);
                    command.Parameters.AddWithValue("@nTotalVolumes", IdentificacaoProduto.nTotalVolumes);
                    command.Parameters.AddWithValue("@nPedidoCompra", IdentificacaoProduto.nPedidoCompra);
                    command.Parameters.AddWithValue("@codItemEletro", IdentificacaoProduto.codItemEletro);
                    command.Parameters.AddWithValue("@qtdPecasEmbalagem", IdentificacaoProduto.qtdPecasEmbalagem);
                    command.Parameters.AddWithValue("@descricaoBreveProduto", IdentificacaoProduto.descricaoBreveProduto);
                    command.Parameters.AddWithValue("@nFornecedorCadEletro", IdentificacaoProduto.nFornecedorCadEletro);
                    command.Parameters.AddWithValue("@dataFornecimento", IdentificacaoProduto.dataFornecimento);
                    command.Parameters.AddWithValue("@nLoteNotaFiscal", IdentificacaoProduto.nLoteNotaFiscal);
                    command.Parameters.AddWithValue("@outros", IdentificacaoProduto.outros);
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

        public int DeletarIdentificacaoProduto(int produto)
        {
            try
            {
                string query = "delete from IdentificacaoProduto where codProduto = @codProduto";
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

        public string CadastrarLogProdutos(ProdutosModel.HistoricoAlteracoes log)
        {
            try
            {
                string query = "INSERT INTO HistoricoAlteracoes (codProduto,Usuario,tela) VALUES (@codProduto,@Usuario,@tela)";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", log.codProduto);
                    command.Parameters.AddWithValue("@usuario", log.usuario);
                    command.Parameters.AddWithValue("@tela", log.tela);
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

        public List<ProdutosModel.cadastrarDadosConsumo> BuscarDadosConsumo(int produto)
        {
            try
            {
                List<ProdutosModel.cadastrarDadosConsumo> dadosConsumo = new List<ProdutosModel.cadastrarDadosConsumo>();

                string query = "SELECT * FROM DadosConsumo WHERE codProduto = @codProduto";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutosModel.cadastrarDadosConsumo dados = new ProdutosModel.cadastrarDadosConsumo
                            {
                                codProduto = reader.IsDBNull(reader.GetOrdinal("codProduto")) ? 0 : reader.GetInt32(reader.GetOrdinal("codProduto")),
                                usuario = reader.IsDBNull(reader.GetOrdinal("usuario")) ? string.Empty : reader.GetString(reader.GetOrdinal("usuario")),
                                sistemaOrdem = reader.IsDBNull(reader.GetOrdinal("sistemaOrdem")) ? string.Empty : reader.GetString(reader.GetOrdinal("sistemaOrdem")),
                                abc = reader.IsDBNull(reader.GetOrdinal("abc")) ? string.Empty : reader.GetString(reader.GetOrdinal("abc")),
                                xyz = reader.IsDBNull(reader.GetOrdinal("xyz")) ? string.Empty : reader.GetString(reader.GetOrdinal("xyz")),
                                pontoReposicao = reader.IsDBNull(reader.GetOrdinal("pontoReposicao")) ? string.Empty : reader.GetString(reader.GetOrdinal("pontoReposicao")),
                                estoqueSeguranca = reader.IsDBNull(reader.GetOrdinal("estoqueSeguranca")) ? string.Empty : reader.GetString(reader.GetOrdinal("estoqueSeguranca")),
                                loteEconomico = reader.IsDBNull(reader.GetOrdinal("loteEconomico")) ? string.Empty : reader.GetString(reader.GetOrdinal("loteEconomico")),
                                usoDiario = reader.IsDBNull(reader.GetOrdinal("usoDiario")) ? false : reader.GetBoolean(reader.GetOrdinal("usoDiario"))
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


        public List<ProdutosModel.cadastrarDadosItem> BuscarDadosItem(int produto)
        {
            try
            {
                List<ProdutosModel.cadastrarDadosItem> dadosConsumo = new List<ProdutosModel.cadastrarDadosItem>();

                string query = "SELECT * FROM DadosItem WHERE codProduto = @codProduto";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutosModel.cadastrarDadosItem dados = new ProdutosModel.cadastrarDadosItem
                            {
                                codProduto = reader.GetInt32(reader.GetOrdinal("codProduto")),
                                usuario = reader.GetString(reader.GetOrdinal("usuario")),
                                familia = reader.GetString(reader.GetOrdinal("familia")),
                                negocio = reader.GetString(reader.GetOrdinal("negocio")),
                                peso = reader.GetDouble(reader.GetOrdinal("peso"))
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

        public List<ProdutosModel.cadastrarIdentificacaoProduto> BuscarIdentificacaoProduto(int produto)
        {
            try
            {
                List<ProdutosModel.cadastrarIdentificacaoProduto> dadosConsumo = new List<ProdutosModel.cadastrarIdentificacaoProduto>();

                string query = "SELECT * FROM IdentificacaoProduto WHERE codProduto = @codProduto";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutosModel.cadastrarIdentificacaoProduto dados = new ProdutosModel.cadastrarIdentificacaoProduto
                            {
                                codProduto = reader.GetInt32(reader.GetOrdinal("codProduto")),
                                usuario = reader.GetString(reader.GetOrdinal("usuario")),
                                dadosDestinatario = reader.GetBoolean(reader.GetOrdinal("dadosDestinatario")),
                                pesoBrutoLiq = reader.GetBoolean(reader.GetOrdinal("pesoBrutoLiq")),
                                nTotalVolumes = reader.GetBoolean(reader.GetOrdinal("nTotalVolumes")),
                                nPedidoCompra = reader.GetBoolean(reader.GetOrdinal("nPedidoCompra")),
                                codItemEletro = reader.GetBoolean(reader.GetOrdinal("codItemEletro")),
                                qtdPecasEmbalagem = reader.GetBoolean(reader.GetOrdinal("qtdPecasEmbalagem")),
                                descricaoBreveProduto = reader.GetBoolean(reader.GetOrdinal("descricaoBreveProduto")),
                                nFornecedorCadEletro = reader.GetBoolean(reader.GetOrdinal("nFornecedorCadEletro")),
                                dataFornecimento = reader.GetBoolean(reader.GetOrdinal("dataFornecimento")),
                                nLoteNotaFiscal = reader.GetBoolean(reader.GetOrdinal("nLoteNotaFiscal")),
                                outros = reader.GetString(reader.GetOrdinal("outros"))
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

        public List<ProdutosModel.BuscarDadosProduto> BuscarDadosProduto(int produto)
        {
            try
            {
                List<ProdutosModel.BuscarDadosProduto> dadosConsumo = new List<ProdutosModel.BuscarDadosProduto>();

                string query = "SELECT * FROM produto WHERE codProduto = @codProduto";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutosModel.BuscarDadosProduto dados = new ProdutosModel.BuscarDadosProduto
                            {
                                codProduto = reader.GetInt32(reader.GetOrdinal("codProduto")),
                                usuario = reader.GetString(reader.GetOrdinal("usuario")),
                                un = reader.GetString(reader.GetOrdinal("un")),
                                ncm = reader.GetString(reader.GetOrdinal("ncm")),
                                descricao = reader.GetString(reader.GetOrdinal("descricao")),
                                dataCriacao = reader.GetDateTime(reader.GetOrdinal("dataCriacao")),
                                codFornecedor = reader.GetString(reader.GetOrdinal("codFornecedor"))
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

        public List<ProdutosModel.VerificarTabelaProduto> VerificarTabelaProduto(int produto)
        {
            try
            {
                List<ProdutosModel.VerificarTabelaProduto> dadosConsumo = new List<ProdutosModel.VerificarTabelaProduto>();

                string query = "SELECT 1 as ID,'Produto' AS Tabela, \n" +
                                    "CASE WHEN EXISTS(SELECT 1 FROM Produto WHERE codProduto = @codProduto) THEN 'Sim' ELSE 'Não' END AS TemCodigo \n" +
                                    "UNION ALL \n" +
                                    "SELECT 2 as ID,'DadosConsumo' AS Tabela, \n" +
                                    "CASE WHEN EXISTS(SELECT 1 FROM DadosConsumo WHERE codProduto = @codProduto) THEN 'Sim' ELSE 'Não' END AS TemCodigo \n" +
                                    "UNION ALL \n" +
                                    "SELECT 3 as ID,'DadosItem' AS Tabela, \n" +
                                    "CASE WHEN EXISTS(SELECT 1 FROM DadosItem WHERE codProduto = @codProduto) THEN 'Sim' ELSE 'Não' END AS TemCodigo \n" +
                                    "UNION ALL \n" +
                                    "SELECT 4 as ID,'EmbalagemPrimaria' AS Tabela, \n" +
                                    "CASE WHEN EXISTS(SELECT 1 FROM EmbalagemPrimaria WHERE codProduto = @codProduto) THEN 'Sim' ELSE 'Não' END AS TemCodigo \n" +
                                    "UNION ALL \n" +
                                    "SELECT 5 as ID,'EmbalagemSecundaria' AS Tabela, \n" +
                                    "CASE WHEN EXISTS(SELECT 1 FROM EmbalagemSecundaria WHERE codProduto = @codProduto) THEN 'Sim' ELSE 'Não' END AS TemCodigo \n" +
                                    "UNION ALL \n" +
                                    "SELECT 6 as ID,'IdentificacaoProduto' AS Tabela, \n" +
                                    "CASE WHEN EXISTS(SELECT 1 FROM IdentificacaoProduto WHERE codProduto = @codProduto) THEN 'Sim' ELSE 'Não' END AS TemCodigo \n" +
                                    "UNION ALL \n" +
                                    "SELECT 7 as ID,'ArmazenagemAlmoxarife' AS Tabela, \n" +
                                    "CASE WHEN EXISTS(SELECT 1 FROM ArmazenagemAlmoxarife WHERE codProduto = @codProduto) THEN 'Sim' ELSE 'Não' END AS TemCodigo \n" +
                                    "UNION ALL \n" +
                                    "SELECT 8 as ID,'AbastecimentoProducaoCO' AS Tabela, \n" +
                                    "CASE WHEN EXISTS(SELECT 1 FROM AbastecimentoProducaoCO WHERE codProduto = @codProduto) THEN 'Sim' ELSE 'Não' END AS TemCodigo \n" +
                                    "UNION ALL \n" +
                                    "SELECT 9 as ID,'AbastecimentoProducaoKB' AS Tabela, \n" +
                                    "CASE WHEN EXISTS(SELECT 1 FROM AbastecimentoProducaoKB WHERE codProduto = @codProduto) THEN 'Sim' ELSE 'Não' END AS TemCodigo \n" +
                                    "UNION ALL \n" +
                                    "SELECT 10 as ID,'HistoricoAlteracoes' AS Tabela, \n" +
                                    "CASE WHEN EXISTS(SELECT 1 FROM HistoricoAlteracoes WHERE codProduto = @codProduto) THEN 'Sim' ELSE 'Não' END AS TemCodigo \n" +
                                    "UNION ALL \n" +
                                    "SELECT 11 as ID,'Imagens' AS Tabela, \n" +
                                    "CASE WHEN EXISTS(SELECT 1 FROM Imagens WHERE codProduto = @codProduto) THEN 'Sim' ELSE 'Não' END AS TemCodigo ";

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@codProduto", produto);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProdutosModel.VerificarTabelaProduto dados = new ProdutosModel.VerificarTabelaProduto
                            {
                                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                                Tabela = reader.GetString(reader.GetOrdinal("Tabela")),
                                TemCodigo = reader.GetString(reader.GetOrdinal("TemCodigo")),                               
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
