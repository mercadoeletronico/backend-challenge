package br.com.luizbsilva.api.util;

import lombok.Getter;

public enum StatusEnum {
    APPROVED("APROVADO"),
    APPROVED_MINOR_PRICE("APROVADO_VALOR_A_MENOR"),
    APPROVED_GREATER_PRICE("APROVADO_VALOR_A_MAIOR"),
    APPROVED_MINOR_QUANTITY("APROVADO_QTD_A_MENOR"),
    APPROVED_GREATER_QUANTITY("APROVADO_QTD_A_MAIOR"),
    DISAPPROVED("REPROVADO"),
    INVALID_ORDER_NUMBER("CODIGO_PEDIDO_INVALIDO");

    @Getter
    private String message;

    StatusEnum(String message) {
        this.message = message;
    }

}
