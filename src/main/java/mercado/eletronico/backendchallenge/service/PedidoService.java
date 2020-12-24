package mercado.eletronico.backendchallenge.service;

import mercado.eletronico.backendchallenge.api.v1.model.BaseDTO;
import mercado.eletronico.backendchallenge.api.v1.model.PedidoDTO;
import mercado.eletronico.backendchallenge.api.v1.model.StatusUpdateDTO;

public interface PedidoService {

    BaseDTO criaNovoPedido(PedidoDTO pedidoDTO);

    BaseDTO getPedido(String codigoPedido);

    BaseDTO atualizaStatus(StatusUpdateDTO statusUpdateDTO);

    BaseDTO editaPedido(PedidoDTO pedidoDTO);

    BaseDTO deletaPedido(PedidoDTO pedidoDTO);
}
