package br.com.luizbsilva.api.service;


import br.com.luizbsilva.api.model.payload.ItemSalesOrder;
import br.com.luizbsilva.api.model.payload.SalesOrder;
import br.com.luizbsilva.api.model.response.SalesOrderResponse;
import br.com.luizbsilva.api.model.table.Items;
import br.com.luizbsilva.api.model.table.OrderItems;
import br.com.luizbsilva.api.model.table.Orders;
import br.com.luizbsilva.api.repository.OrdersRepository;
import br.com.luizbsilva.api.util.Constants;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.junit.jupiter.api.Assertions.assertThrows;
import static org.mockito.ArgumentMatchers.anyString;
import static org.mockito.Mockito.when;

@SpringBootTest
public class SalesOrderServiceTest {

    @InjectMocks
    SalesOrderService service;

    @Mock
    OrdersRepository repository;

    Optional<Orders> order;

    AutoCloseable closeable;

    @BeforeEach
    void init() {
        closeable = MockitoAnnotations.openMocks(this);

        List<OrderItems> items = new ArrayList<>();
        Orders orderAux = Orders.builder().id("123456").totalPrice(Constants.BIG_DECIMAL_TWENTY).totalQuantity(Constants.BIG_DECIMAL_THREE).build();
        items.add(OrderItems.builder().order(orderAux).id(1l).quantity(Constants.BIG_DECIMAL_TWO).unitPrice(Constants.BIG_DECIMAL_FIVE)
                .item(Items.builder().description("ITEM 1").build()).build());
        items.add(OrderItems.builder().order(orderAux).id(2l).quantity(Constants.BIG_DECIMAL_THREE).unitPrice(Constants.BIG_DECIMAL_FIVE)
                .item(Items.builder().description("ITEM 2").build()).build());
        orderAux.setItems(items);
        order = Optional.of(orderAux);
    }

    @AfterEach
    void end() throws Exception {
        closeable.close();
    }

    @Test
    @DisplayName("When order found")
    void testFind() {
        when(repository.findById("123456")).thenReturn(order);
        ResponseEntity<SalesOrderResponse> response = service.find("123456");
        SalesOrderResponse expected = SalesOrderResponse.builder().ordered("123456")
                .items(Arrays.asList(ItemSalesOrder.builder().description("ITEM 1").amount(Constants.BIG_DECIMAL_TWO).unitaryValue(Constants.BIG_DECIMAL_FIVE).build(),
                        ItemSalesOrder.builder().description("ITEM 2").amount(Constants.BIG_DECIMAL_TWO).unitaryValue(Constants.BIG_DECIMAL_FIVE).build()))
                .build();
        assertEquals(expected, response.getBody(),"Should return the order");
    }

    @Test
    @DisplayName("When order not found")
    void testFindNotFound() {
        when(repository.findById(anyString())).thenReturn(Optional.empty());
        ResponseEntity<SalesOrderResponse> response = service.find("123456");
        assertEquals(HttpStatus.NOT_FOUND, response.getStatusCode(), "Should return a NOT FOUND status code");
    }

    @Test
    @DisplayName("When find and order id invalid")
    void testFindIdInvalid() {
        when(repository.findById("123456")).thenReturn(order);
        assertThrows(IllegalArgumentException.class, () -> service.find("123456-N"),
                "Should throw a IllegalArgumentException");
    }

    @Test
    @DisplayName("When create a order")
    void testCreate() {
        when(repository.save(order.get())).thenReturn(order.get());
        SalesOrder payload = new SalesOrder("123456",
                Arrays.asList(ItemSalesOrder.builder().description("ITEM 1").amount(Constants.BIG_DECIMAL_TWO).unitaryValue(Constants.BIG_DECIMAL_FIVE).build(),
                        ItemSalesOrder.builder().description("ITEM 2").amount(Constants.BIG_DECIMAL_THREE).unitaryValue(Constants.BIG_DECIMAL_FIVE).build()));
        ResponseEntity<SalesOrderResponse> response = service.create(payload);
        assertEquals(HttpStatus.OK, response.getStatusCode(), "Should return a OK status code");
    }

    @Test
    @DisplayName("When order already exists")
    void testCreateExists() {
        when(repository.findById("123456")).thenReturn(order);
        SalesOrder payload = new SalesOrder("123456",
                Arrays.asList(ItemSalesOrder.builder().description("ITEM 1").amount(Constants.BIG_DECIMAL_TWO).unitaryValue(Constants.BIG_DECIMAL_FIVE).build(),
                        ItemSalesOrder.builder().description("ITEM 2").amount(Constants.BIG_DECIMAL_THREE).unitaryValue(Constants.BIG_DECIMAL_FIVE).build()));
        ResponseEntity<SalesOrderResponse> response = service.create(payload);
        assertEquals(HttpStatus.CONFLICT, response.getStatusCode(), "Should return a CONFLICT status code");
    }

    @Test
    @DisplayName("When create and order id invalid")
    void testCreateInvalid() {
        when(repository.findById("123456")).thenReturn(order);
        SalesOrder payload = new SalesOrder("123456-N",
                Arrays.asList(ItemSalesOrder.builder().description("ITEM 1").amount(Constants.BIG_DECIMAL_TWO).unitaryValue(Constants.BIG_DECIMAL_FIVE).build(),
                        ItemSalesOrder.builder().description("ITEM 2").amount(Constants.BIG_DECIMAL_THREE).unitaryValue(Constants.BIG_DECIMAL_FIVE).build()));
        assertThrows(IllegalArgumentException.class, () -> service.create(payload),
                "Should throw a IllegalArgumentException");
    }

    @Test
    @DisplayName("When create and payload is null")
    void testCreatePayloadNull() {
        assertThrows(IllegalArgumentException.class, () -> service.create(null),
                "Should throw a IllegalArgumentException");
    }

    @Test
    @DisplayName("When update a order")
    void testUpdate() {
        when(repository.findById("123456")).thenReturn(order);
        SalesOrder payload = new SalesOrder("123456",
                Arrays.asList(ItemSalesOrder.builder().description("ITEM 1").amount(Constants.BIG_DECIMAL_TWO).unitaryValue(Constants.BIG_DECIMAL_FIVE).build(),
                        ItemSalesOrder.builder().description("ITEM 2").amount(Constants.BIG_DECIMAL_THREE).unitaryValue(Constants.BIG_DECIMAL_FIVE).build()));
        ResponseEntity<SalesOrderResponse> response = service.update(payload);
        assertEquals(HttpStatus.OK, response.getStatusCode(), "Should return a OK status code");
    }

    @Test
    @DisplayName("When update order and non exists then should create")
    void testUpdateNonExists() {
        when(repository.findById("123456")).thenReturn(Optional.empty());
        SalesOrder payload = new SalesOrder("123456",
                Arrays.asList(ItemSalesOrder.builder().description("ITEM 1").amount(Constants.BIG_DECIMAL_TWO).unitaryValue(Constants.BIG_DECIMAL_FIVE).build(),
                        ItemSalesOrder.builder().description("ITEM 2").amount(Constants.BIG_DECIMAL_THREE).unitaryValue(Constants.BIG_DECIMAL_FIVE).build()));
        ResponseEntity<SalesOrderResponse> response = service.update(payload);
        assertEquals(HttpStatus.OK, response.getStatusCode(), "Should return a OK status code");
    }

    @Test
    @DisplayName("When update and order id invalid")
    void testUpdateInvalid() {
        when(repository.findById("123456")).thenReturn(order);
        SalesOrder payload = new SalesOrder("123456-N",
                Arrays.asList(ItemSalesOrder.builder().description("ITEM 1").amount(Constants.BIG_DECIMAL_TWO).unitaryValue(Constants.BIG_DECIMAL_FIVE).build(),
                        ItemSalesOrder.builder().description("ITEM 2").amount(Constants.BIG_DECIMAL_THREE).unitaryValue(Constants.BIG_DECIMAL_FIVE).build()));
        assertThrows(IllegalArgumentException.class, () -> service.update(payload),
                "Should throw a IllegalArgumentException");
    }

    @Test
    @DisplayName("When update and payload is null")
    void testUpdatePayloadNull() {
        assertThrows(IllegalArgumentException.class, () -> service.update(null),
                "Should throw a IllegalArgumentException");
    }

    @Test
    @DisplayName("When delete and order found")
    void testDelete() {
        when(repository.findById("123456")).thenReturn(order);
        ResponseEntity<HttpStatus> response = service.delete("123456");
        assertEquals(HttpStatus.OK, response.getStatusCode(), "Should return OK status code");
    }

    @Test
    @DisplayName("When delete and order not found")
    void testDeleteNotFound() {
        when(repository.findById("123456")).thenReturn(order);
        ResponseEntity<HttpStatus> response = service.delete("12345");
        assertEquals(HttpStatus.NOT_FOUND, response.getStatusCode(), "Should return NOT FOUND status code");
    }

    @Test
    @DisplayName("When delete and order id invalid")
    void testDeleteInvalid() {
        when(repository.findById("123456")).thenReturn(order);
        ResponseEntity<HttpStatus> response = service.delete("12345-N");
        assertEquals(HttpStatus.BAD_REQUEST, response.getStatusCode(), "Should return BAD REQUEST status code");
    }

}
