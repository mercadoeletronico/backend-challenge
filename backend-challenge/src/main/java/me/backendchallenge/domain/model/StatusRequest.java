package me.backendchallenge.domain.model;

public class StatusRequest {
	private String status;
	private Integer itensAprovados;
	private Double valorAprovado;
	private String pedido;

	public String getStatus() {
		return status;
	}

	public void setStatus(String status) {
		this.status = status;
	}

	public Integer getItensAprovados() {
		return itensAprovados;
	}

	public void setItensAprovados(Integer itensAprovados) {
		this.itensAprovados = itensAprovados;
	}

	public Double getValorAprovado() {
		return valorAprovado;
	}

	public void setValorAprovado(Double valorAprovado) {
		this.valorAprovado = valorAprovado;
	}

	public String getPedido() {
		return pedido;
	}

	public void setPedido(String pedido) {
		this.pedido = pedido;
	}

}
