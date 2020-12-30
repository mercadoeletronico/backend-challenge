package me.backendchallenge.domain.service;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.when;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;

import me.backendchallenge.domain.exception.PedidoNaoEncontradoException;
import me.backendchallenge.domain.exception.PriceOrQuantityNonPositiveException;
import me.backendchallenge.domain.model.Pedido;
import me.backendchallenge.domain.repository.PedidoRepository;
import me.backendchallenge.utils.PedidoUtils;

class RemovePedidoServiceTest {

	private PedidoService pedidoService;

	@Mock
	private PedidoRepository pedidoRepository;

	@BeforeEach
	void setUp() {
		MockitoAnnotations.openMocks(this);
		pedidoService = new PedidoService(pedidoRepository);
	}

	@Test
	void removePedidoValido() {
		Pedido pedido = PedidoUtils.buildPedidoValido();

		when(pedidoRepository.save(pedido)).thenReturn(pedido);
		when(pedidoRepository.findByPedido(pedido.getPedido())).thenReturn(pedido);

		Pedido pedidoSalvo = pedidoService.salvarPedido(pedido);
		pedidoService.removerPedido(pedidoSalvo.getPedido());
	}

	@Test
	void removePedidoInvalido() {
		Pedido pedido = PedidoUtils.buildPedidoValido();

		when(pedidoRepository.save(pedido)).thenReturn(pedido);
		when(pedidoRepository.findByPedido(pedido.getPedido())).thenReturn(pedido);

		Pedido pedidoSalvo = pedidoService.salvarPedido(pedido);
		assertThrows(PedidoNaoEncontradoException.class,
				() -> pedidoService.removerPedido(PedidoUtils.CODIGO_PEDIDO_SEM_ITEM));
	}

}
