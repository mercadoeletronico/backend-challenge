package br.com.me.backendchallenge.dto;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NoArgsConstructor;

import javax.validation.constraints.NotNull;
import javax.validation.constraints.Positive;
import java.math.BigDecimal;

@Data
@AllArgsConstructor
@NoArgsConstructor
public class ItemDTO {
    private Long id;
    @NotNull
    private String descricao;
    @NotNull
    @Positive
    private BigDecimal precoUnitario;
    @NotNull
    @Positive
    private Long qtd;
}