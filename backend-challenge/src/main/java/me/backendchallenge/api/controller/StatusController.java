package me.backendchallenge.api.controller;

import java.util.HashMap;
import java.util.Map;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import me.backendchallenge.domain.model.StatusEnum;
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
	public Map<String, String> verificarStatus(@RequestBody StatusRequest statusRequest) {
		HashMap<String, String> map = new HashMap<>();
		StatusResponse statusResponse = statusService.verificarStatus(statusRequest);

		String statusString = "";
		for (StatusEnum status : statusResponse.getListStatus()) {
			System.out.println("Status: " + status.toString());
			statusString += status.toString();
			statusString += " ";
		}

		map.put("pedido", statusResponse.getPedido());
		map.put("status", statusString);

		return map;
	}

}
