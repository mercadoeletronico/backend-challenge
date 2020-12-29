package me.backendchallenge.domain.model;

import java.util.ArrayList;
import java.util.List;

public class StatusResponse {
	private String pedido;
	private List<StatusEnum> listStatus = new ArrayList<>();

	public StatusResponse() {
		this.listStatus = new ArrayList<>();
	}

	public StatusResponse(String pedido, List<StatusEnum> listStatus) {
		this.pedido = pedido;
		this.listStatus = listStatus;
	}

	public String getPedido() {
		return pedido;
	}

	public void setPedido(String pedido) {
		this.pedido = pedido;
	}

	public List<StatusEnum> getListStatus() {
		return listStatus;
	}

	public void setListStatus(List<StatusEnum> listStatus) {
		this.listStatus = listStatus;
	}

}
