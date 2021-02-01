package br.com.luizbsilva.api.validator;

import br.com.luizbsilva.api.model.payload.StatusSalesOrder;
import br.com.luizbsilva.api.model.table.Orders;
import br.com.luizbsilva.api.util.Constants;
import br.com.luizbsilva.api.util.StatusEnum;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.assertEquals;

@SpringBootTest
public class QuantityValidatorTest {

    StatusSalesOrder payload;

    Orders entity;

    List<StatusEnum> status;

    ValidatorChain<StatusSalesOrder, Orders> validator;

    @BeforeEach
    void init() {
        payload = StatusSalesOrder.builder().status("APROVADO").ordered("123").approvedValue(Constants.BIG_DECIMAL_TWENTY).approvedItems(Constants.BIG_DECIMAL_THIRTEEN).build();
        entity = Orders.builder().id("123").totalPrice(Constants.BIG_DECIMAL_TWENTY).totalQuantity(Constants.BIG_DECIMAL_THIRTEEN).build();
        status = new ArrayList<>();
        validator = new QuantityValidator();
    }

    @Test
    @DisplayName("When quantities are same")
    void testSameQuantity() {
        assertEquals(status, validator.check(payload, entity, new ArrayList<>()),
                "Should return an empty array");
    }

    @Test
    @DisplayName("When one quantity is greater")
    void testGreaterQuantity() {
        payload.setApprovedItems(Constants.BIG_DECIMAL_FOR);
        status.add(StatusEnum.APPROVED_GREATER_QUANTITY);
        assertEquals(status, validator.check(payload, entity, new ArrayList<>()),
                "Should return an array with [APPROVED_GREATER_QUANTITY]");
    }

    @Test
    @DisplayName("When one quantity is lower")
    void testLowerQuantity() {
        payload.setApprovedItems(Constants.BIG_DECIMAL_TWO);
        status.add(StatusEnum.APPROVED_MINOR_QUANTITY);
        assertEquals(status, validator.check(payload, entity, new ArrayList<>()),
                "Should return an array with [APPROVED_MINOR_QUANTITY]");
    }

}
