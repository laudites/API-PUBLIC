namespace API_BANCODEDADOS.Models
{
    public class FornecedorModel
    {
        public class cadastrarFornecedor
        {
            public string codFornecedor { get; set; }
            public string fornecedor { get; set; }
            public string usuario { get; set; }            
            public string cidade { get; set; }
            public string uf { get; set; }
            public int avaliacao { get; set; }
            public double distancia { get; set; }
            public string transportadora { get; set; }
            public double tempo { get; set; }
        }
    }
}
