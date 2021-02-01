package br.com.luizbsilva.api.model.payload;

import lombok.*;

import java.util.List;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@RequiredArgsConstructor
public class SalesOrder implements ISalesOrder {

    @NonNull
    private String ordered;

    private List<ItemSalesOrder> orderedItems;

}
