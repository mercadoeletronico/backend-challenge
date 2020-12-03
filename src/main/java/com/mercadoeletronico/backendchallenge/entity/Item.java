package com.mercadoeletronico.backendchallenge.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.Lob;
import javax.persistence.Table;

import org.springframework.transaction.annotation.Transactional;

import com.fasterxml.jackson.annotation.JsonIgnore;

import lombok.AllArgsConstructor;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

@Entity
@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Transactional
@Table(name="itens")
public class Item {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@Column(name = "id")
	@JsonIgnore
	private Long id;
	
	@Lob
	private String descricao;
	
	private Double precoUnitario;
	
	private Long qtd;
	
	@JoinColumn(name="pedidoId")
	@JsonIgnore
	private Long pedidoId;
	
	public Item (String descricao, Double precoUnitario, Long qtd, Long pedidoId) {
		this.descricao = descricao;
		this.precoUnitario = precoUnitario;
		this.qtd = qtd;
		this.pedidoId = pedidoId;
	}
	
}
