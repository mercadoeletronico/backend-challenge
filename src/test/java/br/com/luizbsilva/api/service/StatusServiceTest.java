package br.com.luizbsilva.api.service;

import br.com.luizbsilva.api.model.payload.StatusSalesOrder;
import br.com.luizbsilva.api.model.response.StatusResponse;
import br.com.luizbsilva.api.model.table.Orders;
import br.com.luizbsilva.api.repository.OrdersRepository;
import br.com.luizbsilva.api.util.Constants;
import br.com.luizbsilva.api.util.StatusEnum;
import org.junit.jupiter.api.AfterEach;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;
import org.mockito.InjectMocks;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.ResponseEntity;

import java.util.Arrays;
import java.util.Optional;

import static org.junit.jupiter.api.Assertions.assertEquals;
import static org.mockito.ArgumentMatchers.anyString;
import static org.mockito.Mockito.when;

@SpringBootTest
public class StatusServiceTest {

    @InjectMocks
    StatusService service;

    @Mock
    OrdersRepository repository;

    Optional<Orders> order;

    StatusSalesOrder payload;

    AutoCloseable closeable;

    @BeforeEach
    void init() {
        closeable = MockitoAnnotations.openMocks(this);

        order = Optional.of(Orders.builder().id("123456").totalPrice(Constants.BIG_DECIMAL_TWENTY).totalQuantity(Constants.BIG_DECIMAL_THREE).build());
        payload = StatusSalesOrder.builder().status("APROVADO").ordered("123456").approvedValue(Constants.BIG_DECIMAL_TWENTY).approvedItems(Constants.BIG_DECIMAL_THREE)
                .build();
    }

    @AfterEach
    void end() throws Exception {
        closeable.close();
    }

    @Test
    @DisplayName("When totalQuantity, totalPrice are same than order and status APROVADO")
    void testApproved() {
        when(repository.findById("123456")).thenReturn(order);
        ResponseEntity<StatusResponse> response = service.updateStatus(payload);

        StatusResponse expected = StatusResponse.builder().ordered("123456")
                .status(Arrays.asList(StatusEnum.APPROVED.getMessage())).build();

        assertEquals(expected, response.getBody(), "Should have status ".concat(StatusEnum.APPROVED.getMessage()));
    }

    @Test
    @DisplayName("When totalPrice is greater and status APROVADO")
    void testPriceGreater() {
        when(repository.findById("123456")).thenReturn(order);
        payload.setApprovedValue(Constants.BIG_DECIMAL_TWENTY_ONE);

        ResponseEntity<StatusResponse> response = service.updateStatus(payload);

        StatusResponse expected = StatusResponse.builder().ordered("123456")
                .status(Arrays.asList(StatusEnum.APPROVED_GREATER_PRICE.getMessage())).build();

        assertEquals(expected, response.getBody(),
                "Should have status ".concat(StatusEnum.APPROVED_GREATER_PRICE.getMessage()));
    }

    @Test
    @DisplayName("When totalPrice is lower and status APROVADO")
    void testPriceLower() {
        when(repository.findById("123456")).thenReturn(order);
        payload.setApprovedValue(Constants.BIG_DECIMAL_NINETEEN);

        ResponseEntity<StatusResponse> response = service.updateStatus(payload);

        StatusResponse expected = StatusResponse.builder().ordered("123456")
                .status(Arrays.asList(StatusEnum.APPROVED_MINOR_PRICE.getMessage())).build();

        assertEquals(expected, response.getBody(),
                "Should have status ".concat(StatusEnum.APPROVED_MINOR_PRICE.getMessage()));
    }

    @Test
    @DisplayName("When totalQuantity is greater and status APROVADO")
    void testQuantityGreater() {
        when(repository.findById("123456")).thenReturn(order);
        payload.setApprovedItems(Constants.BIG_DECIMAL_FOR);

        ResponseEntity<StatusResponse> response = service.updateStatus(payload);

        StatusResponse expected = StatusResponse.builder().ordered("123456")
                .status(Arrays.asList(StatusEnum.APPROVED_GREATER_QUANTITY.getMessage())).build();

        assertEquals(expected, response.getBody(),
                "Should have status ".concat(StatusEnum.APPROVED_GREATER_QUANTITY.getMessage()));
    }

    @Test
    @DisplayName("When totalQuantity is lower and status APROVADO")
    void testQuantityLower() {
        when(repository.findById("123456")).thenReturn(order);

        payload.setApprovedItems(Constants.BIG_DECIMAL_TWO);

        ResponseEntity<StatusResponse> response = service.updateStatus(payload);

        StatusResponse expected = StatusResponse.builder().ordered("123456")
                .status(Arrays.asList(StatusEnum.APPROVED_MINOR_QUANTITY.getMessage())).build();

        assertEquals(expected, response.getBody(),
                "Should have status ".concat(StatusEnum.APPROVED_MINOR_QUANTITY.getMessage()));
    }

    @Test
    @DisplayName("When totalQuantity, totalPrice are greater and status APROVADO")
    void testQuantityAndPriceGreater() {
        when(repository.findById("123456")).thenReturn(order);

        payload.setApprovedItems(Constants.BIG_DECIMAL_FOR);
        payload.setApprovedValue(Constants.BIG_DECIMAL_TWENTY_ONE);

        ResponseEntity<StatusResponse> response = service.updateStatus(payload);

        StatusResponse expected = StatusResponse.builder().ordered("123456")
                .status(Arrays.asList(StatusEnum.APPROVED_GREATER_QUANTITY.getMessage(),
                        StatusEnum.APPROVED_GREATER_PRICE.getMessage()))
                .build();

        assertEquals(expected, response.getBody(),
                "Should have status ".concat(StatusEnum.APPROVED_GREATER_QUANTITY.getMessage()).concat(" and ")
                        .concat(StatusEnum.APPROVED_GREATER_PRICE.getMessage()));
    }

    @Test
    @DisplayName("When totalQuantity, totalPrice are lower and status APROVADO")
    void testQuantityAndPriceLower() {
        when(repository.findById("123456")).thenReturn(order);
        payload.setApprovedItems(Constants.BIG_DECIMAL_TWO);
        payload.setApprovedValue(Constants.BIG_DECIMAL_NINETEEN);

        ResponseEntity<StatusResponse> response = service.updateStatus(payload);

        StatusResponse expected = StatusResponse.builder().ordered("123456").status(Arrays
                .asList(StatusEnum.APPROVED_MINOR_QUANTITY.getMessage(), StatusEnum.APPROVED_MINOR_PRICE.getMessage()))
                .build();

        assertEquals(expected, response.getBody(),
                "Should have status ".concat(StatusEnum.APPROVED_MINOR_QUANTITY.getMessage()).concat(" and ")
                        .concat(StatusEnum.APPROVED_MINOR_PRICE.getMessage()));
    }

    @Test
    @DisplayName("When totalQuantity is lower, totalPrice is greater and status APROVADO")
    void testQuantityLowerAndPriceGreater() {
        when(repository.findById("123456")).thenReturn(order);
        payload.setApprovedItems(Constants.BIG_DECIMAL_TWO);
        payload.setApprovedValue(Constants.BIG_DECIMAL_TWENTY_ONE);

        ResponseEntity<StatusResponse> response = service.updateStatus(payload);
        StatusResponse expected = StatusResponse.builder().ordered("123456")
                .status(Arrays.asList(StatusEnum.APPROVED_MINOR_QUANTITY.getMessage(),
                        StatusEnum.APPROVED_GREATER_PRICE.getMessage()))
                .build();

        assertEquals(expected, response.getBody(),
                "Should have status ".concat(StatusEnum.APPROVED_MINOR_QUANTITY.getMessage()).concat(" and ")
                        .concat(StatusEnum.APPROVED_GREATER_PRICE.getMessage()));
    }

    @Test
    @DisplayName("When totalQuantity is greater, totalPrice is lower and status APROVADO")
    void testQuantityGreaterAndPriceLower() {
        when(repository.findById("123456")).thenReturn(order);
        payload.setApprovedItems(Constants.BIG_DECIMAL_FOR);
        payload.setApprovedValue(Constants.BIG_DECIMAL_NINETEEN);

        ResponseEntity<StatusResponse> response = service.updateStatus(payload);
        StatusResponse expected = StatusResponse.builder().ordered("123456")
                .status(Arrays.asList(StatusEnum.APPROVED_GREATER_QUANTITY.getMessage(),
                        StatusEnum.APPROVED_MINOR_PRICE.getMessage()))
                .build();

        assertEquals(expected, response.getBody(),
                "Should have status ".concat(StatusEnum.APPROVED_GREATER_QUANTITY.getMessage()).concat(" and ")
                        .concat(StatusEnum.APPROVED_MINOR_PRICE.getMessage()));
    }

    @Test
    @DisplayName("When status is REPROVADO")
    void testDisapprove() {
        when(repository.findById("123456")).thenReturn(order);
        payload.setStatus(StatusEnum.DISAPPROVED.getMessage());
        ResponseEntity<StatusResponse> response = service.updateStatus(payload);

        StatusResponse expected = StatusResponse.builder().ordered("123456")
                .status(Arrays.asList(StatusEnum.DISAPPROVED.getMessage())).build();

        assertEquals(expected, response.getBody(), "Should have status ".concat(StatusEnum.DISAPPROVED.getMessage()));
    }

    @Test
    @DisplayName("When is a invalid order id")
    void testInvalidId() {
        when(repository.findById(anyString())).thenReturn(order);
        payload.setOrdered("123456-N");

        ResponseEntity<StatusResponse> response = service.updateStatus(payload);

        StatusResponse expected = StatusResponse.builder().ordered("123456-N")
                .status(Arrays.asList(StatusEnum.INVALID_ORDER_NUMBER.getMessage())).build();

        assertEquals(expected, response.getBody(),
                "Should have status ".concat(StatusEnum.INVALID_ORDER_NUMBER.getMessage()));
    }

    @Test
    @DisplayName("When not found order")
    void testNotFoundOrder() {
        when(repository.findById("123456")).thenReturn(order);

        payload.setOrdered("12345");
        ResponseEntity<StatusResponse> response = service.updateStatus(payload);

        StatusResponse expected = StatusResponse.builder().ordered("12345")
                .status(Arrays.asList(StatusEnum.INVALID_ORDER_NUMBER.getMessage())).build();

        assertEquals(expected, response.getBody(),
                "Should have status ".concat(StatusEnum.INVALID_ORDER_NUMBER.getMessage()));
    }

}
