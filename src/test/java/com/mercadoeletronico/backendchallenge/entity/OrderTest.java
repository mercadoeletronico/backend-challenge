package com.mercadoeletronico.backendchallenge.entity;

import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

public class OrderTest {

	String stringValue = "String Test";
	Long longValue = new Long(0);
	
	@Test
	public void testGetAndSet() {
		Order order = new Order();
		Item item = new Item();
		List<Item> itens = new ArrayList<Item>();
		item.setDescricao(stringValue);
		item.setId(longValue);
		item.setPedidoId(longValue);
		item.setPrecoUnitario(0.0);
		item.setQtd(longValue);
		itens.add(item);
		order.setPedido(stringValue);
		order.setItem(itens);
		assertEquals(stringValue, order.getPedido());
		assertEquals(itens, order.getItem());
	}
}
