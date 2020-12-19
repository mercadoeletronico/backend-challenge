package br.com.me.backendchallenge.service;

import br.com.me.backendchallenge.dto.StatusAlteradoDTO;
import br.com.me.backendchallenge.dto.StatusAlterarDTO;
import br.com.me.backendchallenge.enums.Status;
import br.com.me.backendchallenge.repository.PedidoRepository;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public class PedidoService {
    private final PedidoRepository pedidoRepository;

    public PedidoService(PedidoRepository pedidoRepository) {
        this.pedidoRepository = pedidoRepository;
    }

    public StatusAlteradoDTO alterarStatus(StatusAlterarDTO novoStatus) {
        final var pedido = this.pedidoRepository.findById(novoStatus.getPedido());
        final List<Status> status;
        if (pedido.isPresent()) {
            status = pedido.get().alterarStatus(novoStatus);
        } else {
            status = List.of(Status.CODIGO_PEDIDO_INVALIDO);
        }
        return new StatusAlteradoDTO(novoStatus.getPedido(), status);
    }
}