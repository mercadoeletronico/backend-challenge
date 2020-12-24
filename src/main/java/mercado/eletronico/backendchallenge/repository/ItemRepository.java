package mercado.eletronico.backendchallenge.repository;

import mercado.eletronico.backendchallenge.domain.Item;
import mercado.eletronico.backendchallenge.domain.Pedido;
import org.springframework.data.repository.CrudRepository;

import java.util.List;

public interface ItemRepository extends CrudRepository<Item, Long> {

    List<Item> findAllByPedido(Pedido pedido);
}
