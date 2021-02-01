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
public class PriceValidatorTest {

    StatusSalesOrder payload;

    Orders entity;

    List<StatusEnum> status;

    ValidatorChain<StatusSalesOrder, Orders> validator;

    @BeforeEach
    void setUp() {
        payload = StatusSalesOrder.builder().status("APROVADO").ordered("123").approvedValue(Constants.BIG_DECIMAL_TWENTY).approvedItems(Constants.BIG_DECIMAL_THREE).build();
        entity = Orders.builder().id("123").totalPrice(Constants.BIG_DECIMAL_TWENTY).totalQuantity(Constants.BIG_DECIMAL_THREE).build();
        status = new ArrayList<>();
        validator = new PriceValidator();
    }

    @Test
    @DisplayName("When prices are same")
    void testSamePrice() {
        assertEquals(status, validator.check(payload, entity, new ArrayList<>()),
                "Should return an empty array");
    }

    @Test
    @DisplayName("When one prices is greater")
    void testGreaterPrice() {
        payload.setApprovedValue(Constants.BIG_DECIMAL_TWENTY_ONE);
        status.add(StatusEnum.APPROVED_GREATER_PRICE);

        assertEquals(status, validator.check(payload, entity, new ArrayList<>()),
                "Should return an array with [APPROVED_GREATER_PRICE]");
    }

    @Test
    @DisplayName("When one price is lower")
    void testLowerPrice() {
        payload.setApprovedValue(Constants.BIG_DECIMAL_NINETEEN);
        status.add(StatusEnum.APPROVED_MINOR_PRICE);
        assertEquals(status, validator.check(payload, entity, new ArrayList<>()),
                "Should return an array with [APPROVED_MINOR_PRICE]");
    }

}
