package mercado.eletronico.backendchallenge.domain;


import javax.persistence.*;
import java.util.ArrayList;
import java.util.List;

@Entity
public class Pedido {


    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @Column(name = "codigoPedido", unique = true)
    private String codigoPedido;

    @OneToMany(cascade = CascadeType.ALL, mappedBy = "pedido")
    private List<Item> itens = new ArrayList<>();

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getCodigoPedido() {
        return codigoPedido;
    }

    public void setCodigoPedido(String numeroPedido) {
        this.codigoPedido = numeroPedido;
    }

    public List<Item> getItens() {
        return itens;
    }

    public void setItens(List<Item> items) {
        this.itens = items;
    }

    public Pedido addItem(Item item) {
        item.setPedido(this);
        this.itens.add(item);
        return this;
    }
}
