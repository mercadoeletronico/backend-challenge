package com.mercadoeletronico.backendchallenge.dto;

import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;

public class StatusResponseDTOTest {
	
	String stringValue = "String Test";

	@Test
	public void testGetAndSet() {
		StatusResponseDTO statusResponseDTO = new StatusResponseDTO();
		List<String> statusList = new ArrayList<String>();
		statusList.add(stringValue);
		statusResponseDTO.setPedido(stringValue);
		statusResponseDTO.setStatus(statusList);
		assertEquals(stringValue, statusResponseDTO.getPedido());
		assertEquals(statusList, statusResponseDTO.getStatus());
	}

}
