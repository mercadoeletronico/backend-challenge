package br.com.me.backendchallenge.controller;

import br.com.me.backendchallenge.domain.Pedido;
import br.com.me.backendchallenge.dto.PedidoDTO;
import br.com.me.backendchallenge.service.PedidoService;
import io.swagger.v3.oas.annotations.Parameter;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.util.UriComponentsBuilder;

import java.util.List;

@RestController
@RequestMapping("/pedidos")
public class PedidoController {
    private final PedidoService pedidoService;

    public PedidoController(PedidoService pedidoService) {
        this.pedidoService = pedidoService;
    }

    @GetMapping
    public List<Pedido> get() {
        return this.pedidoService.findAll();
    }

    @GetMapping("/{id}")
    public ResponseEntity<Pedido> get(@PathVariable("id") Long id) {
        final var pedido = this.pedidoService.findById(id);
        if (pedido.isPresent()) {
            return ResponseEntity.of(pedido);
        }
        return ResponseEntity.notFound().build();
    }

    @PostMapping
    public ResponseEntity<Void> add(@RequestBody PedidoDTO pedido,
                                    @Parameter(hidden = true) UriComponentsBuilder builder) {
        final var id = this.pedidoService.add(pedido);
        return ResponseEntity
                .created(builder.path("pedidos/{id}").buildAndExpand(id).toUri())
                .build();
    }

    @PutMapping("/{id}")
    public void update(@PathVariable("id") Long id, @RequestBody PedidoDTO pedido) {
        this.pedidoService.update(id, pedido);
    }

}
