
using API_BANCODEDADOS.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;


namespace API_BANCODEDADOS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] // Aplica a política de autenticação na controller inteira
    public class AuthController : Controller
    {        
        //chave secreta: projeto + desenvolvedor empresa + ano de desenvolvimento
        string key = "CHAVEKEY";
        private readonly JwtService _jwtService;

        Data.Usuario usuarioData = new Data.Usuario();

        public AuthController(JwtService jwtService)
        {
            _jwtService = jwtService;
        }

        static string EncryptString(string plainText, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = new byte[16];

            using (AesManaged aes = new AesManaged())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;

                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }

                        byte[] encryptedBytes = msEncrypt.ToArray();
                        return Convert.ToBase64String(encryptedBytes);
                    }
                }
            }
        }

        static string DecryptString(string cipherText, string key)
        {
            byte[] keyBytes = Encoding.UTF8.GetBytes(key);
            byte[] ivBytes = new byte[16];
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (AesManaged aes = new AesManaged())
            {
                aes.Key = keyBytes;
                aes.IV = ivBytes;

                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        [AllowAnonymous]
        [HttpPost("createuser")]
        public IActionResult Dados_usuario([FromBody] Models.UsuarioModel.CreateUser user)
        {
            string encryptedText = EncryptString(user.Senha, key);

            try
            {
                string criarUsuario = usuarioData.CreateUser(user.Usuario, user.Email, encryptedText);
                //return Ok(new {"usuario":  criarUsuario });
                return Ok(new { Usuario = criarUsuario });
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Models.UsuarioModel.BuscarUsuario buscarUsuario)
        {         
            string senhaUsuario = usuarioData.BuscarUsuario(buscarUsuario.Usuario);
            if (senhaUsuario == null || senhaUsuario == "")
            {
                {
                    return Unauthorized(new {usuario = "Usuario inexistente!"});
                }
            }
            if (buscarUsuario.Usuario != null)
            {
                // Descriptografe a senha criptografada fornecida
                string decryptedPassword = DecryptString(senhaUsuario, key);

                // Compare a senha descriptografada com a senha correta do usuário
                if (decryptedPassword == buscarUsuario.Senha)
                {
                    // Senha válida, gere o token JWT
                    var token = _jwtService.GenerateToken(buscarUsuario.Usuario);
                    return Ok(new { Token = token });
                }
            }

            // Caso o nome de usuário ou senha sejam inválidos
            return Unauthorized(new { senha = "Senha errada!" });
        }

   
    }
}
