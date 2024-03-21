using API_BANCODEDADOS.Data;
using API_BANCODEDADOS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API_BANCODEDADOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Aplica a política de autenticação na controller inteira
    public class FornecedorController : Controller
    {
        [HttpPost("cadastrarFornecedor")]
        public IActionResult ListaProdutosCompletos([FromBody] FornecedorModel.cadastrarFornecedor fornecedor)
        {
            try
            {
                // Instancia a classe Produto para obter a lista de produtos completos
                Fornecedor produtoData = new Fornecedor();
                var listaProdutos = produtoData.CadastrarFornecedor(fornecedor);

                return Ok(listaProdutos); // Retorna a lista de produtos completos na resposta

            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet("buscardadosfornecedor")]
        public IActionResult BuscarDadosFornecedor(string codFornecedor)
        {
            try
            {
                Fornecedor produtoData = new Fornecedor();
                var dadosConsumo = produtoData.BuscarDadosFornecedor(codFornecedor);

                return Ok(dadosConsumo);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("alterardadosfornecedor")]
        public IActionResult AlterarProduto([FromBody] FornecedorModel.cadastrarFornecedor produtos)
        {
            try
            {
                try
                {
                    Fornecedor produtoData1 = new Fornecedor();
                    produtoData1.DeletarDadosFornecedor(produtos.codFornecedor);
                }
                catch (Exception ex)
                {
                    return BadRequest("Erro ao deletar produto para alteracao!");
                }
                Fornecedor produtoData = new Fornecedor();
                var listaProdutos = produtoData.CadastrarFornecedor(produtos);

                return Ok(listaProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
