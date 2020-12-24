package mercado.eletronico.backendchallenge.api.v1.model;

import lombok.Data;

@Data
public class ItemDTO {
    private String descricao;
    private Double precoUnitario;
    private Integer qtd;
}
