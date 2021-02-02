package br.com.mercadoeletronico.testbackend.dto;

import br.com.mercadoeletronico.testbackend.model.Order;
import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Builder;
import lombok.Value;
import lombok.extern.jackson.Jacksonized;

import javax.validation.Valid;
import javax.validation.constraints.NotEmpty;
import javax.validation.constraints.NotNull;
import java.util.List;
import java.util.stream.Collectors;

@Value
@Jacksonized
@Builder
public class OrderDTO {
    @NotNull
    @NotEmpty
    @JsonProperty("pedido")
    String idOrder;
    @NotNull
    @NotEmpty
    @JsonProperty("itens")
    List<@Valid ProductDTO> items;

    public List<Order> toModel(){
        return items.stream()
            .map(product -> product.toModel(idOrder))
            .collect(Collectors.toList());
    }

}
