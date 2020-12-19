package br.com.me.backendchallenge.dto;

import br.com.me.backendchallenge.enums.Status;
import br.com.me.backendchallenge.validation.StatusSubset;
import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.PositiveOrZero;
import java.math.BigDecimal;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class StatusAlterarDTO {
    @NotNull
    @StatusSubset(anyOf = {Status.APROVADO, Status.REPROVADO})
    private Status status;
    @NotNull
    @PositiveOrZero
    private Long itensAprovados;
    @NotNull
    @PositiveOrZero
    private BigDecimal valorAprovado;
    @NotNull
    private String pedido;
}
