package mercado.eletronico.backendchallenge.domain;

public enum Status {
    APROVADO ("APROVADO"),
    APROVADO_VALOR_A_MENOR ("APROVADO_VALOR_A_MENOR") ,
    APROVADO_VALOR_A_MAIOR ("APROVADO_VALOR_A_MAIOR"),
    APROVADO_QTD_A_MAIOR ("APROVADO_QTD_A_MAIOR"),
    APROVADO_QTD_A_MENOR ("APROVADO_QTD_A_MENOR"),
    REPROVADO ("REPROVADO"),
    CODIGO_PEDIDO_INVALIDO ("CODIGO_PEDIDO_INVALIDO"),
    CODIGO_PEDIDO_JA_EXISTE ("CODIGO_PEDIDO_JA_EXISTE"),
    ITENS_INVALIDOS ("ITENS_INVALIDOS"),
    STATUS_INVALIDO("STATUS_INVALIDO"),
    PEDIDO_DELETADO("PEDIDO_DELETADO");

    private final String name;

    Status(String status) {
        name = status;
    }
    public boolean equalsName(String otherName) {
        return name.equals(otherName);
    }

    public String toString() {
        return this.name;
    }
}
