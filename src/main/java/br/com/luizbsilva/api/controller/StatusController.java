package br.com.luizbsilva.api.controller;

import br.com.luizbsilva.api.model.payload.StatusSalesOrder;
import br.com.luizbsilva.api.model.response.StatusResponse;
import br.com.luizbsilva.api.service.StatusService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/status")
public class StatusController {

    @Autowired
    StatusService service;

    @PostMapping
    public ResponseEntity<StatusResponse> setStatus(@RequestBody StatusSalesOrder status) {
        return service.updateStatus(status);
    }

}
