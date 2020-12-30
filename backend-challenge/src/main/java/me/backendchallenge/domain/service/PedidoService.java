package me.backendchallenge.domain.service;

import java.util.List;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import me.backendchallenge.domain.exception.PedidoExistenteException;
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

	public Pedido obterPedido(String pedido) {
		return findOrFail(pedido);
	}

	public Pedido salvarPedido(Pedido pedido) {
		if (findExists(pedido.getPedido()))
			throw new PedidoExistenteException("Código do pedido já existente");

		pedido.getItens().forEach(item -> validaItem(item));
		pedido.getItens().forEach(item -> item.setPedido(pedido));

		return pedidoRepository.save(pedido);
	}

	public Pedido atualizarPedido(String codigoPedido, Pedido pedido) {
		Pedido pedidoSalvo = findOrFail(codigoPedido);
		pedido.getItens().forEach(item -> item.setPedido(pedido));

		pedidoSalvo.setPedido(pedido.getPedido());
		pedidoSalvo.getItens().clear();

		if (pedido.getItens().size() > 0) {
			Pedido novoPedido = new Pedido(pedidoSalvo);

			for (Item item : pedido.getItens()) {
				validaItem(item);
				novoPedido = pedidoSalvo.addItem(item);
			}

			pedidoSalvo = new Pedido(novoPedido);
		}

		return pedidoRepository.save(pedidoSalvo);
	}

	public void removerPedido(String codigoPedido) {
		Pedido pedido = findOrFail(codigoPedido);
		pedidoRepository.delete(pedido);
	}

	private Pedido findOrFail(String pedido) {
		Pedido pedidoEncontrado = pedidoRepository.findByPedido(pedido);

		if (pedidoEncontrado == null)
			throw new PedidoNaoEncontradoException("Pedido não localizado");

		return pedidoEncontrado;
	}

	private Boolean findExists(String pedido) {
		return pedidoRepository.existsByPedido(pedido);
	}

	private void validaItem(Item item) {
		if ((item.getPrecoUnitario() < 1) || (item.getQtd() < 1))
			throw new PriceOrQuantityNonPositiveException("Preço ou quantidade não positivo");
	}

}
