package br.com.mercadoeletronico.testbackend.resource;

import br.com.mercadoeletronico.testbackend.dto.StatusDTO;
import br.com.mercadoeletronico.testbackend.service.OrderService;
import lombok.AccessLevel;
import lombok.AllArgsConstructor;
import lombok.experimental.FieldDefaults;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import reactor.core.publisher.Mono;

import javax.validation.Valid;

@RestController
@AllArgsConstructor(onConstructor = @__(@Autowired))
@FieldDefaults(makeFinal = true, level = AccessLevel.PRIVATE)
@RequestMapping(value = "/api/status")
public class StatusResource {
    OrderService service;

    //poderia ser um patch em /api/pedido/{idOrder}
    @PostMapping
    public Mono<Void> changeStatus(@Valid StatusDTO status){
        return service.changeStatus(status).then();
    }
}
