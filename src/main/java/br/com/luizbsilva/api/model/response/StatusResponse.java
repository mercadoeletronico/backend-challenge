package br.com.luizbsilva.api.model.response;

import lombok.*;

import java.util.List;

@Getter
@Setter
@Builder
@NoArgsConstructor
@AllArgsConstructor
@EqualsAndHashCode
public class StatusResponse {

    private String ordered;

    private List<String> status;

}
