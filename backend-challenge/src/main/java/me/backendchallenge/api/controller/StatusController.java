package me.backendchallenge.api.controller;

import java.util.HashMap;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import me.backendchallenge.domain.model.StatusRequest;
import me.backendchallenge.domain.model.StatusResponse;
import me.backendchallenge.domain.service.StatusService;

@RestController
@RequestMapping(path = "/api/pedido/status", produces = MediaType.APPLICATION_JSON_VALUE)
public class StatusController {
	private StatusService statusService;

	@Autowired
	public StatusController(StatusService statusService) {
		this.statusService = statusService;
	}

	@PostMapping
	public Map<String, Object> verificarStatus(@RequestBody StatusRequest statusRequest) {
		HashMap<String, Object> map = new HashMap<>();
		StatusResponse statusResponse = statusService.verificarStatus(statusRequest);

		map.put("pedido", statusResponse.getPedido());
		map.put("status", statusResponse.getListStatus());

		return map;
	}
}
