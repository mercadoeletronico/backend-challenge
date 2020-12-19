package br.com.me.backendchallenge.dto;

import br.com.me.backendchallenge.enums.Status;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import java.math.BigDecimal;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class StatusAlterarDTO {
    private Status status;
    private Long itensAprovados;
    private BigDecimal valorAprovado;
    private Long pedido;
}
