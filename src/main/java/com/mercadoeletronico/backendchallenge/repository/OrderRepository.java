package com.mercadoeletronico.backendchallenge.repository;

import org.springframework.data.jpa.repository.JpaRepository;

import com.mercadoeletronico.backendchallenge.entity.Orders;

public interface OrderRepository extends JpaRepository<Orders, Integer>{

	Orders findByPedido(String pedido);
		
}
