package br.com.me.backendchallenge.domain;

import org.assertj.core.api.Assertions;
import org.junit.jupiter.api.Test;

class StatusPedidoTest {

    @Test
    void finalizarDevePreencherFim() {
        var statusPedido = new StatusPedido();
        Assertions.assertThat(statusPedido.getFinalizadoEm()).isNull();
        statusPedido.finalizar();
        Assertions.assertThat(statusPedido.getFinalizadoEm()).isNotNull();
    }
}
