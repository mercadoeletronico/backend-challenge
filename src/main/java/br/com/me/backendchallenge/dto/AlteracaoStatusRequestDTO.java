package br.com.me.backendchallenge.dto;

import br.com.me.backendchallenge.enums.Status;
import lombok.Data;

import java.math.BigDecimal;

@Data
public class AlteracaoStatusRequestDTO {
    private Status status;
    private Long itensAprovados;
    private BigDecimal valorAprovado;
    private Long pedido;
}
