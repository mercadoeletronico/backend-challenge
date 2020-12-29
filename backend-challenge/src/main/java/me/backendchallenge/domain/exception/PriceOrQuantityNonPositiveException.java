package me.backendchallenge.domain.exception;

public class PriceOrQuantityNonPositiveException extends RuntimeException {
	private static final long serialVersionUID = 1424231L;

	public PriceOrQuantityNonPositiveException(String message) {
		super(message);
	}
}
