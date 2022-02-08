namespace MercadoEletronicoApi.Application.Utils
{
    public static class Constantes
    {
        public static string InvalidOrderCode = "CODIGO_PEDIDO_INVALIDO";
        public static string UnprocessedRequest = "Não foi possível processar sua solicitação.";
    }

    public static class StatusTypes 
    {
        public static string AprovedStatus = "APROVADO";
        public static string DisapprovedStatus = "REPROVADO";
        public static string ApprovedValueLower = "APROVADO_VALOR_A_MENOR";
        public static string ApprovedValueGreater = "APROVADO_VALOR_A_MAIOR";
        public static string ApprovedQuantityLower = "APROVADO_QTD_A_MENOR";
        public static string ApprovedQuantityGreater = "APROVADO_QTD_A_MAIOR";
    }

}
