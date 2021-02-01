package br.com.luizbsilva.api.service;

import br.com.luizbsilva.api.model.table.Orders;

import java.util.List;
import java.util.Optional;

public abstract class Service<T, E> {

    protected abstract List<String> validate(T payload, E entity);

    protected abstract Optional<Orders> findOrder(String id) throws IllegalArgumentException;

}
