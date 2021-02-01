package br.com.luizbsilva.api.validator;

import br.com.luizbsilva.api.model.payload.StatusSalesOrder;
import br.com.luizbsilva.api.model.table.Orders;
import br.com.luizbsilva.api.util.StatusEnum;

import java.util.List;

public class StatusValidator extends ValidatorChain<StatusSalesOrder, Orders> {

    @Override
    public List<StatusEnum> check(StatusSalesOrder payload, Orders entity, List<StatusEnum> status) {
        if (payload.getStatus().equalsIgnoreCase(StatusEnum.DISAPPROVED.getMessage())) {
            status.add(StatusEnum.DISAPPROVED);
            return status;
        } else {
            return checkNext(payload, entity, status);
        }
    }

}
