using System.ComponentModel;

namespace MercadoEletronico.Domain.Enums
{
    public enum StatusAprovacao
    {
        [Description("APROVADO")]
        Aprovado,
        [Description("APROVADO_QTD_A_MAIOR")]
        AprovadoQuantidadeMaior,
        [Description("APROVADO_QTD_A_MENOR")]
        AprovadoQuantidadeMenor,
        [Description("APROVADO_VALOR_A_MAIOR")]
        AprovadoValorMaior,
        [Description("APROVADO_VALOR_A_MENOR")]
        AprovadoValorMenor,
        [Description("CODIGO_PEDIDO_INVALIDO")]
        PedidoInvalido,
        [Description("REPROVADO")]
        Reprovado
    }
}