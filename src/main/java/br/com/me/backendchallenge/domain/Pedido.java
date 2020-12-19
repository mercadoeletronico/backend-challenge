package br.com.me.backendchallenge.domain;

import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.Getter;
import lombok.Setter;

import javax.persistence.*;
import java.util.List;

@Getter
@Setter
@Entity
@Table(name = "TB_PEDIDO")
public class Pedido {
    @Id
    @Column(name = "ID")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @OneToMany(mappedBy = "pedido")
    private List<Item> itens;

    @JsonIgnore
    @OneToOne(mappedBy = "pedido")
    private StatusPedido status;
}