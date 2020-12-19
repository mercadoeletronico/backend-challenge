package br.com.me.backendchallenge.controller;

import br.com.me.backendchallenge.dto.StatusAlteradoDTO;
import br.com.me.backendchallenge.dto.StatusAlterarDTO;
import br.com.me.backendchallenge.service.PedidoService;
import io.swagger.v3.oas.annotations.tags.Tag;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@Tag(name = "Pedido")
@RestController
@RequestMapping("/status")
public class StatusController {

    private final PedidoService pedidoService;

    public StatusController(PedidoService pedidoService) {
        this.pedidoService = pedidoService;
    }

    @PostMapping
    public ResponseEntity<StatusAlteradoDTO> updateStatus(@RequestBody StatusAlterarDTO statusAlterarDTO) {
        return ResponseEntity.ok(this.pedidoService.alterarStatus(statusAlterarDTO));
    }

} 