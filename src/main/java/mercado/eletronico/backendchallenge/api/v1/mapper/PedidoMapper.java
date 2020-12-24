package mercado.eletronico.backendchallenge.api.v1.mapper;

import mercado.eletronico.backendchallenge.api.v1.model.PedidoDTO;
import mercado.eletronico.backendchallenge.domain.Pedido;
import org.mapstruct.Mapper;
import org.mapstruct.Mapping;
import org.mapstruct.Mappings;
import org.mapstruct.factory.Mappers;

@Mapper
public interface PedidoMapper {

    PedidoMapper INSTANCE = Mappers.getMapper(PedidoMapper.class);

    @Mappings({
            @Mapping(source = "codigoPedido", target = "pedido"),
            @Mapping(source = "itens", target = "itens")})
    PedidoDTO pedidoToPedidoDTO(Pedido pedido);

    @Mappings({
            @Mapping(source = "pedido", target = "codigoPedido"),
            @Mapping(source = "itens", target = "itens")
    })
    Pedido pedidoDTOToPedido(PedidoDTO pedidoDTO);
}
