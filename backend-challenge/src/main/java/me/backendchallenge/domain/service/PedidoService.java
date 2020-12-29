package me.backendchallenge.domain.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import me.backendchallenge.domain.exception.PedidoNaoEncontradoException;
import me.backendchallenge.domain.exception.PriceOrQuantityNonPositiveException;
import me.backendchallenge.domain.model.Item;
import me.backendchallenge.domain.model.Pedido;
import me.backendchallenge.domain.repository.PedidoRepository;

@Service
public class PedidoService {

	private PedidoRepository pedidoRepository;

	@Autowired
	public PedidoService(PedidoRepository pedidoRepository) {
		this.pedidoRepository = pedidoRepository;
	}

	public List<Pedido> listar() {
		return pedidoRepository.findAll();
	}

	public Pedido obterPedido(Long id) {
		return findOrFail(id);
	}

	public Pedido salvarPedido(Pedido pedido) {
		for (Item item : pedido.getItens()) {
			if ((item.getPrecoUnitario() < 1) || (item.getQtd() < 1))
				throw new PriceOrQuantityNonPositiveException("Preço ou quantidade não positivo");
		}

		pedido.getItens().forEach(item -> item.setPedido(pedido));
		return pedidoRepository.save(pedido);
	}

	public Pedido atualizarPedido(Long id, Pedido pedido) {
		Pedido pedidoSalvo = findOrFail(id);

		pedidoSalvo.setPedido(pedido.getPedido());

		pedido.getItens().forEach(item -> item.setPedido(pedido));

		pedidoSalvo.getItens().clear();

		if (pedido.getItens().size() > 0) {
			Pedido novoPedido = new Pedido(pedidoSalvo);
			for (Item item : pedido.getItens()) {
				if ((item.getPrecoUnitario() < 1) || (item.getQtd() < 1))
					throw new PriceOrQuantityNonPositiveException("Preço ou quantidade não positivo");

				novoPedido = pedidoSalvo.addItem(item);
			}
			pedidoSalvo = new Pedido(novoPedido);
		}

		return pedidoRepository.save(pedidoSalvo);
	}

	public void removerPedido(Long id) {
		Pedido pedido = findOrFail(id);
		pedidoRepository.delete(pedido);
	}

	private Pedido findOrFail(Long id) {
		return pedidoRepository.findById(id)
				.orElseThrow(() -> new PedidoNaoEncontradoException("Pedido não localizado"));
	}

}
