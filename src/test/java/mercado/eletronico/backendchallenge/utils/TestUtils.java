package mercado.eletronico.backendchallenge.utils;

import mercado.eletronico.backendchallenge.api.v1.mapper.PedidoMapper;
import mercado.eletronico.backendchallenge.api.v1.model.ItemDTO;
import mercado.eletronico.backendchallenge.api.v1.model.PedidoDTO;
import mercado.eletronico.backendchallenge.api.v1.model.StatusUpdateDTO;
import mercado.eletronico.backendchallenge.domain.Item;
import mercado.eletronico.backendchallenge.domain.Pedido;
import mercado.eletronico.backendchallenge.domain.Status;

import java.util.ArrayList;
import java.util.List;

public class TestUtils {

    public static PedidoMapper pedidoMapper = PedidoMapper.INSTANCE;
    public static String NUMERO_PEDIDO = "123456";
    public static final Long ID_PEDIDO = 1L;

    public static PedidoDTO montaPedidoDTO() {
        List<ItemDTO> itens = new ArrayList<>();
        itens.add(montaItemDTO("Item 1", 10.0, 6));
        itens.add(montaItemDTO("Item 2", 25.0, 4));
        PedidoDTO pedidoDTO = new PedidoDTO();
        pedidoDTO.setPedido(NUMERO_PEDIDO);
        pedidoDTO.setItens(itens);
        return pedidoDTO;
    }

    public static ItemDTO montaItemDTO(String descricao, Double precoUnitario, Integer qtd) {
        ItemDTO itemDTO = new ItemDTO();
        itemDTO.setDescricao(descricao);
        itemDTO.setPrecoUnitario(precoUnitario);
        itemDTO.setQtd(qtd);
        return itemDTO;
    }

    public static Pedido montaPedido() {
        PedidoDTO pedidoDTO = montaPedidoDTO();
        Pedido pedido = pedidoMapper.pedidoDTOToPedido(pedidoDTO);
        List<Item> itens = pedido.getItens();
        pedido.setItens(new ArrayList<>());
        itens.stream().forEach(item -> pedido.addItem(item));
        return pedido;
    }

    public static StatusUpdateDTO montaStatusUpdateDTO() {
        StatusUpdateDTO statusUpdateDTO = new StatusUpdateDTO();
        statusUpdateDTO.setStatus(Status.APROVADO.name());
        statusUpdateDTO.setPedido(NUMERO_PEDIDO);
        statusUpdateDTO.setItensAprovados(2);
        statusUpdateDTO.setValorAprovado(160.0);
        return statusUpdateDTO;
    }
}
