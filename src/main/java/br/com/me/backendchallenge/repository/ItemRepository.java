package br.com.me.backendchallenge.repository;

import br.com.me.backendchallenge.domain.Item;
import org.springframework.data.jpa.repository.JpaRepository;

public interface ItemRepository extends JpaRepository<Item, Long> {
}
