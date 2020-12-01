package com.mercadoeletronico.backendchallenge.dto;

import java.util.List;

import com.mercadoeletronico.backendchallenge.entity.Itens;

import lombok.Getter;
import lombok.Setter;

@Getter
@Setter
public class OrderDTO {

	private String pedido;
	private List<Itens> itens;
}
