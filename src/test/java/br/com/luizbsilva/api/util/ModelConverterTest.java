package br.com.luizbsilva.api.util;

import br.com.luizbsilva.api.model.payload.ItemSalesOrder;
import br.com.luizbsilva.api.model.payload.SalesOrder;
import br.com.luizbsilva.api.model.response.SalesOrderResponse;
import br.com.luizbsilva.api.model.table.Items;
import br.com.luizbsilva.api.model.table.OrderItems;
import br.com.luizbsilva.api.model.table.Orders;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertTrue;

@SpringBootTest
public class ModelConverterTest {

    SalesOrder payload;

    Orders order;

    SalesOrderResponse response;

    @BeforeEach
    void setUp() {
        List<ItemSalesOrder> itens = new ArrayList<>();
        itens.add(ItemSalesOrder.builder().description("ITEM 1").amount(Constants.BIG_DECIMAL_TWO).unitaryValue(Constants.BIG_DECIMAL_THREE).build());
        itens.add(ItemSalesOrder.builder().description("ITEM 2").amount(Constants.BIG_DECIMAL_THREE).unitaryValue(Constants.BIG_DECIMAL_FIVE).build());

        payload = new SalesOrder("123", itens);

        List<OrderItems> items = new ArrayList<>();
        items.add(OrderItems.builder().quantity(Constants.BIG_DECIMAL_TWO).unitPrice(Constants.BIG_DECIMAL_THREE).item(Items.builder().description("ITEM 1").build())
                .build());
        items.add(OrderItems.builder().quantity(Constants.BIG_DECIMAL_THREE).unitPrice(Constants.BIG_DECIMAL_FIVE).item(Items.builder().description("ITEM 2").build())
                .build());

        order = Orders.builder().id("123").totalPrice(Constants.BIG_DECIMAL_TWENTY_ONE).totalQuantity(Constants.BIG_DECIMAL_FIVE).items(items).build();

        response = SalesOrderResponse.builder().ordered("123").items(itens).build();
    }

    @Test
    @DisplayName("When converts SalesOrder to Orders")
    void testConvertsPayloadToTable() {
        assertTrue(ModelConverter.convertsPayloadToTable(payload) instanceof Orders, "Should return a order");
        assertEquals(order, ModelConverter.convertsPayloadToTable(payload),
                "Should return a equal order after convert");
    }

    @Test
    @DisplayName("When converts ItemSalesOrder list to a OrderItems list")
    void testConvertsListItemSalesOrderToListOrderItems() {
        assertTrue(ModelConverter.convertsPayloadToTable(payload.getOrderedItems()) instanceof List, "Should return a List");
        assertTrue(ModelConverter.convertsPayloadToTable(payload.getOrderedItems()).get(0) instanceof OrderItems,
                "Should be a OrderList");
        assertEquals(order.getItems(), ModelConverter.convertsPayloadToTable(payload.getOrderedItems()),
                "Should return a equal list of OrderItems after convert");
    }

    @Test
    @DisplayName("When converts Orders to SalesOrderResponse")
    void testConvertsOrdersToSalesOrderResponse() {
        assertTrue(ModelConverter.convertsTableToResponse(order) instanceof SalesOrderResponse,
                "Should be a SalesOrderResponse");
        assertEquals(response, ModelConverter.convertsTableToResponse(order),
                "Should return a equal response after converter");
    }

}
