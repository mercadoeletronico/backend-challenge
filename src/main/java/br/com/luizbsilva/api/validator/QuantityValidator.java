package br.com.luizbsilva.api.validator;

import br.com.luizbsilva.api.model.payload.StatusSalesOrder;
import br.com.luizbsilva.api.model.table.Orders;
import br.com.luizbsilva.api.util.StatusEnum;
import lombok.NoArgsConstructor;

import java.util.List;

@NoArgsConstructor
public class QuantityValidator extends ValidatorChain<StatusSalesOrder, Orders> {

    @Override
    public List<StatusEnum> check(StatusSalesOrder payload, Orders entity, List<StatusEnum> status) {
        if (payload.getApprovedItems().compareTo(entity.getTotalQuantity()) > 0) {
            status.add(StatusEnum.APPROVED_GREATER_QUANTITY);
            return checkNext(payload, entity, status);

        } else if (payload.getApprovedItems().compareTo(entity.getTotalQuantity()) < 0) {
            status.add(StatusEnum.APPROVED_MINOR_QUANTITY);
            return checkNext(payload, entity, status);

        } else {
            return checkNext(payload, entity, status);
        }
    }

}
