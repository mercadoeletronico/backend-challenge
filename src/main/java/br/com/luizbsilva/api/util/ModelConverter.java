package br.com.luizbsilva.api.util;

import br.com.luizbsilva.api.model.payload.ItemSalesOrder;
import br.com.luizbsilva.api.model.payload.SalesOrder;
import br.com.luizbsilva.api.model.response.SalesOrderResponse;
import br.com.luizbsilva.api.model.table.Items;
import br.com.luizbsilva.api.model.table.OrderItems;
import br.com.luizbsilva.api.model.table.Orders;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;
import java.util.Objects;

public class ModelConverter {

    private ModelConverter() {
        throw new IllegalStateException("Utility class");
    }

    public static Orders convertsPayloadToTable(SalesOrder payload) {
        Orders orders = new Orders();
        if (Objects.nonNull(payload)) {
            List<OrderItems> items = convertsPayloadToTable(payload.getOrderedItems());
            items.forEach(el -> el.setOrder(Orders.builder().id(payload.getOrdered()).items(items).build()));

            orders = Orders.builder()
                    .id(payload.getOrdered())
                    .totalQuantity(items.stream()
                            .map(item -> item.getQuantity()).reduce((x, y) -> x.add(y)).orElse(BigDecimal.ZERO))
                    .totalPrice(items.stream()
                            .map(item -> item.getUnitPrice().multiply(item.getQuantity()))
                            .reduce(BigDecimal.ZERO, BigDecimal::add))
                    .items(items)
                    .build();
        }

        return orders;
    }

    public static List<OrderItems> convertsPayloadToTable(List<ItemSalesOrder> payload) {
        List<OrderItems> orderItems = new ArrayList<>();
        if (Objects.nonNull(payload)) {
            payload.forEach(
                    item -> orderItems.add(OrderItems.builder()
                            .quantity(item.getAmount())
                            .unitPrice(item.getUnitaryValue())
                            .item(Items.builder().description(item.getDescription()).build()).build()));
        }
        return orderItems;
    }

    public static SalesOrderResponse convertsTableToResponse(Orders orders) {
        SalesOrderResponse response = new SalesOrderResponse();
        if (Objects.nonNull(orders)) {
            List<ItemSalesOrder> itemPayloads = new ArrayList<>();

            orders.getItems().forEach(item -> itemPayloads.add(ItemSalesOrder.builder()
                    .unitaryValue(item.getUnitPrice())
                    .amount(item.getQuantity())
                    .description(item.getItem()
                            .getDescription()).build()));

            response = SalesOrderResponse.builder().ordered(orders.getId()).items(itemPayloads).build();

        }
        return response;
    }

}
