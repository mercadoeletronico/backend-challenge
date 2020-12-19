package br.com.me.backendchallenge.controller;

import br.com.me.backendchallenge.dto.PedidoDTO;
import br.com.me.backendchallenge.service.PedidoService;
import org.assertj.core.api.Assertions;
import org.junit.jupiter.api.Test;
import org.mockito.ArgumentCaptor;
import org.mockito.Captor;
import org.mockito.Mockito;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.WebMvcTest;
import org.springframework.boot.test.mock.mockito.MockBean;
import org.springframework.test.web.servlet.MockMvc;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.header;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.status;

@WebMvcTest(controllers = PedidoController.class)
class PedidoControllerTest {
    @Autowired
    MockMvc mockMvc;

    @MockBean
    PedidoService pedidoService;

    @Captor
    ArgumentCaptor<PedidoDTO> pedidoDTOArgumentCaptor;

    @Test
    void testAdd() throws Exception {
        mockMvc.perform(post("/pedidos")
                .contentType("application/json")
                .content("{\"itens\":[{\"descricao\":\"Item A\"," +
                        "\"precoUnitario\":10,\"qtd\":1},{\"descricao\":\"Item B\",\"precoUnitario\":5,\"qtd\":2}]}"))
                .andExpect(status().isCreated())
                .andExpect(header().exists("Location"));

        Mockito.verify(pedidoService).add(pedidoDTOArgumentCaptor.capture());
        final var pedidoDto = pedidoDTOArgumentCaptor.getValue();
        Assertions.assertThat(pedidoDto.getItens()).hasSize(2);
    }
}