package com.mercadoeletronico.backendchallenge.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Modifying;
import org.springframework.data.jpa.repository.Query;
import org.springframework.data.repository.query.Param;
import org.springframework.transaction.annotation.Transactional;

import com.mercadoeletronico.backendchallenge.entity.Itens;


public interface ItemRepository extends JpaRepository<Itens, Integer> {

	List<Itens> findByPedidoId(Integer pedidoId);

	void deleteByPedidoId(Integer pedido);

	@Transactional
	@Modifying
	@Query(value = "UPDATE Tb_item u SET u.DESCRICAO = :descricao, u.PRECO_UNITARIO = :precoUnitario, u.QTD = :qtd  WHERE u.PEDIDO_ID = :pedidoId", nativeQuery = true)
	void updateItemQuery(@Param("pedidoId") Integer id, @Param("descricao") String descricao, @Param("precoUnitario") Double precoUnitario, @Param("qtd") Integer qtd);

}
