using API_BANCODEDADOS.Data;
using API_BANCODEDADOS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_BANCODEDADOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Aplica a política de autenticação na controller inteira
    public class ProdutoController : Controller
    {
        [HttpGet("listaProdutosCompletos")]
        public IActionResult ListaProdutosCompletos()
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Produto produtoData = new Produto();
                var listaProdutos = produtoData.ListaProdutosCompletos();

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("listaProdutosImcompletos")]
        public IActionResult ListaProdutosImcompletos()
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Produto produtoData = new Produto();
                var listaProdutos = produtoData.ListaProdutosImcompletos();

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("cadastrarProduto")]
        public IActionResult CadastrarProduto([FromBody] ProdutosModel.cadastrarProduto produtos)
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Produto produtoData = new Produto();
                var listaProdutos = produtoData.CadastrarProduto(produtos);

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("alterarProduto")]
        public IActionResult AlterarProduto([FromBody] ProdutosModel.cadastrarProduto produtos)
        {
            try
            {
                try
                {
                    Produto produtoData1 = new Produto();
                    var linhasDeletadas = produtoData1.DeletarProduto(produtos.codProduto);
                    if (linhasDeletadas == 0)
                    {
                        return new ObjectResult(new { codigo = "Não existe" })
                        {
                            StatusCode = StatusCodes.Status404NotFound // Código HTTP 404 para recurso não encontrado
                        };
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao deletar produto para alteracao!");
                }
                Produto produtoData = new Produto();
                var listaProdutos = produtoData.CadastrarProduto(produtos);

                return Ok(listaProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("cadastrarDadosConsumo")]
        public IActionResult CadastrarDadosConsumo([FromBody] ProdutosModel.cadastrarDadosConsumo DadosConsumo)
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Produto produtoData = new Produto();
                var listaProdutos = produtoData.CadastrarDadosConsumo(DadosConsumo);

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("alterarDadosConsumo")]
        public IActionResult AlterarDadosConsumo([FromBody] ProdutosModel.cadastrarDadosConsumo produtos)
        {
            try
            {
                try
                {
                    Produto produtoData1 = new Produto();
                    var linhasDeletadas = produtoData1.DeletarDadosConsumo(produtos.codProduto);
                    if (linhasDeletadas == 0)
                    {
                        return new ObjectResult(new { codigo = "Não existe" })
                        {
                            StatusCode = StatusCodes.Status404NotFound // Código HTTP 404 para recurso não encontrado
                        };
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao deletar produto para DadosConsumo!");
                }
                Produto produtoData = new Produto();
                var listaProdutos = produtoData.CadastrarDadosConsumo(produtos);

                return Ok(listaProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("cadastrarDadosItem")]
        public IActionResult CadastrarDadosItem([FromBody] ProdutosModel.cadastrarDadosItem DadosItem)
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Produto produtoData = new Produto();
                var listaProdutos = produtoData.CadastrarDadosItem(DadosItem);

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("alterarDadosItem")]
        public IActionResult AlterarDadosItem([FromBody] ProdutosModel.cadastrarDadosItem produtos)
        {
            try
            {
                try
                {
                    Produto produtoData1 = new Produto();
                    var linhasDeletadas = produtoData1.DeletarDadosItem(produtos.codProduto);
                    if (linhasDeletadas == 0)
                    {
                        return new ObjectResult(new { codigo = "Não existe" })
                        {
                            StatusCode = StatusCodes.Status404NotFound // Código HTTP 404 para recurso não encontrado
                        };
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao deletar produto para DadosConsumo!");
                }
                Produto produtoData = new Produto();
                var listaProdutos = produtoData.CadastrarDadosItem(produtos);

                return Ok(listaProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("cadastroidentificacaoproduto")]
        public IActionResult CadastroIdentificacaoProduto([FromBody] ProdutosModel.cadastrarIdentificacaoProduto IdentificacaoProduto)
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Produto produtoData = new Produto();
                var listaProdutos = produtoData.CadastrarIdentificacaoProduto(IdentificacaoProduto);

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("alterarIdentificacaoProduto")]
        public IActionResult AlterarIdentificacaoProduto([FromBody] ProdutosModel.cadastrarIdentificacaoProduto produtos)
        {
            try
            {
                try
                {
                    Produto produtoData1 = new Produto();
                    var linhasDeletadas = produtoData1.DeletarIdentificacaoProduto(produtos.codProduto);
                    if (linhasDeletadas == 0)
                    {
                        return new ObjectResult(new { codigo = "Não existe" })
                        {
                            StatusCode = StatusCodes.Status404NotFound // Código HTTP 404 para recurso não encontrado
                        };
                    }
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao deletar produto para DadosConsumo!");
                }
                Produto produtoData = new Produto();
                var listaProdutos = produtoData.CadastrarIdentificacaoProduto(produtos);

                return Ok(listaProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("cadastroLogProduto")]
        public IActionResult CadastroLogProduto([FromBody] ProdutosModel.HistoricoAlteracoes HistoricoAlteracoes)
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Produto produtoData = new Produto();
                var listaProdutos = produtoData.CadastrarLogProdutos(HistoricoAlteracoes);

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("buscardadosconsumo")]
        public IActionResult BuscarDadosConsumo(int produto)
        {
            try
            {
                Produto produtoData = new Produto();
                var dadosConsumo = produtoData.BuscarDadosConsumo(produto);

                return Ok(dadosConsumo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("buscardadositem")]
        public IActionResult BuscarDadosItem(int produto)
        {
            try
            {
                Produto produtoData = new Produto();
                var dadosConsumo = produtoData.BuscarDadosItem(produto);

                return Ok(dadosConsumo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("buscarIdentificacaoProduto")]
        public IActionResult BuscarIdentificacaoProduto(int produto)
        {
            try
            {
                Produto produtoData = new Produto();
                var dadosConsumo = produtoData.BuscarIdentificacaoProduto(produto);

                return Ok(dadosConsumo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("buscardadosproduto")]
        public IActionResult BuscarDadosProduto(int produto)
        {
            try
            {
                Produto produtoData = new Produto();
                var dadosConsumo = produtoData.BuscarDadosProduto(produto);

                return Ok(dadosConsumo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("VerificarTabelaProduto")]
        public IActionResult VerificarTabelaProduto(int produto)
        {
            try
            {
                Produto produtoData = new Produto();
                var dadosConsumo = produtoData.VerificarTabelaProduto(produto);

                return Ok(dadosConsumo);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
