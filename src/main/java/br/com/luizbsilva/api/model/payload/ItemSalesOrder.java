package br.com.luizbsilva.api.model.payload;

import lombok.*;

import java.math.BigDecimal;

@Getter
@Setter
@Builder
@NoArgsConstructor
@AllArgsConstructor
@EqualsAndHashCode
public class ItemSalesOrder implements ISalesOrder {

    private String description;

    private BigDecimal unitaryValue;

    private BigDecimal amount;

}
