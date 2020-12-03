package com.mercadoeletronico.backendchallenge.dto;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class ItensDTOTest {

	String stringValue = "String Test";
	Long longValue = new Long(0);
	Double doubleValue = new Double(0.0);
	
	@Test
	public void testGetAndSet() {
		ItensDTO itensDTO = new ItensDTO();
		itensDTO.setDescricao(stringValue);
		itensDTO.setPrecoUnitario(doubleValue);
		itensDTO.setQtd(longValue);
		assertEquals(stringValue, itensDTO.getDescricao());
		assertEquals(doubleValue, itensDTO.getPrecoUnitario());
		assertEquals(longValue, itensDTO.getQtd());	
	}
}
