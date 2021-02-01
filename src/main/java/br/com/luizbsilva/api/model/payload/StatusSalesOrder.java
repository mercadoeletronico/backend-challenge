package br.com.luizbsilva.api.model.payload;

import lombok.*;

import java.math.BigDecimal;

@Getter
@Setter
@Builder
@NoArgsConstructor
@AllArgsConstructor
public class StatusSalesOrder implements ISalesOrder {

    private String status;

    private BigDecimal approvedItems;

    private BigDecimal approvedValue;

    private String ordered;

}
