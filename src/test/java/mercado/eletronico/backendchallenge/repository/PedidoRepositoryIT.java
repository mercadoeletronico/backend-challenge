package mercado.eletronico.backendchallenge.repository;

import mercado.eletronico.backendchallenge.domain.Pedido;
import mercado.eletronico.backendchallenge.domain.Status;
import mercado.eletronico.backendchallenge.utils.TestUtils;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.test.context.junit.jupiter.SpringExtension;

import static org.junit.jupiter.api.Assertions.*;

@ExtendWith(SpringExtension.class)
@DataJpaTest
class PedidoRepositoryIT {

    @Autowired
    private PedidoRepository pedidoRepository;

    @BeforeEach
    void setUp() {
        Pedido pedido = TestUtils.montaPedido();
        pedidoRepository.save(pedido);
    }

    @Test
    void existsByNumeroPedido() {
        Boolean resultadoConsulta = pedidoRepository.existsByCodigoPedido(TestUtils.NUMERO_PEDIDO);
        assertTrue(resultadoConsulta);
    }

    @Test
    void existsByNumeroPedidoQuandoPedidoNaoExiste() {
        Boolean resultadoConsulta = pedidoRepository.existsByCodigoPedido(Status.CODIGO_PEDIDO_INVALIDO.name());
        assertFalse(resultadoConsulta);
    }

    @Test
    void findByNumeroPedido() {
        Pedido resultadoConsulta = pedidoRepository.findByCodigoPedido(TestUtils.NUMERO_PEDIDO);
        assertEquals(TestUtils.NUMERO_PEDIDO, resultadoConsulta.getCodigoPedido());
    }


}