package com.mercadoeletronico.backendchallenge.dto;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class StatusRequestDTO {
	
	private String status;
	private Long itensAprovados;
	private Double valorAprovado;
	private String pedido;

}
