package br.com.me.backendchallenge.domain;

import br.com.me.backendchallenge.enums.Status;
import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.Getter;
import lombok.Setter;

import javax.persistence.*;
import java.math.BigDecimal;

@Getter
@Setter
@Entity
@Table(name = "TB_STATUS_PEDIDO")
public class StatusPedido {
    @Id
    @Column(name = "ID")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @JsonIgnore
    @OneToOne
    private Pedido pedido;

    private Status status;
    private Long itensAprovados;
    private BigDecimal valorAprovado;
}
