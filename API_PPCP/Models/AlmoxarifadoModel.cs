namespace API_BANCODEDADOS.Models
{
    public class AlmoxarifadoModel
    {
        public class cadastrarEmbalagemPrimaria
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public string tipoEmbalagem { get; set; }
            public string fechamentoCarga { get; set; }
            public string protecaoIndividual { get; set; }
            public string projetadoEmpilhar { get; set; }
            public double comprimento { get; set; }
            public double largura { get; set; }
            public double altura { get; set; }
            public double qtEmbalagemPrimaria { get; set; }
            public string taraEmbalagem { get; set; }
            public double pesoBrutoEmbalagem { get; set; }
        }
        public class cadastrarEmbalagemSecundaria
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public string tipoEmbalagem { get; set; }
            public string tipoEmbalagemCaixaPalete { get; set; }
            public string nEntradaEmbalagem { get; set; }
            public double alturaGarfo { get; set; }
            public double larguraGarfo { get; set; }
            public string fechamentoCarga { get; set; }
            public string disponibilidadeEmbalagem { get; set; }
            public string projetadoParaEmpilhar { get; set; }
            public double comprimento { get; set; }
            public double altura { get; set; }
            public double largura { get; set; }
            public double qtPecasEmbalaSecundaria { get; set; }
            public double qtEmbalaPrimaria { get; set; }
            public double Peso { get; set; }
        }

        public class cadastrarArmazenagemAlmoxarife
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public bool localizacaoFixa { get; set; }
            public double comprimento { get; set; }
            public double largura { get; set; }
            public double altura { get; set; }
            public string capacidadeMax { get; set; }
            public string almoxarifado { get; set; }
            public string localizacao { get; set; }
            public string comentario { get; set; }
        }

        public class cadastrarAbastecimentoProducaoKB
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public bool abastecimentoKanban { get; set; }
            public string equipamentoNecessario { get; set; }
            public int nCartao { get; set; }
            public double qtdPecas { get; set; }
            public string localEntrega { get; set; }
            public string linha { get; set; }
            public int nCartao2 { get; set; }
            public double qtdPecas2 { get; set; }
            public string localEntrega2 { get; set; }
            public string linha2 { get; set; }
            public int nCartao3 { get; set; }
            public double qtdPecas3 { get; set; }
            public string localEntrega3 { get; set; }
            public string linha3 { get; set; }
            public int nCartao4 { get; set; }
            public double qtdPecas4 { get; set; }
            public string localEntrega4 { get; set; }
            public string linha4 { get; set; }
        }

        public class cadastrarAbastecimentoProducaoCO
        {
            public int codProduto { get; set; }
            public string usuario { get; set; }
            public bool contraOrdem { get; set; }
            public string equipamentoNecessario { get; set; }
            public string localEntrega { get; set; }
            public string comentarios { get; set; }
        }
    }
}

