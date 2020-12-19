package br.com.me.backendchallenge.service;

import br.com.me.backendchallenge.dto.ItemDTO;
import br.com.me.backendchallenge.dto.PedidoDTO;
import org.assertj.core.api.Assertions;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.transaction.annotation.Transactional;

import java.math.BigDecimal;

@SpringBootTest
class PedidoServiceITTest {

    @Autowired
    private PedidoService pedidoService;

    @Test
    @Transactional
    void testAdd() {
        final var pedidoDTO = new PedidoDTO();
        pedidoDTO.getItens().add(new ItemDTO(null, "A", BigDecimal.TEN, 1L));
        pedidoDTO.getItens().add(new ItemDTO(null, "B", BigDecimal.TEN, 10L));
        final var pedidoId = pedidoService.add(pedidoDTO);
        final var pedidoOpt = pedidoService.findById(pedidoId);
        Assertions.assertThat(pedidoOpt).isNotEmpty();
        final var pedido = pedidoOpt.get();
        Assertions.assertThat(pedido.getItens()).hasSize(2);
        Assertions.assertThat(pedido.getQtdTotalItens()).isEqualTo(11);
        Assertions.assertThat(pedido.getValorTotal()).isEqualTo(BigDecimal.valueOf(110L));
    }

    @Test
    void testDeleteById() {
        final var pedidoDTO = new PedidoDTO();
        final var pedidoId = pedidoService.add(pedidoDTO);
        var pedidoOpt = pedidoService.findById(pedidoId);
        Assertions.assertThat(pedidoOpt).isNotEmpty();
        pedidoService.deleteById(pedidoId);
        pedidoOpt = pedidoService.findById(pedidoId);
        Assertions.assertThat(pedidoOpt).isEmpty();
    }

    @Test
    @Transactional
    void testUpdate() {
        var pedidoDTO = new PedidoDTO();
        pedidoDTO.getItens().add(new ItemDTO(null, "A", BigDecimal.TEN, 1L));
        pedidoDTO.getItens().add(new ItemDTO(null, "B", BigDecimal.TEN, 10L));
        final var pedidoId = pedidoService.add(pedidoDTO);

        var pedidoOpt = pedidoService.findById(pedidoId);
        var pedido = pedidoOpt.get();
        Assertions.assertThat(pedido.getItens()).hasSize(2);

        pedidoDTO = new PedidoDTO();
        pedidoDTO.getItens().add(new ItemDTO(null, "A", BigDecimal.TEN, 1L));
        pedidoService.update(pedidoId, pedidoDTO);

        pedidoOpt = pedidoService.findById(pedidoId);
        pedido = pedidoOpt.get();
        Assertions.assertThat(pedido.getItens()).hasSize(1);

        pedidoDTO = new PedidoDTO();
        pedidoDTO.getItens().add(new ItemDTO(pedido.getItens().get(0).getId(), "B", BigDecimal.TEN, 1L));
        pedidoService.update(pedidoId, pedidoDTO);

        pedidoOpt = pedidoService.findById(pedidoId);
        pedido = pedidoOpt.get();
        Assertions.assertThat(pedido.getItens()).hasSize(1);
        Assertions.assertThat(pedido.getItens().get(0).getDescricao()).isEqualTo("B");

    }
}