using API_BANCODEDADOS.Data;
using API_BANCODEDADOS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_BANCODEDADOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Aplica a política de autenticação na controller inteira
    public class AlmoxarifadoController : Controller
    {
        [HttpPost("cadastroEmbalagemPrimaria")]
        public IActionResult CadastroEmbalagemPrimaria([FromBody] AlmoxarifadoModel.cadastrarEmbalagemPrimaria EmbalagemPrimaria)
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Almoxarifado produtoData = new Almoxarifado();
                var listaProdutos = produtoData.CadastrarEmbalagemPrimaria(EmbalagemPrimaria);

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("alterarEmbalagemPrimaria")]
        public IActionResult AlterarEmbalagemPrimaria([FromBody] AlmoxarifadoModel.cadastrarEmbalagemPrimaria produtos)
        {
            try
            {
                try
                {
                    Almoxarifado produtoData1 = new Almoxarifado();
                    var linhasDeletadas = produtoData1.DeletarEmbalagemPrimaria(produtos.codProduto);
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
                Almoxarifado produtoData = new Almoxarifado();
                var listaProdutos = produtoData.CadastrarEmbalagemPrimaria(produtos);

                return Ok(listaProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPost("cadastroEmbalagemSecundaria")]
        public IActionResult CadastroEmbalagemSecundaria([FromBody] AlmoxarifadoModel.cadastrarEmbalagemSecundaria EmbalagemSecundaria)
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Almoxarifado produtoData = new Almoxarifado();
                var listaProdutos = produtoData.CadastrarEmbalagemSecundaria(EmbalagemSecundaria);

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("alterarEmbalagemSecundaria")]
        public IActionResult AlterarEmbalagemSecundaria([FromBody] AlmoxarifadoModel.cadastrarEmbalagemSecundaria produtos)
        {
            try
            {
                try
                {
                    Almoxarifado produtoData1 = new Almoxarifado();
                    var linhasDeletadas = produtoData1.DeletarEmbalagemSecundaria(produtos.codProduto);
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
                Almoxarifado produtoData = new Almoxarifado();
                var listaProdutos = produtoData.CadastrarEmbalagemSecundaria(produtos);

                return Ok(listaProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("cadastroArmazenagemAlmoxarife")]
        public IActionResult CadastroArmazenagemAlmoxarife([FromBody] AlmoxarifadoModel.cadastrarArmazenagemAlmoxarife ArmazenagemAlmoxarife)
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Almoxarifado produtoData = new Almoxarifado();
                var listaProdutos = produtoData.CadastrarArmazenagemAlmoxarife(ArmazenagemAlmoxarife);

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("alterarArmazenagemAlmoxarife")]
        public IActionResult AlterarArmazenagemAlmoxarife([FromBody] AlmoxarifadoModel.cadastrarArmazenagemAlmoxarife produtos)
        {
            try
            {
                try
                {
                    Almoxarifado produtoData1 = new Almoxarifado();
                    var linhasDeletadas = produtoData1.DeletarArmazenagemAlmoxarife(produtos.codProduto);
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
                Almoxarifado produtoData = new Almoxarifado();
                var listaProdutos = produtoData.CadastrarArmazenagemAlmoxarife(produtos);

                return Ok(listaProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("cadastroAbastecimentoProducaoKB")]
        public IActionResult CadastroAbastecimentoProducaoKB([FromBody] AlmoxarifadoModel.cadastrarAbastecimentoProducaoKB AbastecimentoProducaoKB)
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Almoxarifado produtoData = new Almoxarifado();
                var listaProdutos = produtoData.CadastrarAbastecimentoProducaoKB(AbastecimentoProducaoKB);

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("alterarAbastecimentoProducaoKB")]
        public IActionResult AlterarAbastecimentoProducaoKB([FromBody] AlmoxarifadoModel.cadastrarAbastecimentoProducaoKB produtos)
        {
            try
            {
                try
                {
                    Almoxarifado produtoData1 = new Almoxarifado();
                    var linhasDeletadas = produtoData1.DeletarAbastecimentoProducaoKB(produtos.codProduto);
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
                Almoxarifado produtoData = new Almoxarifado();
                var listaProdutos = produtoData.CadastrarAbastecimentoProducaoKB(produtos);

                return Ok(listaProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("cadastroAbastecimentoProducaoCO")]
        public IActionResult CadastroAbastecimentoProducaoCO([FromBody] AlmoxarifadoModel.cadastrarAbastecimentoProducaoCO AbastecimentoProducaoCO)
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Almoxarifado produtoData = new Almoxarifado();
                var listaProdutos = produtoData.CadastrarAbastecimentoProducaoCO(AbastecimentoProducaoCO);

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("alterarAbastecimentoProducaoCO")]
        public IActionResult AlterarAbastecimentoProducaoCO([FromBody] AlmoxarifadoModel.cadastrarAbastecimentoProducaoCO produtos)
        {
            try
            {
                try
                {
                    Almoxarifado produtoData1 = new Almoxarifado();
                    var linhasDeletadas = produtoData1.DeletarAbastecimentoProducaoCO(produtos.codProduto);
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
                Almoxarifado produtoData = new Almoxarifado();
                var listaProdutos = produtoData.CadastrarAbastecimentoProducaoCO(produtos);

                return Ok(listaProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("buscarEmbalagemPrimaria")]
        public IActionResult BuscarEmbalagemPrimaria(int produto)
        {
            try
            {
                Almoxarifado produtoData = new Almoxarifado();
                var dadosConsumo = produtoData.BuscarEmbalagemPrimaria(produto);

                return Ok(dadosConsumo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("buscarEmbalagemSecundaria")]
        public IActionResult BuscarEmbalagemSecundaria(int produto)
        {
            try
            {
                Almoxarifado produtoData = new Almoxarifado();
                var dadosConsumo = produtoData.BuscarEmbalagemSecundaria(produto);

                return Ok(dadosConsumo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("buscarArmazenagemAlmoxarife")]
        public IActionResult BuscarArmazenagemAlmoxarife(int produto)
        {
            try
            {
                Almoxarifado produtoData = new Almoxarifado();
                var dadosConsumo = produtoData.BuscarArmazenagemAlmoxarife(produto);

                return Ok(dadosConsumo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("buscarAbastecimentoProducaoCO")]
        public IActionResult BuscarAbastecimentoProducaoCO(int produto)
        {
            try
            {
                Almoxarifado produtoData = new Almoxarifado();
                var dadosConsumo = produtoData.BuscarAbastecimentoProducaoCO(produto);

                return Ok(dadosConsumo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("buscarAbastecimentoProducaoKB")]
        public IActionResult BuscarAbastecimentoProducaoKB(int produto)
        {
            try
            {
                Almoxarifado produtoData = new Almoxarifado();
                var dadosConsumo = produtoData.BuscarAbastecimentoProducaoKB(produto);

                return Ok(dadosConsumo);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
