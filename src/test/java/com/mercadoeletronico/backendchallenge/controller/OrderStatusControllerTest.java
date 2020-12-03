package com.mercadoeletronico.backendchallenge.controller;

import static org.junit.jupiter.api.Assertions.assertEquals;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

import com.mercadoeletronico.backendchallenge.dto.StatusRequestDTO;
import com.mercadoeletronico.backendchallenge.dto.StatusResponseDTO;
import com.mercadoeletronico.backendchallenge.service.OrderService;
import com.mercadoeletronico.backendchallenge.service.StatusService;

@RunWith(MockitoJUnitRunner.Silent.class)
public class OrderStatusControllerTest {

	@InjectMocks
	private OrderController orderController;
	
	@InjectMocks
	private OrderStatusController orderStatusController;
	
	@Mock
	private OrderService orderService;
	
	@Mock
	private StatusService statusService;
	
	private StatusRequestDTO request = new StatusRequestDTO();
	
	Long longValue = new Long(1);
	Double doubleValue = new Double(10.0);
	
	@Test
	public void changeStatusTest() {
		try {
			request.setItensAprovados(longValue);
			request.setPedido("1");
			request.setStatus("APROVADO");
			request.setValorAprovado(doubleValue);
			
			StatusResponseDTO controller = orderStatusController.changeStatus(request);
			
			assertEquals(null, controller);
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}
}
