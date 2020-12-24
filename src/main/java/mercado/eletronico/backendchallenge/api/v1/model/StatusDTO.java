package mercado.eletronico.backendchallenge.api.v1.model;

import lombok.Builder;
import lombok.Data;
import mercado.eletronico.backendchallenge.domain.Status;

import java.util.List;


@Data
@Builder
public class StatusDTO extends BaseDTO {

    private String pedido;
    private List<Status> status;


}
