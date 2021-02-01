package br.com.luizbsilva.api.model.table;

import lombok.*;

import javax.persistence.*;

@Builder
@NoArgsConstructor
@AllArgsConstructor
@EqualsAndHashCode
@Entity
@Table(name = "items")
public class Items implements IEntity {

    @Getter
    @Setter
    @Id
    @SequenceGenerator(name = "items_sequence", sequenceName = "items_seq", initialValue = 1, allocationSize = 100)
    @GeneratedValue(generator = "items_sequence")
    private Long id;

    @Getter
    @Setter
    @Column(name = "description")
    private String description;

}
