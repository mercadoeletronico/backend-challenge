package br.com.me.backendchallenge.dto;

import br.com.me.backendchallenge.enums.StatusPayload;
import lombok.Data;

import java.util.List;

@Data
public class AlteracaoStatusResponseDTO {
    private Long pedido;
    private List<StatusPayload> status;
}
