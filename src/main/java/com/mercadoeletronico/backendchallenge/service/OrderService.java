package com.mercadoeletronico.backendchallenge.service;

import java.util.List;
import java.util.Optional;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import com.mercadoeletronico.backendchallenge.entity.Item;
import com.mercadoeletronico.backendchallenge.entity.Order;
import com.mercadoeletronico.backendchallenge.repository.ItemRepository;
import com.mercadoeletronico.backendchallenge.repository.OrderRepository;

@Service
public class OrderService {

	@Autowired
	private OrderRepository orderRepository;

	@Autowired
	private ItemRepository itemRepository;

	public List<Order> getAllOrders() {
		return orderRepository.findAll();
	}

	public Order getOrderByPedido(String pedido) {
		return orderRepository.findByPedido(pedido);
	}

	public List<Item> getItensByPedidoId(Long pedidoId) {
		return itemRepository.findByPedidoId(pedidoId);
	}

	public Optional<Order> getOrder(Long id) {
		return orderRepository.findById(id);
	}

	public void saveItem(Item request) {
		try {
			itemRepository.save(request);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}

	public void saveOrder(Order request) {
		try {
			orderRepository.save(request);
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	}
	
	public void updateItem(Long pedidoId, List<Item> itemRequest) {
		try {
			List<Item> itemList = itemRepository.findByPedidoId(pedidoId);

			for (int i = 0; i < itemRequest.size(); i++) {
				itemList.get(i).setDescricao(itemRequest.get(i).getDescricao());
				itemList.get(i).setPrecoUnitario(itemRequest.get(i).getPrecoUnitario());
				itemList.get(i).setQtd(itemRequest.get(i).getQtd());
				itemRepository.save(itemList.get(i));
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}

	}

	public void deleteOrder(Long pedidoId) {
		try {
			orderRepository.deleteById(pedidoId);

		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
