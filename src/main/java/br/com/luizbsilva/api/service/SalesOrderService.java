package br.com.luizbsilva.api.service;

import br.com.luizbsilva.api.model.payload.SalesOrder;
import br.com.luizbsilva.api.model.response.SalesOrderResponse;
import br.com.luizbsilva.api.model.table.OrderItems;
import br.com.luizbsilva.api.model.table.Orders;
import br.com.luizbsilva.api.repository.OrdersRepository;
import br.com.luizbsilva.api.util.ModelConverter;
import br.com.luizbsilva.api.util.StatusEnum;
import br.com.luizbsilva.api.validator.OrderNumberValidator;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Component;

import java.util.ArrayList;
import java.util.List;
import java.util.Objects;
import java.util.Optional;

@Component
public class SalesOrderService extends Service<SalesOrder, Orders> {

    @Autowired
    OrdersRepository ordersRepository;

    @Override
    protected List<String> validate(SalesOrder payload, Orders entity) {
        OrderNumberValidator validator = new OrderNumberValidator();
        List<StatusEnum> status = validator.check(payload, null, new ArrayList<>());

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

    private List<OrderItems> updateOrderItems(List<OrderItems> base, List<OrderItems> newValues) {
        for (int i = 0; i < base.size(); i++) {
            base.get(i).setQuantity(newValues.get(i).getQuantity());
            base.get(i).setUnitPrice(newValues.get(i).getUnitPrice());
            base.get(i).getItem().setDescription(newValues.get(i).getItem().getDescription());
        }

        return base;
    }

    private void updateOrders(Orders base, Orders newValues) {

        Integer sizeBaseItems = base.getItems().size();
        Integer sizeNewItems = newValues.getItems().size();


        if (sizeBaseItems.compareTo(sizeNewItems) == 0) {
            base.setItems(updateOrderItems(base.getItems(), newValues.getItems()));

        } else if (sizeBaseItems.compareTo(sizeNewItems) < 0) {

            base.setItems(updateOrderItems(base.getItems(), newValues.getItems()));
            for (int i = sizeBaseItems; i < sizeNewItems; i++) {
                base.getItems().add(newValues.getItems().get(i));
            }

        } else {

            for (int i = sizeBaseItems - 1; i > sizeNewItems - 1; i--) {
                base.getItems().remove(i);
            }

            base.setItems(updateOrderItems(base.getItems(), newValues.getItems()));
        }

        base.setTotalQuantity(newValues.getTotalQuantity());
        base.setTotalPrice(newValues.getTotalPrice());
    }

    public ResponseEntity<SalesOrderResponse> find(String id) throws IllegalArgumentException {
        List<String> status = validate(new SalesOrder(id), null);

        if (!status.isEmpty()) {
            throw new IllegalArgumentException(status.toString());

        } else {
            Optional<Orders> orders = findOrder(id);

            if (orders.isPresent()) {
                return new ResponseEntity<>(HttpStatus.NOT_FOUND);
            } else {
                return new ResponseEntity<>(ModelConverter.convertsTableToResponse(orders.get()), HttpStatus.OK);
            }
        }
    }

    public ResponseEntity<SalesOrderResponse> create(SalesOrder pedido) throws IllegalArgumentException {
        if (Objects.nonNull(pedido)) {
            List<String> status = validate(pedido, null);

            if (!status.isEmpty()) {
                throw new IllegalArgumentException(status.toString());

            } else {
                if (findOrder(pedido.getOrdered()).isPresent()) {
                    Orders order = ModelConverter.convertsPayloadToTable(pedido);
                    order.setStatus("CREATED");
                    ordersRepository.save(order);
                    return new ResponseEntity<>(HttpStatus.OK);
                } else {
                    return new ResponseEntity<>(HttpStatus.CONFLICT);
                }
            }

        } else {
            throw new IllegalArgumentException("The payload can't be null");
        }
    }

    public ResponseEntity<SalesOrderResponse> update(SalesOrder pedido) throws IllegalArgumentException {
        if (pedido != null) {
            List<String> status = validate(pedido, null);
            if (!status.isEmpty()) {
                throw new IllegalArgumentException(status.toString());

            } else {
                Optional<Orders> orders = findOrder(pedido.getOrdered());

                if (orders.isPresent()) {
                    updateOrders(orders.get(), ModelConverter.convertsPayloadToTable(pedido));
                    ordersRepository.save(orders.get());
                    return new ResponseEntity<>(HttpStatus.OK);

                } else {
                    Orders order = ModelConverter.convertsPayloadToTable(pedido);
                    ordersRepository.save(order);
                    return new ResponseEntity<>(HttpStatus.OK);
                }
            }

        } else {
            throw new IllegalArgumentException("The payload can't be null");
        }
    }

    public ResponseEntity<HttpStatus> delete(String id) {
        List<String> status = validate(new SalesOrder(id), null);

        if (!status.isEmpty()) {
            return new ResponseEntity<>(HttpStatus.BAD_REQUEST);

        } else {
            Optional<Orders> orders = findOrder(id);

            if (orders.isPresent()) {
                ordersRepository.delete(orders.get());
                return new ResponseEntity<>(HttpStatus.OK);

            } else {
                return new ResponseEntity<>(HttpStatus.NOT_FOUND);
            }
        }
    }

}
