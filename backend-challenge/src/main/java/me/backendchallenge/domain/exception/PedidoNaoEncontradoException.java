package me.backendchallenge.domain.exception;

public class PedidoNaoEncontradoException extends RuntimeException{

	private static final long serialVersionUID = 1243L;
	
	public PedidoNaoEncontradoException(String message) {
		super(message);
	}
}
