package br.com.luizbsilva.api.validator;

import br.com.luizbsilva.api.model.payload.SalesOrder;
import br.com.luizbsilva.api.model.table.Orders;
import br.com.luizbsilva.api.util.StatusEnum;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.params.ParameterizedTest;
import org.junit.jupiter.params.provider.MethodSource;
import org.springframework.boot.test.context.SpringBootTest;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Stream;

import static org.junit.jupiter.api.Assertions.assertEquals;

@SpringBootTest
public class OrderNumberValidatorTest {

    SalesOrder payload;

    Orders entity;

    List<StatusEnum> status;

    ValidatorChain<SalesOrder, Orders> validator;

    static Stream<String> invalidValues() {
        return Stream.of("1234-N", "test_", "      ", "");
    }

    @BeforeEach
    void setUp() {
        payload = new SalesOrder("123");
        entity = null;
        status = new ArrayList<>();
        validator = new OrderNumberValidator();
    }

    @Test
    @DisplayName("When order id is OK")
    void testOrderIdIsOK() {
        assertEquals(status, validator.check(payload, entity, new ArrayList<>()),
                "Should return an empty array");
    }

    @ParameterizedTest
    @DisplayName("When order id is invalid")
    @MethodSource("invalidValues")
    void testOrderId(final String arg) {
        payload.setOrdered(arg);
        status.add(StatusEnum.INVALID_ORDER_NUMBER);
        assertEquals(status, validator.check(payload, entity, new ArrayList<>()),
                "Should return an array with [INVALID_ORDER_NUMBER]");
    }

    @Test
    @DisplayName("When payload is NULL")
    void testPayloadIsNull() {
        payload = null;
        status.add(StatusEnum.INVALID_ORDER_NUMBER);
        assertEquals(status, validator.check(payload, entity, new ArrayList<>()),
                "Should return an array with [INVALID_ORDER_NUMBER]");
    }

}
