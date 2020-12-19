package br.com.me.backendchallenge.domain;

import br.com.me.backendchallenge.dto.StatusAlterarDTO;
import br.com.me.backendchallenge.enums.Status;
import org.assertj.core.api.Assertions;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mockito;

import java.math.BigDecimal;
import java.util.List;

class PedidoTest {

    Pedido pedido;

    @BeforeEach
    void setUp() {
        pedido = new Pedido();
        pedido.getItens().add(new Item(null, null, null, BigDecimal.valueOf(2L), 5L));
        pedido.getItens().add(new Item(null, null, null, BigDecimal.valueOf(2L), 5L));
    }


    StatusAlterarDTO novaAlteracao(Status status, Long qtd, BigDecimal valor) {
        return new StatusAlterarDTO(status, qtd, valor, null);
    }

    @Test
    void deveFinalizarStatusAnterior() {
        final var statusPedidoMock = Mockito.mock(StatusPedido.class);
        this.pedido.setStatusAtual(statusPedidoMock);

        Assertions.assertThat(this.pedido.alterarStatus(
                novaAlteracao(Status.APROVADO, 10L, new BigDecimal("20.0"))
        )).hasSize(1).contains(Status.APROVADO);

        Mockito.verify(statusPedidoMock).finalizar();
    }

    @Test
    void deveAdicioanrNovoStatus() {
        final List<StatusPedido> statusList = Mockito.mock(List.class);
        this.pedido.setStatusList(statusList);

        Assertions.assertThat(this.pedido.alterarStatus(
                novaAlteracao(Status.APROVADO, 10L, new BigDecimal("20.0"))
        )).hasSize(1).contains(Status.APROVADO);

        Mockito.verify(statusList).add(Mockito.any(StatusPedido.class));
    }


    @Test
    void deveRetornarAprovado() {
        Assertions.assertThat(this.pedido.alterarStatus(
                novaAlteracao(Status.APROVADO, 10L, new BigDecimal("20.0"))
        )).hasSize(1).contains(Status.APROVADO);
    }

    @Test
    void deveRetornarAprovadoQtdMaior() {
        Assertions.assertThat(this.pedido.alterarStatus(
                novaAlteracao(Status.APROVADO, 15L, new BigDecimal("20.0"))
        )).hasSize(1).contains(Status.APROVADO_QTD_A_MAIOR);
    }

    @Test
    void deveRetornarAprovadoValorMaior() {
        Assertions.assertThat(this.pedido.alterarStatus(
                novaAlteracao(Status.APROVADO, 10L, new BigDecimal("25.0"))
        )).hasSize(1).contains(Status.APROVADO_VALOR_A_MAIOR);
    }

    @Test
    void deveRetornarAprovadoQtdMenor() {
        Assertions.assertThat(this.pedido.alterarStatus(
                novaAlteracao(Status.APROVADO, 1L, new BigDecimal("20.0"))
        )).hasSize(1).contains(Status.APROVADO_QTD_A_MENOR);
    }

    @Test
    void deveRetornarAprovadoValorMenor() {
        Assertions.assertThat(this.pedido.alterarStatus(
                novaAlteracao(Status.APROVADO, 10L, new BigDecimal("10.0"))
        )).hasSize(1)
                .contains(Status.APROVADO_VALOR_A_MENOR);
    }

    @Test
    void deveRetornarAprovadoValorMenorQtdMenor() {
        Assertions.assertThat(this.pedido.alterarStatus(
                novaAlteracao(Status.APROVADO, 1L, new BigDecimal("10.0"))
        )).hasSize(2)
                .contains(Status.APROVADO_VALOR_A_MENOR, Status.APROVADO_QTD_A_MENOR);
    }

    @Test
    void deveRetornarAprovadoValorMaiorQtdMenor() {
        Assertions.assertThat(this.pedido.alterarStatus(
                novaAlteracao(Status.APROVADO, 1L, new BigDecimal("30.0"))
        )).hasSize(2)
                .contains(Status.APROVADO_VALOR_A_MAIOR, Status.APROVADO_QTD_A_MENOR);
    }

    @Test
    void deveRetornarAprovadoValorMaiorQtdMaior() {
        Assertions.assertThat(this.pedido.alterarStatus(
                novaAlteracao(Status.APROVADO, 50L, new BigDecimal("30.0"))
        )).hasSize(2)
                .contains(Status.APROVADO_VALOR_A_MAIOR, Status.APROVADO_QTD_A_MAIOR);
    }

    @Test
    void deveRetornarReprovado() {
        Assertions.assertThat(this.pedido.alterarStatus(
                novaAlteracao(Status.REPROVADO, 50L, new BigDecimal("30.0"))
        )).hasSize(1)
                .contains(Status.REPROVADO);
    }
}