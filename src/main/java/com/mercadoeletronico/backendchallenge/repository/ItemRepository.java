package com.mercadoeletronico.backendchallenge.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.mercadoeletronico.backendchallenge.entity.Item;

@Repository
public interface ItemRepository extends JpaRepository<Item, Long> {

	List<Item> findByPedidoId(Long pedidoId);
	
	void deleteByPedidoId(Long pedido);
	
}
