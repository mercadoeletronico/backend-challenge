package br.com.me.backendchallenge.domain;

import br.com.me.backendchallenge.dto.StatusAlterarDTO;
import br.com.me.backendchallenge.enums.Status;
import com.fasterxml.jackson.annotation.JsonIgnore;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.annotations.JoinFormula;

import javax.persistence.*;
import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;
import java.util.Optional;

@Getter
@Setter
@Entity
@Table(name = "TB_PEDIDO")
public class Pedido {
    @Id
    @Column(name = "ID")
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @OneToMany(mappedBy = "pedido")
    private List<Item> itens = new ArrayList<>();

    @JsonIgnore
    @OneToMany(mappedBy = "pedido", cascade = CascadeType.ALL)
    @OrderBy(value = "criadoEm")
    private List<StatusPedido> statusList;

    @JsonIgnore
    @ManyToOne
    @JoinFormula("(SELECT ST.ID " +
            " FROM TB_STATUS_PEDIDO ST " +
            " WHERE ST.PEDIDO_ID = ID AND ST.FINALIZADO_EM IS NULL)")
    private StatusPedido statusAtual;

    @JsonIgnore
    private Date criadoEm;

    public List<Status> alterarStatus(StatusAlterarDTO dto) {
        var status = novoStatus(dto);
        var statusRetorno = this.comparar(dto);
        if (this.statusAtual != null) {
            this.statusAtual.finalizar();
        }
        this.statusAtual = status;
        this.statusList.add(status);
        return statusRetorno;
    }

    private StatusPedido novoStatus(StatusAlterarDTO novoStatus) {
        var status = new StatusPedido();
        status.setPedido(this);
        status.setItensAprovados(novoStatus.getItensAprovados());
        status.setValorAprovado(novoStatus.getValorAprovado());
        status.setCriadoEm(new Date());
        status.setStatus(novoStatus.getStatus());
        return status;
    }

    public List<Status> comparar(StatusAlterarDTO novoStatus) {
        var retorno = new ArrayList<Status>();
        if (Status.REPROVADO == novoStatus.getStatus()) {
            return List.of(Status.REPROVADO);
        }
        testValorAprovado(novoStatus.getValorAprovado()).ifPresent(retorno::add);
        testQtdAprovada(novoStatus.getItensAprovados()).ifPresent(retorno::add);
        if (retorno.size() == 0) {
            return List.of(Status.APROVADO);
        }
        return retorno;
    }

    private Optional<Status> testQtdAprovada(Long novoQtdItensAprovados) {
        int comparacao = novoQtdItensAprovados.compareTo(this.getQtdTotalItens());
        if (comparacao > 0) {
            return Optional.of(Status.APROVADO_QTD_A_MAIOR);
        } else if (comparacao < 0) {
            return Optional.of(Status.APROVADO_QTD_A_MENOR);
        }
        return Optional.empty();
    }

    private Optional<Status> testValorAprovado(BigDecimal novoValorAprovado) {
        int comparacao = novoValorAprovado.compareTo(this.getValorTotal());
        if (comparacao > 0) {
            return Optional.of(Status.APROVADO_VALOR_A_MAIOR);
        } else if (comparacao < 0) {
            return Optional.of(Status.APROVADO_VALOR_A_MENOR);
        }
        return Optional.empty();
    }

    @JsonIgnore
    public Long getQtdTotalItens() {
        return this.itens.stream().mapToLong(Item::getQtd).sum();
    }

    @JsonIgnore
    public BigDecimal getValorTotal() {
        return this.itens.stream()
                .map(i -> i.getPrecoUnitario().multiply(BigDecimal.valueOf(i.getQtd())))
                .reduce(BigDecimal.ZERO, BigDecimal::add);
    }
}