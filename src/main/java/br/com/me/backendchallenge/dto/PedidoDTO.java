package br.com.me.backendchallenge.dto;

import lombok.Data;

import javax.validation.constraints.NotEmpty;
import java.util.ArrayList;
import java.util.List;

@Data
public class PedidoDTO {
    @NotEmpty
    private List<ItemDTO> itens = new ArrayList<>();
}