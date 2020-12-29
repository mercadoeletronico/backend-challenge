package me.backendchallenge.domain.model;

public enum StatusEnum {
	APROVADO("APROVADO"), REPROVADO("REPROVADO"), APROVADO_VALOR_A_MENOR("APROVADO_VALOR_A_MENOR"),
	APROVADO_VALOR_A_MAIOR("APROVADO_VALOR_A_MAIOR"), APROVADO_QTD_A_MAIOR("APROVADO_QTD_A_MAIOR"),
	APROVADO_QTD_A_MENOR("APROVADO_QTD_A_MENOR"), CODIGO_PEDIDO_INVALIDO("CODIGO_PEDIDO_INVALIDO"),
	STATUS_INVALIDO("STATUS_INVALIDO");

	private final String status;

	StatusEnum(String status) {
		this.status = status;
	}

	public boolean equals(StatusEnum otherStatus) {
		if (this.status.equals(otherStatus.status))
			return true;

		return false;
	}

	public String toString() {
		return this.status;
	}
}
