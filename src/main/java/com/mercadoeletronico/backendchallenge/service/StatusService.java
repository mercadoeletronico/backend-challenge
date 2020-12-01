package com.mercadoeletronico.backendchallenge.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.mercadoeletronico.backendchallenge.dto.StatusRequestDTO;
import com.mercadoeletronico.backendchallenge.dto.StatusResponseDTO;
import com.mercadoeletronico.backendchallenge.entity.Itens;
import com.mercadoeletronico.backendchallenge.entity.Orders;
import com.mercadoeletronico.backendchallenge.enums.StatusEnum;
import com.mercadoeletronico.backendchallenge.repository.ItemRepository;
import com.mercadoeletronico.backendchallenge.repository.OrderRepository;

@Service
public class StatusService {

	@Autowired
	private OrderRepository orderRepository;

	@Autowired
	private ItemRepository itemRepository;

	private StatusEnum statusEnum;

	@SuppressWarnings("unused")
	public StatusResponseDTO validateStatus(StatusRequestDTO request) {

		StatusResponseDTO response = new StatusResponseDTO();

		List<String> statusResponse = new ArrayList<String>();

		// Campos do request
		
		String pedido = request.getPedido();
		String status = request.getStatus();
		Integer itensAprovados = request.getItensAprovados();
		Double valorAprovado = request.getValorAprovado();

		// Campos de tratamento do request
		
		Integer qtdItensPedido = 0;
		Double valorTotalPedido = 0.0;

		// Busca o pedido pelo usando o campo Pedido
		
		Orders orderResult = new Orders();
		orderResult = orderRepository.findByPedido(pedido);

		// Busca os itens do pedido usando o ID do Pedido
		
		List<Itens> itensPedido = new ArrayList<Itens>();
		Integer pedidoId = orderResult.getId();
		itensPedido = itemRepository.findByPedidoId(pedidoId);
		
		// Itera os itens do pedido somando a quantidade de itens do pedido
		
		for(int i = 0; i < itensPedido.size(); i++) {
			qtdItensPedido = qtdItensPedido + itensPedido.get(i).getQtd();
			valorTotalPedido = valorTotalPedido + (itensPedido.get(i).getQtd() * itensPedido.get(i).getPrecoUnitario());
		}		

		// pedido não for localizado no banco de dados.
		
		if (orderResult == null) {
			statusResponse.add(statusEnum.CODIGO_PEDIDO_INVALIDO.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		}

		// pedido for localizado no banco de dados.
		// status for igual a REPROVADO
		
		if (orderResult != null && status.equalsIgnoreCase("REPROVADO")) {
			statusResponse.add(statusEnum.REPROVADO.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);

		}

		// pedido for localizado no banco de dados.
		// itensAprovados for igual a quantidade de itens do pedido.
		// valorAprovado for igual o valor total do pedido.
		// status for igual a APROVADO.

		if (orderResult != null && itensAprovados.equals(qtdItensPedido) && valorAprovado.equals(valorTotalPedido)
				&& status.equalsIgnoreCase("APROVADO")) {
			statusResponse.add(statusEnum.APROVADO.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		}

		// pedido for localizado no banco de dados.
		// valorAprovado for menor que o valor total do pedido
		// status for igual a APROVADO
		
		if (orderResult != null && valorAprovado.intValue() < valorTotalPedido.intValue()
				&& status.equalsIgnoreCase("APROVADO")) {
			statusResponse.add(statusEnum.APROVADO_VALOR_A_MENOR.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		}
		
		// pedido for localizado no banco de dados.
		// itensAprovados for menor que a quantidade de itens do pedido.
		// status for igual a APROVADO
		
		if (orderResult != null && itensAprovados.intValue() < qtdItensPedido.intValue()
				&& status.equalsIgnoreCase("APROVADO")) {
			statusResponse.add(statusEnum.APROVADO_QTD_A_MENOR.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		}
		
		// pedido for localizado no banco de dados.
		// valorAprovado for maior que o valor total do pedido
		// status for igual a APROVADO
		
		if (orderResult != null && valorAprovado.intValue() > valorTotalPedido.intValue()
				&& status.equalsIgnoreCase("APROVADO")) {
			statusResponse.add(statusEnum.APROVADO_VALOR_A_MAIOR.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		}

		// pedido for localizado no banco de dados.
		// itensAprovados for maior que a quantidade de itens do pedido.
		// status for igual a APROVADO
		
		if (orderResult != null && itensAprovados.intValue() > qtdItensPedido.intValue()
				&& status.equalsIgnoreCase("APROVADO")) {
			statusResponse.add(statusEnum.APROVADO_QTD_A_MAIOR.getDsStatus());
			response.setPedido(pedido);
			response.setStatus(statusResponse);
		}

		return response;
	}
}
