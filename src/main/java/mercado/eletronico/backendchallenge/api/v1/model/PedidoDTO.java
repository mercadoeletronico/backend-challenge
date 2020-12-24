package mercado.eletronico.backendchallenge.api.v1.model;

import lombok.Data;

import java.util.List;

@Data
public class PedidoDTO extends BaseDTO {

    private String pedido;
    private List<ItemDTO> itens;
}
