package me.backendchallenge.domain.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import me.backendchallenge.domain.exception.PedidoNaoEncontradoException;
import me.backendchallenge.domain.model.Item;
import me.backendchallenge.domain.model.Pedido;
import me.backendchallenge.domain.model.StatusEnum;
import me.backendchallenge.domain.model.StatusRequest;
import me.backendchallenge.domain.model.StatusResponse;
import me.backendchallenge.domain.repository.StatusRepository;

@Service
public class StatusService {
	private StatusRepository statusRepository;

	@Autowired
	public StatusService(StatusRepository statusRepository) {
		this.statusRepository = statusRepository;
	}

	public StatusResponse verificarStatus(StatusRequest statusRequest) {
		Pedido pedido;
		List<StatusEnum> listStatus = new ArrayList<>();
		try {
			pedido = FindOrFail(statusRequest.getPedido());

		} catch (PedidoNaoEncontradoException e) {

			listStatus.add(StatusEnum.CODIGO_PEDIDO_INVALIDO);
			return new StatusResponse(statusRequest.getPedido(), listStatus);
		}

		if (statusRequest.getStatus().equals(StatusEnum.APROVADO.toString())) {
			Integer quantidadeTotal = 0;
			Double valorTotal = 0.0;

			for (Item item : pedido.getItens()) {
				quantidadeTotal += item.getQtd();
				valorTotal += (item.getPrecoUnitario() * item.getQtd());
			}

			StatusEnum quantidadeStatus = verificarQuantidadeStatus(statusRequest.getItensAprovados(), quantidadeTotal);
			StatusEnum valorStatus = verificarValorStatus(statusRequest.getValorAprovado(), valorTotal);

			if ((valorStatus.equals(StatusEnum.APROVADO)) && quantidadeStatus.equals(StatusEnum.APROVADO))
				listStatus.add(StatusEnum.APROVADO);

			if (!valorStatus.equals(StatusEnum.APROVADO))
				listStatus.add(valorStatus);

			if (!quantidadeStatus.equals(StatusEnum.APROVADO))
				listStatus.add(quantidadeStatus);

			return new StatusResponse(statusRequest.getPedido(), listStatus);

		} else if (statusRequest.getStatus().equals(StatusEnum.REPROVADO.toString())) {
			listStatus.add(StatusEnum.REPROVADO);

			return new StatusResponse(statusRequest.getPedido(), listStatus);
		}

		listStatus.add(StatusEnum.STATUS_INVALIDO);
		return new StatusResponse(statusRequest.getPedido(), listStatus);
	}

	private Pedido FindOrFail(String pedido) {
		List<Pedido> pedidos = statusRepository.findByPedido(pedido);

		if (pedidos.size() > 0)
			return pedidos.get(0);

		throw new PedidoNaoEncontradoException("Pedido não encontrado");

	}
	
	private StatusEnum verificarQuantidadeStatus(Integer quantidadeRequest, Integer quantidadePedido) {
		if (quantidadeRequest > quantidadePedido)
			return StatusEnum.APROVADO_QTD_A_MAIOR;
		
		if (quantidadeRequest < quantidadePedido)
			return StatusEnum.APROVADO_QTD_A_MENOR;
		
		return StatusEnum.APROVADO;
	}
	
	private StatusEnum verificarValorStatus(Double valorRequest, Double valorPedido) {
		if (valorRequest > valorPedido)
			return StatusEnum.APROVADO_VALOR_A_MAIOR;
		
		if (valorRequest < valorPedido)
			return StatusEnum.APROVADO_VALOR_A_MENOR;
		
		return StatusEnum.APROVADO;
	}

}
