package com.mercadoeletronico.backendchallenge.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.mercadoeletronico.backendchallenge.entity.Order;

@Repository
public interface OrderRepository extends JpaRepository<Order, Long>{

	Order findByPedido(String pedido);
		
}
