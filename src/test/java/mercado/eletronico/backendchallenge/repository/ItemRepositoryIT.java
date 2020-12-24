package mercado.eletronico.backendchallenge.repository;

import mercado.eletronico.backendchallenge.domain.Item;
import mercado.eletronico.backendchallenge.domain.Pedido;
import mercado.eletronico.backendchallenge.utils.TestUtils;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.orm.jpa.DataJpaTest;
import org.springframework.test.context.junit.jupiter.SpringExtension;

import java.util.List;

import static org.junit.jupiter.api.Assertions.*;

@ExtendWith(SpringExtension.class)
@DataJpaTest
class ItemRepositoryIT {

    @Autowired
    private ItemRepository itemRepository;

    @Autowired
    private PedidoRepository pedidoRepository;

    private Pedido pedido;

    @BeforeEach
    void setUp() {
        pedido = TestUtils.montaPedido();
        pedidoRepository.save(pedido);
    }

    @Test
    void findAllByPedido() {
        List<Item> itens = itemRepository.findAllByPedido(pedido);
        assertEquals(2, itens.size());
    }
}