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
public class StatusValidatorTest {

    StatusSalesOrder payload;

    Orders entity;

    List<StatusEnum> status;

    ValidatorChain<StatusSalesOrder, Orders> validator;

    @BeforeEach
    void init() {
        payload = StatusSalesOrder.builder().status("APROVADO").ordered("123").approvedValue(Constants.BIG_DECIMAL_TWENTY).approvedItems(Constants.BIG_DECIMAL_THREE).build();
        entity = null;
        status = new ArrayList<>();
        validator = new StatusValidator();
    }

    @Test
    @DisplayName("When status is APPROVED")
    void testApprovedStatus() {
        assertEquals(status, validator.check(payload, entity, new ArrayList<>()),
                "Should return an empty array");
    }

    @Test
    @DisplayName("When status is DISAPPROVED")
    void testDisapprovedStatus() {
        payload.setStatus("REPROVADO");
        status.add(StatusEnum.DISAPPROVED);
        assertEquals(status, validator.check(payload, entity, new ArrayList<>()),
                "Should return an array with [DISAPPROVED]");
    }

}
