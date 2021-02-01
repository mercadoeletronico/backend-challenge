package br.com.luizbsilva.api.validator;

import br.com.luizbsilva.api.model.payload.SalesOrder;
import br.com.luizbsilva.api.model.table.Orders;
import br.com.luizbsilva.api.util.StatusEnum;

import java.util.List;
import java.util.Objects;

public class OrderNumberValidator extends ValidatorChain<SalesOrder, Orders> {

    @Override
    public List<StatusEnum> check(SalesOrder payload, Orders entity, List<StatusEnum> status) {
        if (Objects.isNull(payload) || payload.getOrdered().isEmpty() || !payload.getOrdered().matches("\\d+")) {
            status.add(StatusEnum.INVALID_ORDER_NUMBER);
            return status;

        } else {
            return checkNext(payload, entity, status);
        }
    }
}
