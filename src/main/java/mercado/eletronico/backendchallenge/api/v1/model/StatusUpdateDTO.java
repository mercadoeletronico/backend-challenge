package mercado.eletronico.backendchallenge.api.v1.model;


import lombok.Data;

@Data
public class StatusUpdateDTO extends BaseDTO {

    private String pedido;
    private String status;
    private Integer itensAprovados;
    private Double valorAprovado;
}
