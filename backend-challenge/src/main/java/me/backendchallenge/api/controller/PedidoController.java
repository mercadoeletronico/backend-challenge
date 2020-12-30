package me.backendchallenge.api.controller;

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
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;

import me.backendchallenge.domain.model.Pedido;
import me.backendchallenge.domain.service.PedidoService;

@RestController
@RequestMapping(path = "/api/pedido", produces = MediaType.APPLICATION_JSON_VALUE)
public class PedidoController {

	private PedidoService pedidoService;

	@Autowired
	public PedidoController(PedidoService pedidoService) {
		this.pedidoService = pedidoService;
	}

	@GetMapping
	public List<Pedido> listar() {
		return pedidoService.listar();
	}

	@GetMapping("/{pedido}")
	public ResponseEntity<Pedido> buscar(@PathVariable(name = "pedido") String pedido) {
		return ResponseEntity.ok(pedidoService.obterPedido(pedido));
	}

	@PostMapping
	public ResponseEntity<Pedido> salvar(@RequestBody Pedido pedido) {
		Pedido pedidoSalvo = pedidoService.salvarPedido(pedido);

		return ResponseEntity.status(HttpStatus.CREATED).body(pedidoSalvo);
	}

	@PutMapping("/{pedido}")
	public ResponseEntity<Pedido> atualizar(@PathVariable(name = "pedido") String codigoPedido, @RequestBody Pedido pedido) {
		return ResponseEntity.ok(pedidoService.atualizarPedido(codigoPedido, pedido));
	}

	@DeleteMapping("/{pedido}")
	@ResponseStatus(HttpStatus.NO_CONTENT)
	public void delete(@PathVariable String pedido) {
		pedidoService.removerPedido(pedido);
	}
}
