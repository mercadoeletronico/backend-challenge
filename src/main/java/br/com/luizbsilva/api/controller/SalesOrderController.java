package br.com.luizbsilva.api.controller;

import br.com.luizbsilva.api.model.payload.SalesOrder;
import br.com.luizbsilva.api.model.response.SalesOrderResponse;
import br.com.luizbsilva.api.service.SalesOrderService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

@RestController
@RequestMapping("/pedido")
public class SalesOrderController {

    @Autowired
    SalesOrderService service;

    @GetMapping("/{id}")
    public ResponseEntity<SalesOrderResponse> getSalesOrder(@PathVariable("id") String id) {
        try {
            return service.find(id);
        } catch (IllegalArgumentException e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @PostMapping
    public ResponseEntity<SalesOrderResponse> createSalesOrder(@RequestBody SalesOrder salesOrder) {
        try {
            return service.create(salesOrder);
        } catch (IllegalArgumentException e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @PutMapping()
    public ResponseEntity<SalesOrderResponse> updateSalesOrder(@RequestBody SalesOrder salesOrder) {
        try {
            return service.update(salesOrder);
        } catch (IllegalArgumentException e) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    @DeleteMapping("/{id}")
    public ResponseEntity<HttpStatus> deleteSaleOrder(@PathVariable("id") String id) {
        return service.delete(id);
    }
}
