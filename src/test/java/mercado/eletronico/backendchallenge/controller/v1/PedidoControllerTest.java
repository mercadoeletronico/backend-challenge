package mercado.eletronico.backendchallenge.controller.v1;

import mercado.eletronico.backendchallenge.api.v1.model.BaseDTO;
import mercado.eletronico.backendchallenge.api.v1.model.PedidoDTO;
import mercado.eletronico.backendchallenge.api.v1.model.StatusDTO;
import mercado.eletronico.backendchallenge.domain.Status;
import mercado.eletronico.backendchallenge.service.PedidoService;
import mercado.eletronico.backendchallenge.utils.TestUtils;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

import java.util.Collections;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.when;

class PedidoControllerTest {

    @Mock
    private PedidoService pedidoService;
    private PedidoController pedidoController;
    private PedidoDTO pedidoDTO;
    private StatusDTO statusDTO;

    @BeforeEach
    void setUp() {
        MockitoAnnotations.openMocks(this);
        pedidoController = new PedidoController(pedidoService);
        pedidoDTO = TestUtils.montaPedidoDTO();
        statusDTO = StatusDTO.builder()
                .pedido(TestUtils.NUMERO_PEDIDO)
                .status(Collections.singletonList(Status.PEDIDO_DELETADO))
                .build();
    }

    @Test
    void getPedido() {
        when(pedidoService.getPedido(pedidoDTO.getPedido())).thenReturn(pedidoDTO);
        ResponseEntity<BaseDTO> resposta = pedidoController.getPedido(pedidoDTO);
        PedidoDTO respostaDTO = (PedidoDTO) resposta.getBody();
        assertEquals(HttpStatus.OK,resposta.getStatusCode());
        assertEquals(pedidoDTO.getPedido(), respostaDTO.getPedido());
    }

    @Test
    void criaNovoPedido() {
        when(pedidoService.criaNovoPedido(pedidoDTO)).thenReturn(pedidoDTO);
        ResponseEntity<BaseDTO> resposta = pedidoController.criaNovoPedido(pedidoDTO);
        PedidoDTO respostaDTO = (PedidoDTO) resposta.getBody();
        assertEquals(HttpStatus.CREATED,resposta.getStatusCode());
        assertEquals(pedidoDTO.getPedido(), respostaDTO.getPedido());
    }

    @Test
    void editaPedido() {
        when(pedidoService.editaPedido(pedidoDTO)).thenReturn(pedidoDTO);
        ResponseEntity<BaseDTO> resposta = pedidoController.editaPedido(pedidoDTO);
        PedidoDTO respostaDTO = (PedidoDTO) resposta.getBody();
        assertEquals(HttpStatus.OK,resposta.getStatusCode());
        assertEquals(pedidoDTO.getPedido(), respostaDTO.getPedido());
    }

    @Test
    void deletaPedido() {
        when(pedidoService.deletaPedido(pedidoDTO)).thenReturn(statusDTO);
        ResponseEntity<BaseDTO> resposta = pedidoController.deletaPedido(pedidoDTO);
        StatusDTO respostaDTO = (StatusDTO) resposta.getBody();
        assertEquals(HttpStatus.OK,resposta.getStatusCode());
        assertEquals(pedidoDTO.getPedido(), respostaDTO.getPedido());
        assertEquals(Status.PEDIDO_DELETADO, respostaDTO.getStatus().get(0));

    }
}