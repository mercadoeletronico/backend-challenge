package me.backendchallenge.domain.repository;

import java.util.List;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import me.backendchallenge.domain.model.Pedido;

@Repository
public interface StatusRepository extends JpaRepository<Pedido, Long> {
	public List<Pedido> findByPedido(String pedido);
}
