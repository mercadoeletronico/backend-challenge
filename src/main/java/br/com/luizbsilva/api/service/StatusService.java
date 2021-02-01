package br.com.luizbsilva.api.service;

import br.com.luizbsilva.api.model.payload.StatusSalesOrder;
import br.com.luizbsilva.api.model.response.StatusResponse;
import br.com.luizbsilva.api.model.table.Orders;
import br.com.luizbsilva.api.repository.OrdersRepository;
import br.com.luizbsilva.api.util.StatusEnum;
import br.com.luizbsilva.api.validator.*;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;

import java.util.*;

@Component
public class StatusService extends Service<StatusSalesOrder, Orders> {

    @Autowired
    OrdersRepository ordersRepository;

    @Override
    protected List<String> validate(StatusSalesOrder payload, Orders entity) {
        ValidatorChain<StatusSalesOrder, Orders> validator = new StatusValidator();
        validator.linkWith(new QuantityValidator()).linkWith(new PriceValidator());
        List<StatusEnum> status = validator.check(payload, entity, new ArrayList<>());

        if (!status.isEmpty()) {
            List<String> statusMessage = new ArrayList<>();
            status.forEach(element -> statusMessage.add(element.getMessage()));
            return statusMessage;
        }

        return new ArrayList<>();
    }

    @Override
    protected Optional<Orders> findOrder(String id) throws IllegalArgumentException {
        return ordersRepository.findById(id);
    }

    private List<String> validateOrderId(StatusSalesOrder payload) {
        ValidatorChain<StatusSalesOrder, Orders> validator = new OrderNumberStatusValidator();
        List<StatusEnum> status = validator.check(payload, null, new ArrayList<>());

        if (!status.isEmpty()) {
            List<String> statusMessage = new ArrayList<>();
            status.forEach(element -> statusMessage.add(element.getMessage()));

            return statusMessage;
        }

        return new ArrayList<>();
    }

    public ResponseEntity<StatusResponse> updateStatus(StatusSalesOrder status) {
        if (Objects.nonNull(status)) {
            List<String> statusList = validateOrderId(status);
            if (statusList.contains(StatusEnum.INVALID_ORDER_NUMBER.getMessage())) {
                return getStausOrder(status.getOrdered(), statusList, HttpStatus.BAD_REQUEST);

            } else {
                Optional<Orders> order = findOrder(status.getOrdered());

                if (order.isPresent()) {
                    statusList = validate(status, order.get());

                    if (statusList.isEmpty()) {
                        return getStausOrder(status.getOrdered(), Arrays.asList(StatusEnum.APPROVED.getMessage()), HttpStatus.OK);
                    } else {
                        return getStausOrder(status.getOrdered(), statusList, HttpStatus.OK);
                    }
                } else {
                    return getStausOrder(status.getOrdered(), Arrays.asList(StatusEnum.INVALID_ORDER_NUMBER.getMessage()), HttpStatus.NOT_FOUND);
                }
            }
        } else {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);
        }
    }

    private ResponseEntity<StatusResponse> getStausOrder(String pedido, List<String> statusList, HttpStatus httpStatus) {
        return new ResponseEntity<>(
                StatusResponse.builder().ordered(pedido).status(statusList).build(), httpStatus);

    }

}
