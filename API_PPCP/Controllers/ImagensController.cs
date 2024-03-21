using API_BANCODEDADOS.Data;
using API_BANCODEDADOS.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace API_BANCODEDADOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Aplica a política de autenticação na controller inteira


    public class ImagensController : Controller
    {

        [HttpGet("infoImages")]
        public IActionResult ObterInfoImagens()
        {
            try
            {
                Imagens produtoData = new Imagens();
                var infoimagens = produtoData.configImage(); // Chamada para o método configImage()

                if (infoimagens.Count == 0)
                {
                    return NotFound("Nenhuma informacao encontrada no banco de dados.");
                }

                return Ok(infoimagens);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao obter as informacoes das imagens: {ex.Message}");
            }
        }

        [HttpPost("UploadImagem")]
        public async Task<IActionResult> UploadImagem(int codProduto, string usuario, string telaReferencia)        
        {
            try
            {
                var file = Request.Form.Files[0]; // Assume que a imagem é enviada como parte do formulário

                if (file == null || file.Length == 0)
                {
                    return BadRequest("Nenhum arquivo foi enviado.");
                }
                Imagens caminhaData = new Imagens();
                var caminho = caminhaData.ObterInfo("Root_servidor");
                var pasta = caminhaData.ObterInfo("Pasta_imagens");
                var caminho_completo = caminho + pasta;


                //var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(caminho_completo, file.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                ImagensModel.CadastrarImagens imagem = new ImagensModel.CadastrarImagens
                {
                    codProduto = codProduto,
                    usuario = usuario,
                    telaReferencia = telaReferencia,
                    caminho = file.FileName
                };

                Imagens produtoData = new Imagens();
                produtoData.CadastrarImagens(imagem);

                return Ok("Imagem enviada e salva com sucesso.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao fazer o upload da imagem: {ex.Message}");
            }
        }

        [HttpGet("urlImagem")]
        public IActionResult ObterUrlImagem(int codProduto, string usuario, string telaReferencia,string caminho)
        {
            try
            {
                Imagens produtoData = new Imagens();
                var infoImagens = new ImagensModel.CadastrarImagens
                {
                    codProduto = codProduto,
                    usuario = usuario,
                    telaReferencia = telaReferencia,
                    caminho = caminho
                };

                var listaProdutos = produtoData.ImageUrl(infoImagens);

                return Ok(listaProdutos);
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
