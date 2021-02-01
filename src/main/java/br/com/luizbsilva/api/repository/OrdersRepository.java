package br.com.luizbsilva.api.repository;

import br.com.luizbsilva.api.model.table.Orders;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface OrdersRepository extends JpaRepository<Orders, String> {

}
