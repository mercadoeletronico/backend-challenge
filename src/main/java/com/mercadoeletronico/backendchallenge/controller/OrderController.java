package com.mercadoeletronico.backendchallenge.controller;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.DeleteMapping;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.PutMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.mercadoeletronico.backendchallenge.dto.OrderDTO;
import com.mercadoeletronico.backendchallenge.entity.Item;
import com.mercadoeletronico.backendchallenge.entity.Order;
import com.mercadoeletronico.backendchallenge.service.OrderService;

@RestController
@RequestMapping("/api")
public class OrderController {
	
	@Autowired
	private OrderService orderService;
	
	@GetMapping(value="/pedido", produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<List<Order>> getOrder() {
		List<Order> response = new ArrayList<Order>();
		
		try {
			response = orderService.getAllOrders();
		} catch (Exception e) {
			// TODO: handle exception
		}
		
		return new ResponseEntity<List<Order>>(response, HttpStatus.OK);
	}
	
	@GetMapping(value="/pedido/{pedido}")
	public Order getOrderByPedido(@PathVariable String pedido) {
		return orderService.getOrderByPedido(pedido);
	}
	
	@PostMapping(value="/pedido", consumes = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Object> createOrder(@RequestBody OrderDTO request){
		
		Order order = new Order();
		List<Item> itemList = new ArrayList<Item>();
		
		itemList = request.getItens();
		
		for(int i = 0; i < itemList.size(); i++) {
			order.setItem(itemList);
			order.setPedido(request.getPedido());
			orderService.saveOrder(order);
			itemList.get(i).setPedidoId(order.getId());
			orderService.saveItem(itemList.get(i));
		}
		
		return ResponseEntity.status(HttpStatus.CREATED).build();
	}
	
		@PutMapping(value="/pedido", consumes = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Object> updateOrder(@RequestBody OrderDTO request){
		Order order = orderService.getOrderByPedido(request.getPedido());
		Long pedidoId = order.getId();
		orderService.updateItem(pedidoId, request.getItens());
		
		return ResponseEntity.status(HttpStatus.OK).build();
	}
	
	@DeleteMapping(value="/pedido/{pedido}")
	public ResponseEntity<Object> deleteOrder(@PathVariable String pedido) {
		Order order = orderService.getOrderByPedido(pedido);
		Long pedidoId = order.getId();
		orderService.deleteOrder(pedidoId);
		return ResponseEntity.status(HttpStatus.OK).build();
	}
}
