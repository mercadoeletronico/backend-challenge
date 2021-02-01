package br.com.luizbsilva.api.model.table;

import lombok.*;

import javax.persistence.*;
import java.math.BigDecimal;

@Builder
@NoArgsConstructor
@AllArgsConstructor
@EqualsAndHashCode(exclude = { "order" })
@Entity
@Table(name = "order_items")
public class OrderItems implements IEntity {

    @Getter
    @Setter
    @Id
    @SequenceGenerator(name = "order_items_sequence", sequenceName = "order_items_seq", initialValue = 1, allocationSize = 100)
    @GeneratedValue(generator = "order_items_sequence")
    private Long id;

    @Getter
    @Setter
    @Column(name = "quantity")
    private BigDecimal quantity;

    @Getter
    @Setter
    @Column(name = "unit_price")
    private BigDecimal unitPrice;

    @Getter
    @Setter
    @ManyToOne(cascade = { CascadeType.PERSIST, CascadeType.REFRESH, CascadeType.DETACH, CascadeType.REMOVE })
    @JoinColumn(name = "orders_id")
    private Orders order;

    @Getter
    @Setter
    @OneToOne(cascade = CascadeType.ALL)
    @JoinColumn(name = "item_id")
    private Items item;

}
