package me.backendchallenge.domain.service;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.Mockito.when;

import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;

import me.backendchallenge.domain.exception.PedidoNaoEncontradoException;
import me.backendchallenge.domain.exception.PriceOrQuantityNonPositiveException;
import me.backendchallenge.domain.model.Pedido;
import me.backendchallenge.domain.repository.PedidoRepository;
import me.backendchallenge.utils.PedidoUtils;

class ConsultaPedidoServiceTest {

	private PedidoService pedidoService;

	@Mock
	private PedidoRepository pedidoRepository;

	@BeforeEach
	void setUp() {
		MockitoAnnotations.openMocks(this);
		pedidoService = new PedidoService(pedidoRepository);
	}
	
	@Test
	void consultaPedidoValido() {
		Pedido pedido = PedidoUtils.buildPedidoValido();
		
		when(pedidoRepository.findByPedido(pedido.getPedido())).thenReturn(pedido);
		pedido = pedidoService.obterPedido(PedidoUtils.CODIGO_PEDIDO_VALIDO);
		assertEquals(pedido.getPedido(), PedidoUtils.CODIGO_PEDIDO_VALIDO);
	}
	
	@Test
	void consultaPedidoInvalido() {
		Pedido pedido = PedidoUtils.buildPedidoValido();
		
		when(pedidoRepository.existsByPedido(pedido.getPedido())).thenReturn(false);
		
		assertEquals(pedido.getPedido(), PedidoUtils.CODIGO_PEDIDO_VALIDO);
		
		assertThrows(PedidoNaoEncontradoException.class, () -> pedidoService.obterPedido(PedidoUtils.CODIGO_PEDIDO_VALIDO));
	}

}
