package br.com.me.backendchallenge.controller;

import br.com.me.backendchallenge.enums.Status;
import org.hamcrest.Matchers;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.autoconfigure.web.servlet.AutoConfigureMockMvc;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.test.web.servlet.MockMvc;

import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.get;
import static org.springframework.test.web.servlet.request.MockMvcRequestBuilders.post;
import static org.springframework.test.web.servlet.result.MockMvcResultMatchers.*;


@SpringBootTest
@AutoConfigureMockMvc
class PedidoIntegrationTest {
    @Autowired
    MockMvc mockMvc;

    String pedidoId;

    @BeforeEach
    void setUp() throws Exception {
        mockMvc.perform(post("/pedidos")
                .contentType("application/json")
                .content("{\"itens\":[{\"descricao\":\"Item A\"," +
                        "\"precoUnitario\":10,\"qtd\":1},{\"descricao\":\"Item B\",\"precoUnitario\":5,\"qtd\":2}]}"))
                .andExpect(status().isCreated())
                .andExpect(header().exists("Location"))
                .andDo(h -> {
                    final var location = h.getResponse().getHeader("Location");
                    pedidoId = location.substring(location.lastIndexOf("/") + 1);
                });
    }

    @Test
    void testGet() throws Exception {
        mockMvc.perform(get("/pedidos/" + pedidoId)).andExpect(status().isOk());
    }

    @Test
    void testStatusAprovado() throws Exception {
        mockMvc.perform(post("/status")
                .contentType("application/json")
                .content("{\"status\":\"APROVADO\",\"itensAprovados\":3,\"valorAprovado\":20,\"pedido\":\"" + pedidoId + "\"}"))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$.status", Matchers.contains(Status.APROVADO.name())));
    }

    @Test
    void testStatusReprovado() throws Exception {
        mockMvc.perform(post("/status")
                .contentType("application/json")
                .content("{\"status\":\"REPROVADO\",\"itensAprovados\":3,\"valorAprovado\":20,\"pedido\":\"" + pedidoId + "\"}"))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$.status", Matchers.contains(Status.REPROVADO.name())));
    }

    @Test
    void testStatusValorMenor() throws Exception {
        mockMvc.perform(post("/status")
                .contentType("application/json")
                .content("{\"status\":\"APROVADO\",\"itensAprovados\":3,\"valorAprovado\":10,\"pedido\":\"" + pedidoId + "\"}"))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$.status", Matchers.contains(Status.APROVADO_VALOR_A_MENOR.name())));
    }

    @Test
    void testStatusValorMaiorQtdMaior() throws Exception {
        mockMvc.perform(post("/status")
                .contentType("application/json")
                .content("{\"status\":\"APROVADO\",\"itensAprovados\":4,\"valorAprovado\":22,\"pedido\":\"" + pedidoId + "\"}"))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$.status", Matchers.contains(Status.APROVADO_VALOR_A_MAIOR.name(),
                        Status.APROVADO_QTD_A_MAIOR.name())));
    }

    @Test
    void testStatusQtdMenor() throws Exception {
        mockMvc.perform(post("/status")
                .contentType("application/json")
                .content("{\"status\":\"APROVADO\",\"itensAprovados\":2,\"valorAprovado\":20,\"pedido\":\"" + pedidoId + "\"}"))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$.status", Matchers.contains(Status.APROVADO_QTD_A_MENOR.name())));
    }

    @Test
    void testStatusCodigoInvalido() throws Exception {
        mockMvc.perform(post("/status")
                .contentType("application/json")
                .content("{\"status\":\"APROVADO\",\"itensAprovados\":2,\"valorAprovado\":20,\"pedido\":\"123xs\"}"))
                .andExpect(status().isOk())
                .andExpect(jsonPath("$.status", Matchers.contains(Status.CODIGO_PEDIDO_INVALIDO.name())));
    }

    @Test
    void testStatusInvalido() throws Exception {
        mockMvc.perform(post("/status")
                .contentType("application/json")
                .content("{\"status\":\"APROVADO_QTD_A_MENOR\",\"itensAprovados\":2,\"valorAprovado\":20,\"pedido\":\"" + pedidoId + "\"}"))
                .andExpect(status().isBadRequest());
    }
}