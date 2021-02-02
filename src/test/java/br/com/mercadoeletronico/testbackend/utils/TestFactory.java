package br.com.mercadoeletronico.testbackend.utils;

import br.com.mercadoeletronico.testbackend.dto.OrderDTO;
import br.com.mercadoeletronico.testbackend.dto.ProductDTO;
import com.github.javafaker.Faker;

import java.util.stream.Collectors;
import java.util.stream.IntStream;

public class TestFactory {
    public static OrderDTO createOrder(Integer productsCount){
        var faker = new Faker();
        return OrderDTO.builder()
            .idOrder(
                faker.number()
                    .digits(6)
            ).items(
                IntStream.range(0,productsCount)
                    .mapToObj(
                        i ->
                            ProductDTO.builder()
                                .description(faker.lorem().characters(100, 200))
                                .price(faker.number().randomDigitNotZero())
                                .quantity(faker.number().randomDigitNotZero())
                                .build()
                    ).collect(Collectors.toList())
            ).build();
    }
}
