package com.mercadoeletronico.backendchallenge.controller;

import static org.junit.Assert.assertEquals;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import org.junit.Test;
import org.junit.runner.RunWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.MockitoJUnitRunner;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

import com.mercadoeletronico.backendchallenge.dto.OrderDTO;
import com.mercadoeletronico.backendchallenge.entity.Item;
import com.mercadoeletronico.backendchallenge.entity.Order;
import com.mercadoeletronico.backendchallenge.service.OrderService;
import com.mercadoeletronico.backendchallenge.service.StatusService;

@RunWith(MockitoJUnitRunner.Silent.class)

public class OrderControllerTest {

	@InjectMocks
	private OrderController orderController;

	@InjectMocks
	private OrderStatusController orderStatusController;

	@Mock
	private OrderService orderService;

	@Mock
	private StatusService statusService;

	Long longValue = new Long(1);
	Double doubleValue = new Double(10.0);

	@Test
	public void getOrderTest() {
		try {
			List<Order> expected = new ArrayList<Order>();
			Mockito.when(orderService.getAllOrders()).thenReturn(expected);
			ResponseEntity<List<Order>> response = orderController.getOrder();
			assertEquals(expected, response.getBody());
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}

	@Test
	public void getOrderByPedidoTest() {
		try {
			Optional<Order> expected = Optional.empty();
			Mockito.when(orderService.getOrder(Mockito.anyLong())).thenReturn(expected);
			Order response = orderController.getOrderByPedido(Mockito.anyString());
			assertEquals(null, response);
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}

	@Test
	public void createOrderTest() {
		try {
			OrderDTO request = new OrderDTO();
			List<Item> itemRequest = new ArrayList<Item>();
			request.setItens(itemRequest);
			request.setPedido("1");
			Mockito.when(orderController.createOrder(request)).thenReturn(ResponseEntity.status(HttpStatus.CREATED).build());

			assertEquals(ResponseEntity.status(HttpStatus.CREATED).build(), orderController.createOrder(request));
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}

	@Test
	public void updateOrderTest() {
		try {
			OrderDTO request = new OrderDTO();
			List<Item> itemRequest = new ArrayList<Item>();
			request.setItens(itemRequest);
			request.setPedido("1");
			Mockito.when(orderController.updateOrder(request)).thenReturn(ResponseEntity.status(HttpStatus.OK).build());

			assertEquals(ResponseEntity.status(HttpStatus.OK).build(), orderController.updateOrder(request));
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}

	@Test
	public void deleteOrderTest() {
		try {
			OrderDTO request = new OrderDTO();
			List<Item> itemRequest = new ArrayList<Item>();
			request.setItens(itemRequest);
			request.setPedido("1");
			Mockito.when(orderController.deleteOrder(request.getPedido())).thenReturn(ResponseEntity.status(HttpStatus.OK).build());

			assertEquals(ResponseEntity.status(HttpStatus.OK).build(), orderController.deleteOrder(request.getPedido()));
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}

}
