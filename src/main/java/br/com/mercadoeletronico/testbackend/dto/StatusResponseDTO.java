package br.com.mercadoeletronico.testbackend.dto;

import com.fasterxml.jackson.annotation.JsonProperty;
import lombok.Builder;
import lombok.Value;

import java.util.List;

@Value
@Builder(builderClassName = "Builder")
public class StatusResponseDTO {
    @JsonProperty("pedido")
    String idOrder;
    List<Status> status;
}
