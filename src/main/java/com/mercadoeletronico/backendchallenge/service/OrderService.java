package com.mercadoeletronico.backendchallenge.service;

import java.util.ArrayList;
import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.mercadoeletronico.backendchallenge.dto.OrderDTO;
import com.mercadoeletronico.backendchallenge.entity.Itens;
import com.mercadoeletronico.backendchallenge.entity.Orders;
import com.mercadoeletronico.backendchallenge.repository.ItemRepository;
import com.mercadoeletronico.backendchallenge.repository.OrderRepository;

@Service
public class OrderService {

	@Autowired
	private OrderRepository orderRepository;

	@Autowired
	private ItemRepository itemRepository;

	public List<OrderDTO> getAllOrders() {
		List<OrderDTO> response = new ArrayList<OrderDTO>();

		try {
			
			List<Orders> orders = new ArrayList<Orders>();
			orders = orderRepository.findAll();
			for (int i = 0; i < orders.size(); i++) {
				OrderDTO order = new OrderDTO();
				order.setPedido(orders.get(i).getPedido());
				Integer pedidoId = orders.get(i).getId();
				List<Itens> item = new ArrayList<Itens>();
				item = itemRepository.findByPedidoId(pedidoId);
				order.setItens(item);
				response.add(order);
				
			}
		} catch (Exception e) {
			e.printStackTrace();
		}

		return response;
	}

	public void saveOrder(OrderDTO request) {

		try {
			Orders order = new Orders();
			order.setPedido(request.getPedido());
			orderRepository.save(order);

			for (int i = 0; i < request.getItens().size(); i++) {
				Itens item = new Itens();
				item.setDescricao(request.getItens().get(i).getDescricao());
				item.setPrecoUnitario(request.getItens().get(i).getPrecoUnitario());
				item.setQtd(request.getItens().get(i).getQtd());
				item.setPedidoId(order.getId());
				itemRepository.save(item);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}

	}

	public void updateOrder(OrderDTO request) {
		String pedido = request.getPedido();		
				
		try {			
			Orders order = new Orders();
			// busca o pedido pelo Id do Pedido
			order = orderRepository.findByPedido(pedido);
			Integer pedidoId = order.getId();
			
			// busca os itens deste pedido e seleciona os ids deles
			List<Itens> itens = new ArrayList<Itens>();
			itens = itemRepository.findByPedidoId(pedidoId);
			
			// sobrescreve os itens do request aos itens salvos no bd
			
			for (int i = 0; i < itens.size(); i++) {
				itemRepository.updateItemQuery(pedidoId, request.getItens().get(i).getDescricao(), request.getItens().get(i).getPrecoUnitario(), request.getItens().get(i).getQtd());
			}
			
//			for (int i = 0; i < request.getItens().size(); i++) {
//				Itens item = new Itens();
//				item.setDescricao(request.getItens().get(i).getDescricao());
//				item.setPrecoUnitario(request.getItens().get(i).getPrecoUnitario());
//				item.setQtd(request.getItens().get(i).getQtd());
//				item.setPedidoId(order.getId());
//				itemRepository.saveAndFlush(item);
//			}
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	public void deleteOrder(String request) {
		try {
			Orders order = new Orders();
			order = orderRepository.findByPedido(request);
			Integer orderId = order.getId();
			List<Itens> itens = new ArrayList<Itens>();
			itens = itemRepository.findByPedidoId(orderId);
			for (int i = 0; i < itens.size(); i++) {
				itemRepository.deleteById(itens.get(i).getId());
			}
			orderRepository.deleteById(orderId);
		} catch (Exception e) {
			e.printStackTrace();
		}

	}
}
