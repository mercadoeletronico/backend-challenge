package com.mercadoeletronico.backendchallenge.dto;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class ItensDTO {

	private String descricao;
	private Double precoUnitario;
	private Integer qtd;
}
