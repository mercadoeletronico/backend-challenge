using System.ComponentModel;

namespace Core.Enums
{
    public enum EnumStatusPedido
    {
        [Description("APROVADO")]
        APROVADO,
        [Description("APROVADO_VALOR_A_MENOR")]
        APROVADO_VALOR_A_MENOR,
        [Description("APROVADO_VALOR_A_MAIOR")]
        APROVADO_VALOR_A_MAIOR,
        [Description("APROVADO_QTD_A_MAIOR")]
        APROVADO_QTD_A_MAIOR,
        [Description("APROVADO_QTD_A_MENOR")]
        APROVADO_QTD_A_MENOR,
        [Description("REPROVADO")]
        REPROVADO,
        [Description("CODIGO_PEDIDO_INVALIDO")]
        CODIGO_PEDIDO_INVALIDO
    }
}