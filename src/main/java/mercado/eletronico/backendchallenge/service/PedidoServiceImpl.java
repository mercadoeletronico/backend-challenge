package mercado.eletronico.backendchallenge.service;

import mercado.eletronico.backendchallenge.api.v1.mapper.PedidoMapper;
import mercado.eletronico.backendchallenge.api.v1.model.BaseDTO;
import mercado.eletronico.backendchallenge.api.v1.model.PedidoDTO;
import mercado.eletronico.backendchallenge.api.v1.model.StatusDTO;
import mercado.eletronico.backendchallenge.api.v1.model.StatusUpdateDTO;
import mercado.eletronico.backendchallenge.domain.Item;
import mercado.eletronico.backendchallenge.domain.Pedido;
import mercado.eletronico.backendchallenge.domain.Status;
import mercado.eletronico.backendchallenge.manager.PedidoManager;
import mercado.eletronico.backendchallenge.repository.ItemRepository;
import mercado.eletronico.backendchallenge.repository.PedidoRepository;
import org.hibernate.service.spi.ServiceException;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.Collections;
import java.util.List;

@Service
public class PedidoServiceImpl implements PedidoService {

    private final PedidoRepository pedidoRepository;
    private final ItemRepository itemRepository;
    private final PedidoMapper pedidoMapper;

    public PedidoServiceImpl(PedidoRepository pedidoRepository, ItemRepository itemRepository, PedidoMapper pedidoMapper) {
        this.pedidoRepository = pedidoRepository;
        this.itemRepository = itemRepository;
        this.pedidoMapper = pedidoMapper;
    }

    @Override
    public BaseDTO criaNovoPedido(PedidoDTO pedidoDTO) {
        Pedido pedido = pedidoMapper.pedidoDTOToPedido(pedidoDTO);
        BaseDTO responseDTO;
        if (!isCodigoPedidoValido(pedido.getCodigoPedido())){
            responseDTO = montaStatusDTO(pedido.getCodigoPedido(), Status.CODIGO_PEDIDO_INVALIDO);
            return responseDTO;
        }
        if(pedidoRepository.existsByCodigoPedido(pedido.getCodigoPedido())){
            responseDTO = montaStatusDTO(pedido.getCodigoPedido(), Status.CODIGO_PEDIDO_JA_EXISTE);
            return responseDTO;
        }
        try {
            associaItensApedido(pedido);
        } catch (Exception e) {
            responseDTO = montaStatusDTO(pedido.getCodigoPedido(), Status.ITENS_INVALIDOS);
            return responseDTO;
        }

        Pedido pedidoSalvo = pedidoRepository.save(pedido);
        responseDTO = pedidoMapper.pedidoToPedidoDTO(pedidoSalvo);

        return responseDTO;
    }

    @Override
    public BaseDTO getPedido(String codigoPedido) {
        BaseDTO responseDTO;
        Pedido pedido = pedidoRepository.findByCodigoPedido(codigoPedido);
        if(pedido == null){
            responseDTO = montaStatusDTO(codigoPedido, Status.CODIGO_PEDIDO_INVALIDO);
            return responseDTO;
        }
        responseDTO = pedidoMapper.pedidoToPedidoDTO(pedido);
        return responseDTO;
    }

    @Override
    public BaseDTO atualizaStatus(StatusUpdateDTO statusUpdateDTO) {
        Pedido pedido = pedidoRepository.findByCodigoPedido(statusUpdateDTO.getPedido());
        StatusDTO statusDTO;
        if (pedido == null) {
            statusDTO = StatusDTO.builder()
                    .pedido(statusUpdateDTO.getPedido())
                    .status(Collections.singletonList(Status.CODIGO_PEDIDO_INVALIDO))
                    .build();
        } else {
            statusDTO = PedidoManager.updateStatusPedido(pedido, statusUpdateDTO);
        }
        return statusDTO;
    }

    @Override
    public BaseDTO editaPedido(PedidoDTO pedidoDTO) {
        Pedido pedido = pedidoRepository.findByCodigoPedido(pedidoDTO.getPedido());
        StatusDTO statusDTO;
        if (pedido == null){
            statusDTO = montaStatusDTO(pedidoDTO.getPedido(), Status.CODIGO_PEDIDO_INVALIDO);
            return statusDTO;
        }
        Long idPedido = pedido.getId();
        pedido = pedidoMapper.pedidoDTOToPedido(pedidoDTO);
        pedido.setId(idPedido);
        try {
            associaItensApedido(pedido);
            removeItensAntigos(pedido);
        } catch (Exception e) {
            statusDTO = montaStatusDTO(pedido.getCodigoPedido(), Status.ITENS_INVALIDOS);
            return statusDTO;
        }
        pedidoRepository.save(pedido);

        return pedidoDTO;
    }

    @Override
    public BaseDTO deletaPedido(PedidoDTO pedidoDTO) {
        StatusDTO statusDTO;
        Pedido pedido = pedidoRepository.findByCodigoPedido(pedidoDTO.getPedido());
        if (pedido == null) {
            statusDTO = montaStatusDTO(pedidoDTO.getPedido(), Status.CODIGO_PEDIDO_INVALIDO);
            return statusDTO;
        }
        pedidoRepository.delete(pedido);
        statusDTO = montaStatusDTO(pedidoDTO.getPedido(), Status.PEDIDO_DELETADO);
        return statusDTO;
    }

    private void removeItensAntigos(Pedido pedido) {
        List<Item> itensAntigos = itemRepository.findAllByPedido(pedido);
        itemRepository.deleteAll(itensAntigos);
    }

    private Boolean isCodigoPedidoValido(String codigoPedido) {
        if (codigoPedido == null || codigoPedido.isEmpty() || codigoPedido.isBlank()){
            return false;
        }
        return true;
    }

    private void associaItensApedido(Pedido pedido) {
        List<Item> itens = pedido.getItens();
        if (itens == null || itens.isEmpty()) {
            throw new ServiceException("Lista de Itens Nula ou Vazia.");
        }
        pedido.setItens(new ArrayList<>());
        for (Item item: itens) {
            validaItem(item);
            pedido.addItem(item);
        }
    }

    private StatusDTO montaStatusDTO(String codigoPedido, Status status) {
        return StatusDTO.builder()
                .pedido(codigoPedido)
                .status(Collections.singletonList(status))
                .build();
    }

    private void validaItem(Item item) {
        if (item.getDescricao() == null || item.getDescricao().isEmpty() || item.getDescricao().isBlank()){
            throw new ServiceException("Descrição de Item é inválida!");
        }
        if (item.getPrecoUnitario() == null || item.getPrecoUnitario().isNaN() || item.getPrecoUnitario() < 0) {
            throw new ServiceException("Preço de Item é inválido!");
        }
        if (item.getQtd() == null || item.getQtd() < 0 ) {
            throw new ServiceException("Quantidade de item é inválida!");
        }
    }
}
