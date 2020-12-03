package com.mercadoeletronico.backendchallenge.dto;

import static org.junit.Assert.assertEquals;

import org.junit.Test;

public class StatusRequestDTOTest {

	String stringValue = "String Test";
	Long longValue = new Long(0);
	Double doubleValue = new Double(0.0);

	@Test
	public void testGetAndSet() {
		StatusRequestDTO statusRequestDTO = new StatusRequestDTO();
		statusRequestDTO.setItensAprovados(longValue);
		statusRequestDTO.setPedido(stringValue);
		statusRequestDTO.setStatus(stringValue);
		statusRequestDTO.setValorAprovado(doubleValue);
		assertEquals(longValue, statusRequestDTO.getItensAprovados());
		assertEquals(stringValue, statusRequestDTO.getPedido());
		assertEquals(stringValue, statusRequestDTO.getStatus());
		assertEquals(doubleValue, statusRequestDTO.getValorAprovado());
	}
}
