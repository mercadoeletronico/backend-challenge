package mercado.eletronico.backendchallenge.manager;

import mercado.eletronico.backendchallenge.api.v1.model.StatusDTO;
import mercado.eletronico.backendchallenge.api.v1.model.StatusUpdateDTO;
import mercado.eletronico.backendchallenge.domain.Pedido;
import mercado.eletronico.backendchallenge.domain.Status;

import java.util.ArrayList;
import java.util.List;

public class PedidoManager {


    public static StatusDTO updateStatusPedido(Pedido pedido, StatusUpdateDTO statusUpdateDTO) {
        StatusDTO statusDTO = StatusDTO.builder().pedido(statusUpdateDTO.getPedido()).build();
        List<Status> statusList = new ArrayList<>();
        if (Status.REPROVADO.equalsName(statusUpdateDTO.getStatus())) {
            statusList.add(Status.REPROVADO);
            statusDTO.setStatus(statusList);
            return statusDTO;
        } else if (Status.APROVADO.equalsName(statusUpdateDTO.getStatus())) {
            Double valorTotalPedido = calculaValorTotal(pedido);
            if (statusUpdateDTO.getItensAprovados().equals(pedido.getItens().size()) &&
                statusUpdateDTO.getValorAprovado().equals(valorTotalPedido)){
                statusList.add(Status.APROVADO);
            }
            if (statusUpdateDTO.getValorAprovado() < valorTotalPedido) {
                statusList.add(Status.APROVADO_VALOR_A_MENOR);
            }
            if (statusUpdateDTO.getItensAprovados() < pedido.getItens().size()){
                statusList.add(Status.APROVADO_QTD_A_MENOR);
            }
            if (statusUpdateDTO.getValorAprovado() > valorTotalPedido){
                statusList.add(Status.APROVADO_VALOR_A_MAIOR);
            }
            if (statusUpdateDTO.getItensAprovados() > pedido.getItens().size()){
                statusList.add(Status.APROVADO_QTD_A_MAIOR);
            }
            statusDTO.setStatus(statusList);
        } else {
            statusList.add(Status.STATUS_INVALIDO);
            statusDTO = StatusDTO.builder().pedido(statusUpdateDTO.getPedido()).status(statusList).build();
        }
        return statusDTO;
    }

    private static Double calculaValorTotal(Pedido pedido) {
        return pedido.getItens().stream()
                .mapToDouble(item -> item.getPrecoUnitario()*item.getQtd()).sum();
    }
}
