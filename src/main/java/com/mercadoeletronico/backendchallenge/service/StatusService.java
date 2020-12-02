package com.mercadoeletronico.backendchallenge.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.mercadoeletronico.backendchallenge.dto.StatusRequestDTO;
import com.mercadoeletronico.backendchallenge.dto.StatusResponseDTO;
import com.mercadoeletronico.backendchallenge.entity.Item;
import com.mercadoeletronico.backendchallenge.entity.Order;
import com.mercadoeletronico.backendchallenge.enums.StatusEnum;
import com.mercadoeletronico.backendchallenge.repository.ItemRepository;
import com.mercadoeletronico.backendchallenge.repository.OrderRepository;

@Service
public class StatusService {

	@Autowired
	private OrderRepository orderRepository;

	@Autowired
	private ItemRepository itemRepository;

	public StatusResponseDTO validateStatus(StatusRequestDTO request) {

		StatusResponseDTO response = new StatusResponseDTO();

		List<String> statusResponse = new ArrayList<String>();
		
		String pedido = request.getPedido();
		String status = request.getStatus();
		Long itensAprovados = request.getItensAprovados();
		Double valorAprovado = request.getValorAprovado();
		
		Long qtdItensPedido = new Long(0);
		Double valorTotalPedido = 0.0;

		Long pedidoId = new Long(0);
		List<Item> itensPedido = new ArrayList<Item>();
		
		Order orderResult = new Order();
		orderResult = orderRepository.findByPedido(pedido);
				
		if (orderResult == null) {
			statusResponse.add(StatusEnum.CODIGO_PEDIDO_INVALIDO.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		} else {
			pedidoId = orderResult.getId();
			itensPedido = itemRepository.findByPedidoId(pedidoId);
		}
				
		for(int i = 0; i < itensPedido.size(); i++) {
			qtdItensPedido = qtdItensPedido + itensPedido.get(i).getQtd();
			valorTotalPedido = valorTotalPedido + (itensPedido.get(i).getQtd() * itensPedido.get(i).getPrecoUnitario());
		}
		
		if (orderResult != null && status.equalsIgnoreCase("REPROVADO")) {
			statusResponse.add(StatusEnum.REPROVADO.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);

		}

		if (orderResult != null && itensAprovados.equals(qtdItensPedido) && valorAprovado.equals(valorTotalPedido)
				&& status.equalsIgnoreCase("APROVADO")) {
			statusResponse.add(StatusEnum.APROVADO.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		}
		
		if (orderResult != null && valorAprovado.intValue() < valorTotalPedido.intValue()
				&& status.equalsIgnoreCase("APROVADO")) {
			statusResponse.add(StatusEnum.APROVADO_VALOR_A_MENOR.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		}
		
		if (orderResult != null && itensAprovados.intValue() < qtdItensPedido.intValue()
				&& status.equalsIgnoreCase("APROVADO")) {
			statusResponse.add(StatusEnum.APROVADO_QTD_A_MENOR.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		}
		
		if (orderResult != null && valorAprovado.intValue() > valorTotalPedido.intValue()
				&& status.equalsIgnoreCase("APROVADO")) {
			statusResponse.add(StatusEnum.APROVADO_VALOR_A_MAIOR.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		}
		
		if (orderResult != null && itensAprovados.intValue() > qtdItensPedido.intValue()
				&& status.equalsIgnoreCase("APROVADO")) {
			statusResponse.add(StatusEnum.APROVADO_QTD_A_MAIOR.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		}

		return response;
	}
}
