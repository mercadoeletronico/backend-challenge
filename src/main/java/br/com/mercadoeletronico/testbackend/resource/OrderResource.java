package br.com.mercadoeletronico.testbackend.resource;

import br.com.mercadoeletronico.testbackend.dto.OrderDTO;
import br.com.mercadoeletronico.testbackend.service.OrderService;
import lombok.AccessLevel;
import lombok.AllArgsConstructor;
import lombok.experimental.FieldDefaults;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.*;
import reactor.core.publisher.Mono;

import javax.validation.Valid;

@RestController
@AllArgsConstructor(onConstructor = @__(@Autowired))
@FieldDefaults(makeFinal = true, level = AccessLevel.PRIVATE)
@RequestMapping(value = "/api/pedido")
public class OrderResource {

    OrderService service;

    @GetMapping(value = "/{idOrder}")
    public Mono<OrderDTO> getOrder(@PathVariable String idOrder){
        return service.getOrder(idOrder);
    }

    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public Mono<Void> save(@Valid @RequestBody OrderDTO order){
        return service.save(order).then();
    }

    @PutMapping(value = "/{idOrder}")
    public Mono<OrderDTO> update(@PathVariable String idOrder, @Valid @RequestBody OrderDTO order){
        return service.update(idOrder, order);
    }

    @DeleteMapping(value = "/{idOrder}")
    public Mono<OrderDTO> delete(@PathVariable String idOrder){
        return service.delete(idOrder);
    }
}
