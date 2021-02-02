package br.com.mercadoeletronico.testbackend.service;

import br.com.mercadoeletronico.testbackend.dto.*;
import br.com.mercadoeletronico.testbackend.model.Order;
import br.com.mercadoeletronico.testbackend.repository.OrderRepository;
import lombok.AccessLevel;
import lombok.AllArgsConstructor;
import lombok.experimental.FieldDefaults;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;
import org.springframework.web.server.ResponseStatusException;
import reactor.core.publisher.Mono;

import java.util.ArrayList;
import java.util.Collections;
import java.util.stream.Collectors;

@Service
@AllArgsConstructor(onConstructor = @__(@Autowired))
@FieldDefaults(makeFinal = true, level = AccessLevel.PRIVATE)
public class OrderService {
    OrderRepository repository;

    public Mono<OrderDTO> getOrder(String idOrder){
        return repository.findByIdOrder(idOrder)
            .collectList()
            .flatMap(orders -> {
                if(orders.isEmpty()){
                    return Mono.error(new ResponseStatusException(HttpStatus.NOT_FOUND));
                }
                return Mono.just(
                    OrderDTO.builder()
                        .idOrder(idOrder)
                        .items(
                            orders.stream()
                                .map(Order::toDto)
                                .collect(Collectors.toList())
                        ).build()
                );
            });
    }


    public Mono<OrderDTO> save(OrderDTO order){
        if (order.getItems().isEmpty()){
            return Mono.error(new ResponseStatusException(HttpStatus.BAD_REQUEST));
        }
        var idOrder = order.getIdOrder();
        return repository.findByIdOrder(idOrder)
            .collectList()
            .flatMap(orders -> {
                if (orders.isEmpty()){
                    return repository.saveAll(order.toModel())
                        .collectList()
                        .map(ordersUpdated ->
                            OrderDTO.builder()
                                .idOrder(idOrder)
                                .items(
                                    ordersUpdated.stream()
                                        .map(Order::toDto)
                                        .collect(Collectors.toList())
                                ).build()
                        );
                }
                return Mono.error(new ResponseStatusException(HttpStatus.CONFLICT));
            });
    }

    public Mono<OrderDTO> delete(String idOrder){
        return getOrder(idOrder)
            .flatMap(order ->
                repository.deleteByIdOrder(idOrder)
                    .thenReturn(order)
            );
    }

    @Transactional
    public Mono<OrderDTO> update(String idOrder, OrderDTO order) {
        if (!idOrder.equals(order.getIdOrder())){
            return Mono.error(new ResponseStatusException(HttpStatus.BAD_REQUEST));
        }
        return delete(idOrder)
            .thenReturn(1)
            .flatMap(integer -> save(order));
    }

    public Mono<StatusResponseDTO> changeStatus(StatusDTO status) {
        var idOrder = status.getIdOrder();
        var builder = StatusResponseDTO.builder()
            .idOrder(idOrder.replaceAll("[\\D-]*", ""));
        if (idOrder.matches("[\\D-]*")){
            return Mono.just(
                 builder
                    .status(
                        Collections.singletonList(Status.CODIGO_PEDIDO_INVALIDO)
                    ).build()
            );
        }
        return getOrder(idOrder)
            .map(order -> {
                if (Status.REPROVADO.equals(status.getStatus())){
                    return builder.status(
                        Collections.singletonList(Status.REPROVADO)
                    ).build();
                }
                var price = order.getItems()
                    .stream()
                    .map(ProductDTO::getPrice)
                    .reduce(Integer::sum)
                    .orElse(0);
                var quantity = order.getItems()
                    .stream()
                    .map(ProductDTO::getQuantity)
                    .reduce(Integer::sum).orElse(0);
                var statuses = new ArrayList<Status>();
                if (status.getPrice() > price){
                    statuses.add(Status.APROVADO_VALOR_A_MAIOR);
                } else if(status.getPrice() < price) {
                    statuses.add(Status.APROVADO_VALOR_A_MENOR);
                }
                if (status.getItems() > quantity){
                    statuses.add(Status.APROVADO_QTD_A_MAIOR);
                } else if(status.getItems() < quantity) {
                    statuses.add(Status.APROVADO_QTD_A_MENOR);
                }
                if (statuses.isEmpty()){
                    statuses.add(Status.APROVADO);
                }
                return builder.status(statuses).build();
            });
    }
}
