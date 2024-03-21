namespace API_BANCODEDADOS.Models
{
    public class ProdutosModel
    {
        public class ListaProdutosCompletos
        {
            public int codProduto { get; set; }
            public string Descricao { get; set; }
        }
        public class ListaProdutosImcompletos
        {
            public int codProduto { get; set; }
            public string Descricao { get; set; }
            public string Tabela { get; set; }
        }
        public class cadastrarProduto
        {
            public string codProduto { get; set; }
            public string usuario { get; set; }
            public string un { get; set; }
            public string ncm { get; set; }
            public string descricao { get; set; }
            public string codFornecedor { get; set; }
        }
        public class cadastrarDadosConsumo
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public string sistemaOrdem { get; set; }
            public string abc { get; set; }
            public string xyz { get; set; }
            public string pontoReposicao { get; set; }
            public string estoqueSeguranca { get; set; }
            public string loteEconomico { get; set; }
            public bool usoDiario { get; set; }
        }

        public class cadastrarDadosItem
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public string familia { get; set; }
            public string negocio { get; set; }
            public double peso { get; set; }
        }

        public class cadastrarIdentificacaoProduto
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public bool dadosDestinatario { get; set; }
            public bool pesoBrutoLiq { get; set; }
            public bool nTotalVolumes { get; set; }
            public bool nPedidoCompra { get; set; }
            public bool codItemEletro { get; set; }
            public bool qtdPecasEmbalagem { get; set; }
            public bool descricaoBreveProduto { get; set; }
            public bool nFornecedorCadEletro { get; set; }
            public bool dataFornecimento { get; set; }
            public bool nLoteNotaFiscal { get; set; }
            public string outros { get; set; }
        }

        public class HistoricoAlteracoes
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public int tela { get; set; }
        }

        public class BuscarDadosProduto
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public string un { get; set; }
            public string ncm { get; set; }
            public string descricao { get; set; }
            public DateTime dataCriacao { get; set; }
            public string codFornecedor { get; set; }
        }

        public class VerificarTabelaProduto
        {
            public int ID { get; set; }
            public string Tabela { get; set; }
            public string TemCodigo { get; set; }
    
        }
    }
}
