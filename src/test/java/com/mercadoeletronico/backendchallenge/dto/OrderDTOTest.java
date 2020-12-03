package com.mercadoeletronico.backendchallenge.dto;

import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

import com.mercadoeletronico.backendchallenge.entity.Item;

public class OrderDTOTest {
	String stringValue = "String Test";
	Long longValue = new Long(0);
	
	@Test
	public void testGetAndSet() {
		OrderDTO orderDTO = new OrderDTO();
		Item item = new Item();
		List<Item> itens = new ArrayList<Item>();
		item.setDescricao(stringValue);
		item.setId(longValue);
		item.setPedidoId(longValue);
		item.setPrecoUnitario(0.0);
		item.setQtd(longValue);
		itens.add(item);
		orderDTO.setPedido(stringValue);
		orderDTO.setItens(itens);
		assertEquals(stringValue, orderDTO.getPedido());
		assertEquals(itens, orderDTO.getItens());
	}
	
}
