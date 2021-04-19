using System.ComponentModel;

namespace MercadoEletronico.Challenge.Domain.Models.Enums
{
    public enum StatusAprovacao
    {
        [Description("CODIGO_PEDIDO_INVALIDO")]
        PedidoInvalido,

        [Description("REPROVADO")]
        Reprovado,

        [Description("APROVADO")]
        Aprovado,

        [Description("APROVADO_VALOR_A_MENOR")]
        AprovadoValorMenor,

        [Description("APROVADO_VALOR_A_MAIOR")]
        AprovadoValorMaior,

        [Description("APROVADO_QTD_A_MENOR")]
        AprovadoQuantidadeMenor,

        [Description("APROVADO_QTD_A_MAIOR")]
        AprovadoQuantidadeMaior,
    }
}
