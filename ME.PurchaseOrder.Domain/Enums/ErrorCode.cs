using System.ComponentModel;

namespace ME.PurchaseOrder.Domain.Enums
{
    public enum ErrorCode
    {
        [Description("REPROVADO")]
        Disapproved = 1,

        [Description("APROVADO")]
        Approved = 2,

        [Description("APROVADO_VALOR_A_MENOR")]
        LowerPriceApproved = 3,

        [Description("APROVADO_VALOR_A_MAIOR")]
        GreaterPriceApproved = 4,

        [Description("APROVADO_QTD_A_MENOR")]
        LowerQuantityApproved = 5,

        [Description("APROVADO_QTD_A_MAIOR")]
        GreaterQuantityApproved = 6,

        [Description("CODIGO_PEDIDO_INVALIDO")]
        NumberCodeOrderInvalid = 7,

        [Description("REQUISICAO_INVALIDA")]
        InvalidRequest = 8,

        [Description("FALHA_NO_SISTEMA")]
        CriticalError = 9,
    }
}