package com.mercadoeletronico.backendchallenge.dto;

import java.util.List;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class StatusResponseDTO {

	private String pedido;
	private List<String> status;
}
