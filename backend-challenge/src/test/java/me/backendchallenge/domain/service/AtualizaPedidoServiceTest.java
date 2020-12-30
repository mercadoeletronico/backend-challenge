package me.backendchallenge.domain.service;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.when;

import java.util.ArrayList;

import org.junit.jupiter.api.BeforeAll;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;

import me.backendchallenge.domain.exception.PedidoExistenteException;
import me.backendchallenge.domain.exception.PedidoNaoEncontradoException;
import me.backendchallenge.domain.exception.PriceOrQuantityNonPositiveException;
import me.backendchallenge.domain.model.Pedido;
import me.backendchallenge.domain.repository.PedidoRepository;
import me.backendchallenge.utils.PedidoUtils;

class AtualizaPedidoServiceTest {

	private PedidoService pedidoService;

	@Mock
	private PedidoRepository pedidoRepository;

	@BeforeEach
	void setUp() {
		MockitoAnnotations.openMocks(this);
		pedidoService = new PedidoService(pedidoRepository);
	}

	@Test
	void atualizarPedidoValido() {
		Pedido pedido = PedidoUtils.buildPedidoValido();
		Pedido pedidoAtualizado = PedidoUtils.buildPedidoValido();

		int itens = pedido.getItens().size();

		pedidoAtualizado.setItens(new ArrayList<>());

		when(pedidoRepository.findByPedido(pedido.getPedido())).thenReturn(pedido);
		when(pedidoRepository.save(pedido)).thenReturn(pedido);

		Pedido pedidoRecuperado = pedidoService.atualizarPedido(pedidoAtualizado.getPedido(), pedidoAtualizado);

		assertEquals(pedido.getPedido(), pedidoRecuperado.getPedido());
		assertNotEquals(itens, pedidoRecuperado.getItens().size());
	}

	@Test
	void atualizarPedidoQuantidadeNaoPositiva() {
		Pedido pedido = PedidoUtils.buildPedidoValido();
		Pedido pedidoAtualizado = PedidoUtils.buildPedidoQuantidadeNaoPositiva();

		when(pedidoRepository.findByPedido(pedido.getPedido())).thenReturn(pedido);
		when(pedidoRepository.save(pedido)).thenReturn(pedido);

		assertThrows(PriceOrQuantityNonPositiveException.class,
				() -> pedidoService.atualizarPedido(pedidoAtualizado.getPedido(), pedidoAtualizado));
	}

	@Test
	void atualizarPedidoValorNaoPositivo() {
		Pedido pedido = PedidoUtils.buildPedidoValido();
		Pedido pedidoAtualizado = PedidoUtils.buildPedidoValorNaoPositivo();

		when(pedidoRepository.findByPedido(pedido.getPedido())).thenReturn(pedido);
		when(pedidoRepository.save(pedido)).thenReturn(pedido);

		assertThrows(PriceOrQuantityNonPositiveException.class,
				() -> pedidoService.atualizarPedido(pedidoAtualizado.getPedido(), pedidoAtualizado));
	}

	@Test
	void atualizarPedidoCodigoInexistente() {
		Pedido pedido = PedidoUtils.buildPedidoValido();
		Pedido pedidoRepetido = PedidoUtils.buildPedidoValido();

		when(pedidoRepository.findByPedido(pedido.getPedido()))
				.thenThrow(new PedidoNaoEncontradoException("Pedido não localizado"));
		when(pedidoRepository.save(pedido)).thenReturn(pedido);

		assertThrows(PedidoNaoEncontradoException.class,
				() -> pedidoService.atualizarPedido(PedidoUtils.CODIGO_PEDIDO_INVALIDO, pedidoRepetido));
	}

}
