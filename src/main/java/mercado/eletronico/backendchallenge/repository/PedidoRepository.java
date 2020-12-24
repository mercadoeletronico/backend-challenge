package mercado.eletronico.backendchallenge.repository;

import mercado.eletronico.backendchallenge.domain.Pedido;
import org.springframework.data.jpa.repository.JpaRepository;

public interface PedidoRepository extends JpaRepository<Pedido, Long> {

    Boolean existsByCodigoPedido(String codigoPedido);

    Pedido findByCodigoPedido(String codigo);
}
