namespace API_BANCODEDADOS.Models
{
    public class ImagensModel
    {
        public class CadastrarImagens
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public string telaReferencia { get; set; }
            public string caminho { get; set; }
        }

        
        public class ImagemInfo
        {
            public string Nome { get; set; }
            public string Caminho { get; set; }
        }

        public class obterImagens
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public string telaReferencia { get; set; }
        }

    }
}
