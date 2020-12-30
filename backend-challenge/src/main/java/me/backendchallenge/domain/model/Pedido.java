package me.backendchallenge.domain.model;

import java.util.ArrayList;
import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.OneToMany;

import com.fasterxml.jackson.annotation.JsonIgnoreProperties;

@Entity
public class Pedido {

	@Id
	@GeneratedValue(strategy = GenerationType.IDENTITY)
	private Long id;

	@Column(name = "pedido", nullable = false, length = 100, unique = true)
	private String pedido;

	@JsonIgnoreProperties("pedido")
	@OneToMany(mappedBy = "pedido", cascade = CascadeType.ALL, orphanRemoval = true)
	private List<Item> itens = new ArrayList<>();

	public Pedido() {

	}

	public Pedido(Pedido pedido) {
		this.id = pedido.id;
		this.pedido = pedido.pedido;
		this.itens.addAll(pedido.getItens());
	}

	public Long getId() {
		return id;
	}

	public void setId(Long id) {
		this.id = id;
	}

	public String getPedido() {
		return pedido;
	}

	public void setPedido(String codigo) {
		this.pedido = codigo;
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
