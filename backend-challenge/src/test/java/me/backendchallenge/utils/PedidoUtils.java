package me.backendchallenge.utils;

import java.util.ArrayList;
import java.util.List;

import me.backendchallenge.domain.model.Item;
import me.backendchallenge.domain.model.Pedido;

public class PedidoUtils {
	public static final Long ID_PEDIDO_VALIDO = 123L;
	public static final Long ID_PEDIDO_SEM_ITEM = 1231L;

	public static final String CODIGO_PEDIDO_VALIDO = "123456";
	public static final String CODIGO_PEDIDO_INVALIDO = "123456-N";
	public static final String CODIGO_PEDIDO_SEM_ITEM = "12345688";

	public static Pedido buildPedidoValido() {
		Pedido pedido = new Pedido();
		pedido.setId(ID_PEDIDO_VALIDO);
		pedido.setPedido(CODIGO_PEDIDO_VALIDO);

		List<Item> itens = buildItensValido(pedido);

		pedido.setItens(itens);

		return pedido;
	}

	public static Pedido buildPedidoSemItem() {
		Pedido pedido = new Pedido();
		pedido.setId(ID_PEDIDO_SEM_ITEM);
		pedido.setPedido(CODIGO_PEDIDO_SEM_ITEM);
		pedido.setItens(new ArrayList<>());

		return pedido;
	}

	public static Pedido buildPedidoQuantidadeNaoPositiva() {
		Pedido pedido = new Pedido();
		pedido.setId(ID_PEDIDO_VALIDO);
		pedido.setPedido(CODIGO_PEDIDO_VALIDO);

		List<Item> itens = buildItensQuantidadeNaoPositiva(pedido);

		pedido.setItens(itens);

		return pedido;
	}

	public static Pedido buildPedidoValorNaoPositivo() {
		Pedido pedido = new Pedido();
		pedido.setId(ID_PEDIDO_VALIDO);
		pedido.setPedido(CODIGO_PEDIDO_VALIDO);

		List<Item> itens = buildItensValorNaoPositivo(pedido);

		pedido.setItens(itens);

		return pedido;
	}

	public static List<Item> buildItensValido(Pedido pedido) {
		List<Item> itens = new ArrayList<>();
		Item item = new Item();

		for (int i = 0; i < 3; i++) {
			item.setId(new Long(i));
			item.setDescricao("A" + String.valueOf(i));
			item.setPedido(pedido);
			item.setQtd((i + 1) * 5);
			item.setPrecoUnitario(new Double((i + 1) * 10));

			itens.add(item);
		}

		return itens;
	}

	public static List<Item> buildItensQuantidadeNaoPositiva(Pedido pedido) {
		List<Item> itens = new ArrayList<>();
		Item item = new Item();

		for (int i = 0; i < 3; i++) {
			item.setId(new Long(i));
			item.setDescricao("A" + String.valueOf(i));
			item.setPedido(pedido);
			item.setQtd((i + 1) * 0);
			item.setPrecoUnitario(new Double((i + 1) * 10));

			itens.add(item);
		}

		return itens;
	}

	public static List<Item> buildItensValorNaoPositivo(Pedido pedido) {
		List<Item> itens = new ArrayList<>();
		Item item = new Item();

		for (int i = 0; i < 3; i++) {
			item.setId(new Long(i));
			item.setDescricao("A" + String.valueOf(i));
			item.setPedido(pedido);
			item.setQtd((i + 1) * 5);
			item.setPrecoUnitario(new Double((i + 1) * 0));

			itens.add(item);
		}

		return itens;
	}
}
