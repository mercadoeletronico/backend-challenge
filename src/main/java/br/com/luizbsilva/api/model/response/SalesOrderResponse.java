package br.com.luizbsilva.api.model.response;

import br.com.luizbsilva.api.model.payload.ItemSalesOrder;
import br.com.luizbsilva.api.model.payload.SalesOrder;
import lombok.*;

import java.util.List;

@NoArgsConstructor
@AllArgsConstructor
@EqualsAndHashCode(callSuper = false)
public class SalesOrderResponse extends SalesOrder {

    @Getter
    @Setter
    private List<String> status;

    @Builder
    public SalesOrderResponse(String ordered, List<ItemSalesOrder> items, List<String> status) {
        super(ordered, items);
        this.status = status;
    }

}
