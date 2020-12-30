package me.backendchallenge.domain.service;

import static org.hamcrest.CoreMatchers.any;
import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.when;

import org.junit.jupiter.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.jpa.repository.JpaRepository;

import me.backendchallenge.utils.PedidoUtils;
import me.backendchallenge.domain.exception.PedidoNaoEncontradoException;
import me.backendchallenge.domain.model.Pedido;
import me.backendchallenge.domain.repository.PedidoRepository;

class PedidoServiceTest {
	private PedidoService pedidoService;

	@Mock
	private PedidoRepository pedidoRepository;

	@BeforeEach
	void setUp() {
		MockitoAnnotations.openMocks(this);
		pedidoService = new PedidoService(pedidoRepository);
	}

	@Test
	void adicionarPedidoValido() {
		Pedido pedido = PedidoUtils.buildPedidoValido();
		
		when(pedidoRepository.save(pedido)).thenReturn(pedido);

		Pedido pedidoSalvo = pedidoService.salvarPedido(pedido);
		assertEquals(pedido.getPedido(), pedidoSalvo.getPedido());
		assertEquals(pedido.getItens().size(), pedidoSalvo.getItens().size());
	}
	
	@Test
	void adicionarPedidoSemItem() {
		Pedido pedido = PedidoUtils.buildPedidoSemItem();
		
		when(pedidoRepository.save(pedido)).thenReturn(pedido);

		Pedido pedidoSalvo = pedidoService.salvarPedido(pedido);
		assertEquals(pedido.getPedido(), pedidoSalvo.getPedido());
		assertEquals(0, pedidoSalvo.getItens().size());
	}
}
