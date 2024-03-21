namespace API_BANCODEDADOS.Models
{
    public class UsuarioModel
    {
        public class CreateUser
        {
            public string Usuario { get; set; }
            public string Email { get; set; }
            public string Senha { get; set; }
        }

        public class BuscarUsuario
        {
            public string Usuario { get; set; }
            public string Senha { get; set; }
        }
    }
}
