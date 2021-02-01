package br.com.luizbsilva.api.validator;

import br.com.luizbsilva.api.model.payload.StatusSalesOrder;
import br.com.luizbsilva.api.model.table.Orders;
import br.com.luizbsilva.api.util.StatusEnum;

import java.util.List;

public class PriceValidator extends ValidatorChain<StatusSalesOrder, Orders> {

    @Override
    public List<StatusEnum> check(StatusSalesOrder payload, Orders entity, List<StatusEnum> status) {
        if (payload.getApprovedValue().compareTo(entity.getTotalPrice()) > 0) {
            status.add(StatusEnum.APPROVED_GREATER_PRICE);
            return checkNext(payload, entity, status);

        } else if (payload.getApprovedValue().compareTo(entity.getTotalPrice()) < 0) {
            status.add(StatusEnum.APPROVED_MINOR_PRICE);
            return checkNext(payload, entity, status);

        } else {
            return checkNext(payload, entity, status);
        }
    }

}
