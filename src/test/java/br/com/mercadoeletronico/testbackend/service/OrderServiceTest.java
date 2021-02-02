package br.com.mercadoeletronico.testbackend.service;

import br.com.mercadoeletronico.testbackend.dto.*;
import com.github.javafaker.Faker;
import lombok.AccessLevel;
import lombok.AllArgsConstructor;
import lombok.experimental.FieldDefaults;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.web.server.ResponseStatusException;
import reactor.test.StepVerifier;

import java.util.Collections;

import static br.com.mercadoeletronico.testbackend.utils.TestFactory.createOrder;
import static org.junit.jupiter.api.Assertions.assertEquals;

@SpringBootTest
@AllArgsConstructor(onConstructor = @__(@Autowired))
@FieldDefaults(makeFinal = true, level = AccessLevel.PRIVATE)
class OrderServiceTest {

    OrderService service;
    Faker faker;

    @Test
    public void save(){
        var productCount = faker.number()
            .numberBetween(1,10);
        StepVerifier.create(
            service.save(
                createOrder(productCount)
            )
        ).assertNext(
            orderDTO -> assertEquals(
                productCount,
                orderDTO.getItems()
                    .size()
            )
        ).verifyComplete();
    }

    @Test
    public void saveNoItems(){
        StepVerifier.create(
            service.save(
                createOrder(0)
            )
        ).verifyError(ResponseStatusException.class);
    }

    @Test
    public void getOrder(){
        var productCount = faker.number()
            .numberBetween(1,10);
        var order = createOrder(productCount);
        StepVerifier.create(
            service.save(order)
                .flatMap(
                    orderDTO -> service.getOrder(orderDTO.getIdOrder())
                )
        ).assertNext(orderDTO -> {
            assertEquals(order.getIdOrder(), orderDTO.getIdOrder());
            assertEquals(productCount, orderDTO.getItems().size());
        }).verifyComplete();
    }

    @Test
    public void getOrderNotExist(){
        StepVerifier.create(
            service.getOrder("NOTEXIST")
        ).verifyError(ResponseStatusException.class);
    }

    @Test
    public void delete(){
        var productCount = faker.number().numberBetween(1,10);
        var order = createOrder(productCount);
        StepVerifier.create(
            service.save(order)
                .flatMap(
                    orderDTO -> {
                        var idOrder = orderDTO.getIdOrder();
                        return service.delete(idOrder)
                            .then(service.getOrder(idOrder));
                    }
                )
        ).verifyError(ResponseStatusException.class);
    }

    @Test
    public void deleteNotExist(){
        StepVerifier.create(
            service.delete("NOTEXIST")
        ).verifyError(ResponseStatusException.class);
    }

    @Test
    public void update(){
        var productCount = faker.number()
            .numberBetween(1,10);
        var productCountUpdated = faker.number()
            .numberBetween(
                productCount+1,
                productCount*2
            );
        var order = createOrder(productCount);
        var orderUpdated = createOrder(productCountUpdated);
        StepVerifier.create(
            service.save(order)
                .flatMap(orderDTO ->{
                    var idOrder = order.getIdOrder();
                    return service.update(
                        idOrder,
                        OrderDTO.builder()
                            .idOrder(idOrder)
                            .items(orderUpdated.getItems())
                            .build()
                    );
                })
        ).assertNext(orderDTO -> {
            assertEquals(order.getIdOrder(), orderDTO.getIdOrder());
            assertEquals(productCountUpdated, orderDTO.getItems().size());
        }).verifyComplete();
    }

    @Test
    public void updateNotSame(){
        var productCount = faker.number()
            .numberBetween(1,10);
        var productCountUpdated = faker.number()
            .numberBetween(
                productCount+1,
                productCount*2
            );
        var order = createOrder(productCount);
        var orderUpdated = createOrder(productCountUpdated);
        StepVerifier.create(
            service.save(order)
                .flatMapMany(orderDTO ->
                    service.update(orderDTO.getIdOrder(), orderUpdated)
                )
        ).verifyError(ResponseStatusException.class);
    }

    @Test
    public void UpdateNotExists(){
        var productCount = faker.number()
            .numberBetween(1,10);
        var order = createOrder(productCount);
        StepVerifier.create(
            service.update(order.getIdOrder(), order)
        ).verifyError(ResponseStatusException.class);
    }

    @Test
    public void changeStatusReprovado(){
        var productCount = faker.number()
            .numberBetween(1,10);
        var order = createOrder(productCount);
        StepVerifier.create(
            service.save(order)
                .flatMap(orderDTO ->
                    service.changeStatus(
                        StatusDTO.builder()
                            .idOrder(orderDTO.getIdOrder())
                            .status(Status.REPROVADO)
                            .build()
                    )
                )
        ).expectNext(
            StatusResponseDTO.builder()
                .status(Collections.singletonList(Status.REPROVADO))
                .idOrder(order.getIdOrder())
                .build()
        ).verifyComplete();
    }

    @Test
    public void changeStatusInvalido() {
        StepVerifier.create(
            service.changeStatus(
                StatusDTO.builder()
                    .idOrder("NOTEXIST")
                    .status(Status.APROVADO)
                    .build()
            )
        ).expectNext(
            StatusResponseDTO.builder()
                    .status(
                        Collections.singletonList(Status.CODIGO_PEDIDO_INVALIDO)
                    ).idOrder("")
                    .build()
        ).verifyComplete();
    }

    @Test
    public void changeStatusAprovado(){
        var productCount = faker.number()
            .numberBetween(1,10);
        var order = createOrder(productCount);
        StepVerifier.create(
            service.save(order)
                .flatMap(orderDTO ->
                    service.changeStatus(
                        StatusDTO.builder()
                            .idOrder(orderDTO.getIdOrder())
                            .status(Status.APROVADO)
                            .items(
                                order.getItems()
                                    .stream()
                                    .map(ProductDTO::getQuantity)
                                    .reduce(Integer::sum)
                                    .orElse(0)
                            ).price(
                                orderDTO.getItems()
                                    .stream()
                                    .map(product -> product.getPrice() * product.getQuantity())
                                    .reduce(Integer::sum)
                                    .orElse(0)
                            ).build()
                    )
                )
        ).expectNext(
            StatusResponseDTO.builder()
                .status(Collections.singletonList(Status.APROVADO))
                .idOrder(order.getIdOrder())
                .build()
        ).verifyComplete();
    }
}