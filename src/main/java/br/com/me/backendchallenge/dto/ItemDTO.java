package br.com.me.backendchallenge.dto;

import lombok.Data;

@Data
public class ItemDTO {
    private String descricao;
    private String precoUnitario;
    private Long qtd;
}