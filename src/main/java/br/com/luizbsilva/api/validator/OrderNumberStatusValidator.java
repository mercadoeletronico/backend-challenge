package br.com.luizbsilva.api.validator;

import br.com.luizbsilva.api.model.payload.StatusSalesOrder;
import br.com.luizbsilva.api.model.table.Orders;
import br.com.luizbsilva.api.util.StatusEnum;

import java.util.List;
import java.util.Objects;

public class OrderNumberStatusValidator extends ValidatorChain<StatusSalesOrder, Orders> {

    @Override
    public List<StatusEnum> check(StatusSalesOrder payload, Orders entity, List<StatusEnum> status) {

        if (Objects.isNull(payload) || Objects.isNull(payload.getOrdered()) || payload.getOrdered().isEmpty()
                || !payload.getOrdered().matches("\\d+")) {
            status.add(StatusEnum.INVALID_ORDER_NUMBER);

            return status;

        } else {
            return checkNext(payload, entity, status);
        }
    }

}
