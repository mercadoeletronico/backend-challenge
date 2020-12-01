package com.mercadoeletronico.backendchallenge.entity;

import javax.persistence.Column;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.Table;

import com.fasterxml.jackson.annotation.JsonIgnore;

import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;
import lombok.ToString;

@Entity
@Getter
@Setter
//@Builder
@ToString
@NoArgsConstructor
@Table(name="TB_ITEM")
public class Itens {

	@Id
	@GeneratedValue(strategy=GenerationType.IDENTITY)
	@JsonIgnore
	@Column(name = "ID")
	private Integer id;
	@Column(name = "DESCRICAO")
	private String descricao;
	@Column(name = "PRECO_UNITARIO")
	private Double precoUnitario;
	@Column(name = "QTD")
	private Integer qtd;
	@JsonIgnore
	@Column(name = "PEDIDO_ID")
	private Integer pedidoId;
}
