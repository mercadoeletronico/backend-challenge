package com.mercadoeletronico.backendchallenge.service;

import static org.mockito.Mockito.when;

import java.util.ArrayList;
import java.util.List;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.junit.MockitoJUnitRunner;

import com.mercadoeletronico.backendchallenge.dto.StatusRequestDTO;
import com.mercadoeletronico.backendchallenge.dto.StatusResponseDTO;
import com.mercadoeletronico.backendchallenge.enums.StatusEnum;
import com.mercadoeletronico.backendchallenge.repository.ItemRepository;
import com.mercadoeletronico.backendchallenge.repository.OrderRepository;


@RunWith(MockitoJUnitRunner.class)
public class StatusServiceTest {
	
	String stringValue = "String Test";
	Long longValue = new Long(0);
	Double doubleValue = new Double(0.0);
	
	@InjectMocks
	private StatusService statusService;
	
	@Mock
	private OrderRepository orderRepository;

	@Mock
	private ItemRepository itemRepository;
	
	@Test
	public void validateStatusTest() {
		
		try {
			StatusRequestDTO statusRequest = new StatusRequestDTO();
			statusRequest.setItensAprovados(longValue);
			statusRequest.setPedido(stringValue);
			statusRequest.setStatus(stringValue);
			statusRequest.setValorAprovado(doubleValue);
			
			StatusResponseDTO statusResponse = new StatusResponseDTO();
			List<String> listStatus = new ArrayList<String>();
			listStatus.add(StatusEnum.CODIGO_PEDIDO_INVALIDO.getDsStatus());
			statusResponse.setPedido(stringValue);
			statusResponse.setStatus(listStatus);
			
			when(statusService.validateStatus(statusRequest)).thenReturn(statusResponse);
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}
	
}
