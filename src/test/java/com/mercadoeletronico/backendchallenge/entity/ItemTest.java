package com.mercadoeletronico.backendchallenge.entity;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class ItemTest {

	String stringValue = "String Test";
	Long longValue = new Long(0);
	Double doubleValue = new Double(0.0);
	
	@Test
	public void testGetAndSet() {
		Item item = new Item();
		item.setId(longValue);
		item.setPedidoId(longValue);
		item.setDescricao(stringValue);
		item.setPrecoUnitario(doubleValue);
		item.setQtd(longValue);
		assertEquals(longValue, item.getId());
		assertEquals(longValue, item.getPedidoId());
		assertEquals(stringValue, item.getDescricao());
		assertEquals(doubleValue, item.getPrecoUnitario());
		assertEquals(longValue, item.getQtd());	
	}
	
	@Test
	public void testConstructor() {
		Item item = new Item(stringValue, doubleValue, longValue, longValue);
		
		assertEquals(stringValue, item.getDescricao());
		assertEquals(doubleValue, item.getPrecoUnitario());
		assertEquals(longValue, item.getQtd());
		assertEquals(longValue, item.getPedidoId());
		
	}
}
