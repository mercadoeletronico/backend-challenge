package com.mercadoeletronico.backendchallenge.enums;

public enum StatusEnum {

	CODIGO_PEDIDO_INVALIDO(1, "CODIGO_PEDIDO_INVALIDO"), 
	REPROVADO(2, "REPROVADO"), 
	APROVADO(3, "APROVADO"), 
	APROVADO_VALOR_A_MENOR(4, "APROVADO_VALOR_A_MENOR"),
	APROVADO_QTD_A_MENOR(5, "APROVADO_QTD_A_MENOR"), 
	APROVADO_VALOR_A_MAIOR(6, "APROVADO_VALOR_A_MAIOR"), 
	APROVADO_QTD_A_MAIOR(7, "APROVADO_QTD_A_MAIOR");

	private Integer cdStatus = null;
	private String dsStatus = null;

	StatusEnum(Integer cdStatus, String dsStatus) {
		this.cdStatus = cdStatus;
		this.dsStatus = dsStatus;
	}

	public Integer getCdStatus() {
		return cdStatus;
	}

	public String getDsStatus() {
		return dsStatus;
	}
}
