package br.com.mercadoeletronico.testbackend.dto;

import br.com.mercadoeletronico.testbackend.utils.In;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Builder;
import lombok.Data;
import lombok.extern.jackson.Jacksonized;

import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.PositiveOrZero;

@Data
@Jacksonized
@Builder
public class StatusDTO {
    @NotNull
    @NotEmpty
    @JsonProperty("pedido")
    String idOrder;
    @PositiveOrZero
    @JsonProperty("itensAprovados")
    Integer items;
    @PositiveOrZero
    @JsonProperty("valorAprovado")
    Integer price;
    @In(values = {Status.APROVADO, Status.REPROVADO})
    Status status;
}
