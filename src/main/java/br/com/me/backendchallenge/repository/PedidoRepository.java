package br.com.me.backendchallenge.repository;

import br.com.me.backendchallenge.domain.Pedido;
import org.springframework.data.jpa.repository.JpaRepository;

public interface PedidoRepository extends JpaRepository<Pedido, Long> {
}
