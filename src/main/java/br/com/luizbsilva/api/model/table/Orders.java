package br.com.luizbsilva.api.model.table;

import lombok.*;

import javax.persistence.*;
import java.math.BigDecimal;
import java.util.Date;
import java.util.List;

@Getter
@Setter
@Builder
@NoArgsConstructor
@AllArgsConstructor
@EqualsAndHashCode
@Entity
@Table(name = "orders")
public class Orders implements IEntity {

    @Id
    private String id;

    @Column(name = "status")
    private String status;

    @Column(name = "total_price")
    private BigDecimal totalPrice;

    @Column(name = "total_quantity")
    private BigDecimal totalQuantity;

    @OneToMany(cascade = CascadeType.ALL)
    @JoinColumn(name = "orders_id")
    private List<OrderItems> items;

    @Column(name = "create_at")
    private Date createdAt;

    @Column(name = "modified_at")
    private Date modifiedAt;

    @PrePersist
    void createdAt() {
        this.createdAt = new Date();
    }

    @PreUpdate
    void modifiedAt() {
        this.modifiedAt = new Date();
    }

}
