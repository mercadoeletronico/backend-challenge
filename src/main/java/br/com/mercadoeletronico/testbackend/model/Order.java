package br.com.mercadoeletronico.testbackend.model;

import br.com.mercadoeletronico.testbackend.dto.ProductDTO;
import lombok.AccessLevel;
import lombok.Builder;
import lombok.experimental.FieldDefaults;
import org.springframework.data.annotation.Id;
import org.springframework.data.relational.core.mapping.Table;

@Builder
@FieldDefaults(makeFinal = true, level = AccessLevel.PRIVATE)
@Table("orders")
public class Order {
    @Id
    Long id;
    String idOrder;
    String description;
    Integer price;
    Integer quantity;

    public ProductDTO toDto(){
        return ProductDTO.builder()
            .description(description)
            .price(price)
            .quantity(quantity)
            .build();
    }
}
