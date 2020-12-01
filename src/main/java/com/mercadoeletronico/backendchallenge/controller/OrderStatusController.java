package com.mercadoeletronico.backendchallenge.controller;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import com.mercadoeletronico.backendchallenge.dto.StatusRequestDTO;
import com.mercadoeletronico.backendchallenge.dto.StatusResponseDTO;
import com.mercadoeletronico.backendchallenge.service.StatusService;

@RestController
@RequestMapping("/api")
public class OrderStatusController {
	
	@Autowired
	private StatusService statusService;
	
	@PostMapping(value="/status")
	public StatusResponseDTO changeStatus(@RequestBody StatusRequestDTO request) {
		
		return statusService.validateStatus(request);
	}
}
