package br.com.mercadoeletronico.testbackend.resource;

import br.com.mercadoeletronico.testbackend.dto.OrderDTO;
import br.com.mercadoeletronico.testbackend.service.OrderService;
import com.github.javafaker.Faker;
import lombok.AccessLevel;
import lombok.AllArgsConstructor;
import lombok.experimental.FieldDefaults;
import org.junit.jupiter.api.Test;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.test.context.SpringBootTest;
import org.springframework.http.HttpStatus;
import org.springframework.http.MediaType;
import org.springframework.test.web.reactive.server.WebTestClient;

import static br.com.mercadoeletronico.testbackend.utils.TestFactory.createOrder;

@SpringBootTest(webEnvironment = SpringBootTest.WebEnvironment.RANDOM_PORT)
@AllArgsConstructor(onConstructor = @__(@Autowired))
@FieldDefaults(makeFinal = true, level = AccessLevel.PRIVATE)
public class IntegrationTest {

    WebTestClient webTestClient;
    Faker faker;

    public WebTestClient.ResponseSpec requestSave(OrderDTO order){
        return webTestClient.post()
            .uri("/api/pedido")
            .bodyValue(order)
            .accept(MediaType.APPLICATION_JSON)
            .exchange();
    }

    @Test
    public void save(){
        var order = createOrder(
            faker.number()
                .numberBetween(1,10)
        );
        requestSave(order)
            .expectStatus()
            .isCreated();
    }

    @Test
    public void saveNoProduct(){
        var order = createOrder(0);
        requestSave(order)
            .expectStatus()
            .isEqualTo(HttpStatus.BAD_REQUEST);
    }

    @Test
    public void saveAlreadyExists(){
        var order = createOrder(
            faker.number()
                .numberBetween(1,10)
        );
        requestSave(order);
        requestSave(order)
            .expectStatus()
            .isEqualTo(HttpStatus.CONFLICT);
    }

    @Test
    public void get(){
        var order = createOrder(
            faker.number()
                .numberBetween(1,10)
        );
        requestSave(order);
        webTestClient.get()
            .uri("/api/pedido/{idOrder}", order.getIdOrder())
            .accept(MediaType.APPLICATION_JSON)
            .exchange()
            .expectStatus()
            .isOk();
    }

    @Test
    public void getNotExist(){
        webTestClient.get()
            .uri("/api/pedido/NOTEXIST")
            .accept(MediaType.APPLICATION_JSON)
            .exchange()
            .expectStatus()
            .isNotFound();
    }

    @Test
    public void delete(){
        var order = createOrder(
            faker.number()
                .numberBetween(1,10)
        );
        requestSave(order);
        webTestClient.delete()
            .uri("/api/pedido/{idOrder}", order.getIdOrder())
            .accept(MediaType.APPLICATION_JSON)
            .exchange()
            .expectStatus()
            .isOk();
    }

    @Test
    public void deleteNotExist(){
        var order = createOrder(
            faker.number()
                .numberBetween(1,10)
        );
        requestSave(order);
        webTestClient.delete()
            .uri("/api/pedido/NOTEXIST")
            .accept(MediaType.APPLICATION_JSON)
            .exchange()
            .expectStatus()
            .isNotFound();
    }

    @Test
    public void update(){
        var productCount = faker.number()
            .numberBetween(1,10);
        var order = createOrder(productCount);
        var orderUpdated = createOrder(productCount);
        requestSave(order);
        webTestClient.put()
            .uri("/api/pedido/{idOrder}", order.getIdOrder())
            .bodyValue(
                OrderDTO.builder()
                    .idOrder(order.getIdOrder())
                    .items(orderUpdated.getItems())
                    .build()
            ).accept(MediaType.APPLICATION_JSON)
            .exchange()
            .expectStatus()
            .isOk();
    }

    @Test
    public void updateNotSame(){
        var productCount = faker.number()
            .numberBetween(1,10);
        var order = createOrder(productCount);
        var orderUpdated = createOrder(productCount);
        requestSave(order);
        webTestClient.put()
            .uri("/api/pedido/{idOrder}", order.getIdOrder())
            .bodyValue(orderUpdated)
            .accept(MediaType.APPLICATION_JSON)
            .exchange()
            .expectStatus()
            .isBadRequest();
    }

    @Test
    public void updateNotExists(){
        var productCount = faker.number()
                .numberBetween(1,10);
        var order = createOrder(productCount);
        webTestClient.put()
                .uri("/api/pedido/{idOrder}", order.getIdOrder())
                .bodyValue(order)
                .accept(MediaType.APPLICATION_JSON)
                .exchange()
                .expectStatus()
                .isNotFound();
    }


}
