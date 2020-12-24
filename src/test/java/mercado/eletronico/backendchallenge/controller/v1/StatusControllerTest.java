package mercado.eletronico.backendchallenge.controller.v1;

import mercado.eletronico.backendchallenge.api.v1.model.BaseDTO;
import mercado.eletronico.backendchallenge.api.v1.model.StatusDTO;
import mercado.eletronico.backendchallenge.api.v1.model.StatusUpdateDTO;
import mercado.eletronico.backendchallenge.service.PedidoService;
import mercado.eletronico.backendchallenge.utils.TestUtils;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.when;

class StatusControllerTest {

    @Mock
    private PedidoService pedidoService;

    private StatusController statusController;

    @BeforeEach
    void setUp() {
        MockitoAnnotations.openMocks(this);
        statusController = new StatusController(pedidoService);
    }

    @Test
    void atualizaStatus() {
        StatusUpdateDTO statusUpdateDTO = TestUtils.montaStatusUpdateDTO();
        StatusDTO statusDTO = StatusDTO.builder().build();
        when(pedidoService.atualizaStatus(statusUpdateDTO)).thenReturn(statusDTO);
        ResponseEntity<BaseDTO> resposta = statusController.atualizaStatus(statusUpdateDTO);
        assertEquals(HttpStatus.OK, resposta.getStatusCode());
    }
}