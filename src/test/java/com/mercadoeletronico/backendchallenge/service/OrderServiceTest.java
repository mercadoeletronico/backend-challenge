package com.mercadoeletronico.backendchallenge.service;

import static org.junit.Assert.assertEquals;
import static org.mockito.Mockito.times;
import static org.mockito.Mockito.verify;

import java.util.ArrayList;
import java.util.List;
import java.util.Optional;

import org.junit.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.Mockito;
import org.mockito.junit.jupiter.MockitoExtension;

import com.mercadoeletronico.backendchallenge.entity.Item;
import com.mercadoeletronico.backendchallenge.entity.Order;
import com.mercadoeletronico.backendchallenge.repository.ItemRepository;
import com.mercadoeletronico.backendchallenge.repository.OrderRepository;

@ExtendWith(MockitoExtension.class)
public class OrderServiceTest {

	String stringValue = "String Test";
	Long longValue = new Long(1);
	Double doubleValue = new Double(10.0);

	@InjectMocks
	private OrderService orderService;

	@Mock
	private OrderRepository orderRepository;

	@Mock
	private ItemRepository itemRepository;

	@Test
	public void getAllOrdersTest() {
		try {
			List<Item> listItem = new ArrayList<Item>();
			listItem.add(new Item(longValue, stringValue, doubleValue, longValue, longValue));
			List<Order> listOrder = new ArrayList<Order>();
			listOrder.add(new Order(longValue, "1", listItem));

			Mockito.when(orderRepository.findAll()).thenReturn(listOrder);

			List<Order> response = orderService.getAllOrders();

			assertEquals("1", response.get(0).getPedido());
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}

	@Test
	public void getOrderByPedidoTest() {
		try {
			List<Item> listItem = new ArrayList<Item>();
			listItem.add(new Item(longValue, stringValue, doubleValue, longValue, longValue));
			Order order = new Order(longValue, "1", listItem);

			Mockito.when(orderRepository.findByPedido(Mockito.anyString())).thenReturn(order);

			Order response = orderService.getOrderByPedido(order.getPedido());

			assertEquals("1", response.getPedido());
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}

	@Test
	public void getItensByPedidoIdTest() {
		try {
			List<Item> listItem = new ArrayList<Item>();
			listItem.add(new Item(longValue, stringValue, doubleValue, longValue, longValue));
			Order order = new Order(longValue, "1", listItem);

			Mockito.when(itemRepository.findByPedidoId(Mockito.anyLong())).thenReturn(listItem);

			List<Item> response = orderService.getItensByPedidoId(order.getId());

			assertEquals(null, response);

		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}

	@Test
	public void getOrderTest() {
		try {
			List<Item> listItem = new ArrayList<Item>();
			listItem.add(new Item(longValue, stringValue, doubleValue, longValue, longValue));
			Optional<Order> order = Optional.empty();
			order =	orderService.getOrder(longValue);
			
			Mockito.when(orderRepository.findById(Mockito.anyLong())).thenReturn(order);

			Optional<Order> response = orderService.getOrder(order.get().getId());

			assertEquals("1", response);
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}

	@Test
	public void saveItemTest() {
		try {
			List<Item> listItem = new ArrayList<Item>();
			listItem.add(new Item(longValue, stringValue, doubleValue, longValue, longValue));
			Mockito.when(itemRepository.save(Mockito.any(Item.class))).thenReturn(null);
			verify(itemRepository, times(1)).save(Mockito.any(Item.class));
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}

	@Test
	public void saveOrderTest() {
		try {
			List<Item> listItem = new ArrayList<Item>();
			listItem.add(new Item(longValue, stringValue, doubleValue, longValue, longValue));
			Order order = new Order(longValue, "1", listItem);
			Mockito.when(orderRepository.save(Mockito.any(Order.class))).thenReturn(order);
			verify(orderRepository, times(1)).save(Mockito.any(Order.class));
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}


	@Test
	public void deleteOrderTest() {
		try {
			List<Item> listItem = new ArrayList<Item>();
			listItem.add(new Item(longValue, stringValue, doubleValue, longValue, longValue));
			Order order = new Order(longValue, "1", listItem);
			Mockito.when(orderRepository.findByPedido(stringValue)).thenReturn(order);
			verify(orderRepository, times(1)).delete(Mockito.any(Order.class));
		} catch (Exception e) {
			org.junit.Assert.fail();
		}
	}
}
