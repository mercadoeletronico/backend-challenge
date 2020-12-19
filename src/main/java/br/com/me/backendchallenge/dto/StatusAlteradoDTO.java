package br.com.me.backendchallenge.dto;

import br.com.me.backendchallenge.enums.Status;
import lombok.Value;

import java.util.List;

@Value
public class StatusAlteradoDTO {
    Long pedido;
    List<Status> status;
}
