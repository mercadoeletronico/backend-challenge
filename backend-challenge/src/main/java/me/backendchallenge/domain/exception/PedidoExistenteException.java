package me.backendchallenge.domain.exception;

public class PedidoExistenteException extends RuntimeException {
	private static final long serialVersionUID = 1245L;

	public PedidoExistenteException(String message) {
		super(message);
	}
}
