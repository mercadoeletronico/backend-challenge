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
import com.mercadoeletronico.backendchallenge.service.OrderService;

@RestController
@RequestMapping("/api")
public class OrderController {
	
	@Autowired
	private OrderService orderService;
	
	@GetMapping(value="/pedido", produces = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<List<OrderDTO>> getOrder() {
		List<OrderDTO> response = new ArrayList<OrderDTO>();
		
		try {
			response = orderService.getAllOrders();
		} catch (Exception e) {
			// TODO: handle exception
		}
		
		return new ResponseEntity<List<OrderDTO>>(response, HttpStatus.OK);
	}
	
	@PostMapping(value="/pedido", consumes = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Object> createOrder(@RequestBody OrderDTO request){
		
		orderService.saveOrder(request);
		
		return ResponseEntity.status(HttpStatus.CREATED).build();
	}
	
	@PutMapping(value="/pedido", consumes = MediaType.APPLICATION_JSON_VALUE)
	public ResponseEntity<Object> updateOrder(@RequestBody OrderDTO order){
		orderService.updateOrder(order);
		
		return ResponseEntity.status(HttpStatus.OK).build();
	}
	
	@DeleteMapping(value="/pedido/{pedido}")
	public void deleteOrder(@PathVariable String pedido) {
		orderService.deleteOrder(pedido);
	}
}
