package br.com.mercadoeletronico.testbackend.dto;


import br.com.mercadoeletronico.testbackend.model.Order;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Builder;
import lombok.Value;
import lombok.extern.jackson.Jacksonized;

import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.NotNull;
import javax.validation.constraints.Positive;

@Value
@Jacksonized
@Builder
public class ProductDTO {
    @NotNull
    @NotEmpty
    @JsonProperty("decricao")
    String description;
    @NotNull
    @Positive
    @JsonProperty("precoUnitario")
    Integer price;
    @NotNull
    @Positive
    @JsonProperty("qtd")
    Integer quantity;

    public Order toModel(String idOrder) {
        return Order.builder()
                .idOrder(idOrder)
                .description(description)
                .price(price)
                .quantity(quantity)
                .build();
    }

}
