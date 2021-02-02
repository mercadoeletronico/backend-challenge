package br.com.mercadoeletronico.testbackend.repository;

import br.com.mercadoeletronico.testbackend.model.Order;
import org.springframework.data.repository.reactive.ReactiveCrudRepository;
import org.springframework.stereotype.Repository;
import reactor.core.publisher.Flux;
import reactor.core.publisher.Mono;

@Repository
public interface OrderRepository extends ReactiveCrudRepository<Order, Long> {
    Flux<Order> findByIdOrder(String idOrder);
    Mono<Void> deleteByIdOrder(String idOrder);
}
