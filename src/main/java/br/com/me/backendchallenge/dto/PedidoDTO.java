package br.com.me.backendchallenge.dto;

import lombok.Data;

import java.util.ArrayList;
import java.util.List;

@Data
public class PedidoDTO {
    private List<ItemDTO> itens = new ArrayList<>();
}