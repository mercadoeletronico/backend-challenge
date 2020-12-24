package mercado.eletronico.backendchallenge.service;

import mercado.eletronico.backendchallenge.api.v1.mapper.PedidoMapper;
import mercado.eletronico.backendchallenge.api.v1.model.*;
import mercado.eletronico.backendchallenge.domain.Pedido;
import mercado.eletronico.backendchallenge.domain.Status;
import mercado.eletronico.backendchallenge.repository.ItemRepository;
import mercado.eletronico.backendchallenge.repository.PedidoRepository;
import mercado.eletronico.backendchallenge.utils.TestUtils;
import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.mockito.Mock;
import org.mockito.MockitoAnnotations;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.ArgumentMatchers.any;
import static org.mockito.Mockito.when;

class PedidoServiceImplTest {


    private PedidoService pedidoService;
    private PedidoMapper pedidoMapper = PedidoMapper.INSTANCE;
    @Mock
    private PedidoRepository pedidoRepository;
    @Mock
    private ItemRepository itemRepository;

    @BeforeEach
    void setUp() {
        MockitoAnnotations.openMocks(this);
        pedidoService = new PedidoServiceImpl(pedidoRepository, itemRepository, pedidoMapper);
    }

    @Test
    void criaNovoPedido() {
        PedidoDTO pedidoDTO = TestUtils.montaPedidoDTO();
        Pedido pedido = pedidoMapper.pedidoDTOToPedido(pedidoDTO);
        pedido.setId(TestUtils.ID_PEDIDO);

        when(pedidoRepository.existsByCodigoPedido(pedidoDTO.getPedido())).thenReturn(false);
        when(pedidoRepository.save(any(Pedido.class))).thenReturn(pedido);

        PedidoDTO responseDTO = (PedidoDTO) pedidoService.criaNovoPedido(pedidoDTO);
        assertEquals(pedidoDTO.getPedido(), responseDTO.getPedido());
        assertEquals(pedidoDTO.getItens().size(), responseDTO.getItens().size());
    }

    @Test
    void criaNovoPedidoQuandoPedidoExiste() {
        PedidoDTO pedidoDTO = TestUtils.montaPedidoDTO();
        when(pedidoRepository.existsByCodigoPedido(pedidoDTO.getPedido())).thenReturn(true);
        StatusDTO responseDTO = (StatusDTO) pedidoService.criaNovoPedido(pedidoDTO);
        assertEquals(pedidoDTO.getPedido(), responseDTO.getPedido());
        assertEquals(Status.CODIGO_PEDIDO_JA_EXISTE, responseDTO.getStatus().get(0));
    }

    @Test
    void criaNovoPedidoQuandoNumeroPedidoEhInvalido() {
        PedidoDTO pedidoDTO = TestUtils.montaPedidoDTO();
        pedidoDTO.setPedido(" ");
        StatusDTO responseDTO = (StatusDTO) pedidoService.criaNovoPedido(pedidoDTO);
        assertEquals(pedidoDTO.getPedido(), responseDTO.getPedido());
        assertEquals(Status.CODIGO_PEDIDO_INVALIDO, responseDTO.getStatus().get(0));
    }

    @Test
    void criaNovoPedidoQuandoItemEhInvalido() {
        PedidoDTO pedidoDTO = TestUtils.montaPedidoDTO();
        List<ItemDTO> itens = new ArrayList<>();
        itens.add(new ItemDTO());
        pedidoDTO.setItens(itens);

        Pedido pedido = pedidoMapper.pedidoDTOToPedido(pedidoDTO);
        pedido.setId(TestUtils.ID_PEDIDO);
        when(pedidoRepository.existsByCodigoPedido(pedidoDTO.getPedido())).thenReturn(false);

        StatusDTO responseDTO = (StatusDTO) pedidoService.criaNovoPedido(pedidoDTO);
        assertEquals(pedidoDTO.getPedido(), responseDTO.getPedido());
        assertEquals(Status.ITENS_INVALIDOS, responseDTO.getStatus().get(0));
    }

    @Test
    void getPedido() {
        Pedido pedido = TestUtils.montaPedido();
        when(pedidoRepository.findByCodigoPedido(TestUtils.NUMERO_PEDIDO)).thenReturn(pedido);
        PedidoDTO responseDTO = (PedidoDTO) pedidoService.getPedido(TestUtils.NUMERO_PEDIDO);
        assertEquals(TestUtils.NUMERO_PEDIDO, responseDTO.getPedido());
    }

    @Test
    void getPedidoQuandoNumeroPedidoEhInvalido() {
        when(pedidoRepository.findByCodigoPedido(TestUtils.NUMERO_PEDIDO)).thenReturn(null);
        StatusDTO responseDTO = (StatusDTO) pedidoService.getPedido(TestUtils.NUMERO_PEDIDO);
        assertEquals(TestUtils.NUMERO_PEDIDO, responseDTO.getPedido());
        assertEquals(Status.CODIGO_PEDIDO_INVALIDO, responseDTO.getStatus().get(0));
    }

    @Test
    void atualizaStatusAprovado() {
        StatusUpdateDTO statusUpdateDTO = TestUtils.montaStatusUpdateDTO();
        Pedido pedido = TestUtils.montaPedido();
        when(pedidoRepository.findByCodigoPedido(statusUpdateDTO.getPedido())).thenReturn(pedido);
        StatusDTO statusDTO = (StatusDTO) pedidoService.atualizaStatus(statusUpdateDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, statusDTO.getPedido());
        assertEquals(Status.APROVADO, statusDTO.getStatus().get(0));
    }

    @Test
    void atualizaStatusAprovadoValorAMenor() {
        StatusUpdateDTO statusUpdateDTO = TestUtils.montaStatusUpdateDTO();
        statusUpdateDTO.setValorAprovado(150.0);
        Pedido pedido = TestUtils.montaPedido();
        when(pedidoRepository.findByCodigoPedido(statusUpdateDTO.getPedido())).thenReturn(pedido);
        StatusDTO statusDTO = (StatusDTO) pedidoService.atualizaStatus(statusUpdateDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, statusDTO.getPedido());
        assertEquals(Status.APROVADO_VALOR_A_MENOR, statusDTO.getStatus().get(0));
    }

    @Test
    void atualizaStatusAprovadoValorAMaior() {
        StatusUpdateDTO statusUpdateDTO = TestUtils.montaStatusUpdateDTO();
        statusUpdateDTO.setValorAprovado(170.0);
        Pedido pedido = TestUtils.montaPedido();
        when(pedidoRepository.findByCodigoPedido(statusUpdateDTO.getPedido())).thenReturn(pedido);
        StatusDTO statusDTO = (StatusDTO) pedidoService.atualizaStatus(statusUpdateDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, statusDTO.getPedido());
        assertEquals(Status.APROVADO_VALOR_A_MAIOR, statusDTO.getStatus().get(0));
    }

    @Test
    void atualizaStatusAprovadoQtdAMenor() {
        StatusUpdateDTO statusUpdateDTO = TestUtils.montaStatusUpdateDTO();
        statusUpdateDTO.setItensAprovados(1);
        Pedido pedido = TestUtils.montaPedido();
        when(pedidoRepository.findByCodigoPedido(statusUpdateDTO.getPedido())).thenReturn(pedido);
        StatusDTO statusDTO = (StatusDTO) pedidoService.atualizaStatus(statusUpdateDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, statusDTO.getPedido());
        assertEquals(Status.APROVADO_QTD_A_MENOR, statusDTO.getStatus().get(0));
    }

    @Test
    void atualizaStatusAprovadoQtdAMaior() {
        StatusUpdateDTO statusUpdateDTO = TestUtils.montaStatusUpdateDTO();
        statusUpdateDTO.setItensAprovados(3);
        Pedido pedido = TestUtils.montaPedido();
        when(pedidoRepository.findByCodigoPedido(statusUpdateDTO.getPedido())).thenReturn(pedido);
        StatusDTO statusDTO = (StatusDTO) pedidoService.atualizaStatus(statusUpdateDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, statusDTO.getPedido());
        assertEquals(Status.APROVADO_QTD_A_MAIOR, statusDTO.getStatus().get(0));
    }

    @Test
    void atualizaStatusReprovado() {
        StatusUpdateDTO statusUpdateDTO = TestUtils.montaStatusUpdateDTO();
        statusUpdateDTO.setStatus(Status.REPROVADO.name());
        Pedido pedido = TestUtils.montaPedido();
        when(pedidoRepository.findByCodigoPedido(statusUpdateDTO.getPedido())).thenReturn(pedido);
        StatusDTO statusDTO = (StatusDTO) pedidoService.atualizaStatus(statusUpdateDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, statusDTO.getPedido());
        assertEquals(Status.REPROVADO, statusDTO.getStatus().get(0));
    }

    @Test
    void atualizaStatusQuandoStatusEhInvalido() {
        StatusUpdateDTO statusUpdateDTO = TestUtils.montaStatusUpdateDTO();
        statusUpdateDTO.setStatus(Status.STATUS_INVALIDO.name());
        Pedido pedido = TestUtils.montaPedido();
        when(pedidoRepository.findByCodigoPedido(statusUpdateDTO.getPedido())).thenReturn(pedido);
        StatusDTO statusDTO = (StatusDTO) pedidoService.atualizaStatus(statusUpdateDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, statusDTO.getPedido());
        assertEquals(Status.STATUS_INVALIDO, statusDTO.getStatus().get(0));
    }

    @Test
    void atualizaStatusQuandoNumeroPedidoEhInvalido() {
        StatusUpdateDTO statusUpdateDTO = TestUtils.montaStatusUpdateDTO();
        when(pedidoRepository.findByCodigoPedido(statusUpdateDTO.getPedido())).thenReturn(null);
        StatusDTO statusDTO = (StatusDTO) pedidoService.atualizaStatus(statusUpdateDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, statusDTO.getPedido());
        assertEquals(Status.CODIGO_PEDIDO_INVALIDO, statusDTO.getStatus().get(0));
    }

    @Test
    void editaPedidoQuandoNumeroPedidoEhInvalido() {
        PedidoDTO pedidoDTO = TestUtils.montaPedidoDTO();
        when(pedidoRepository.findByCodigoPedido(pedidoDTO.getPedido())).thenReturn(null);
        StatusDTO responseDTO = (StatusDTO) pedidoService.editaPedido(pedidoDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, responseDTO.getPedido());
        assertEquals(Status.CODIGO_PEDIDO_INVALIDO, responseDTO.getStatus().get(0));

    }

    @Test
    void editaPedido() {
        PedidoDTO pedidoDTO = TestUtils.montaPedidoDTO();
        Pedido pedido = TestUtils.montaPedido();
        when(pedidoRepository.findByCodigoPedido(pedidoDTO.getPedido())).thenReturn(pedido);
        when(pedidoRepository.save(pedido)).thenReturn(pedido);
        PedidoDTO responseDTO = (PedidoDTO) pedidoService.editaPedido(pedidoDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, responseDTO.getPedido());
        assertEquals(pedidoDTO.getItens().size(), responseDTO.getItens().size());
    }

    @Test
    void editaPedidoQuandoNaoPossuiItens() {
        PedidoDTO pedidoDTO = TestUtils.montaPedidoDTO();
        pedidoDTO.setItens(new ArrayList<>());
        Pedido pedido = TestUtils.montaPedido();
        when(pedidoRepository.findByCodigoPedido(pedidoDTO.getPedido())).thenReturn(pedido);
        when(pedidoRepository.save(pedido)).thenReturn(pedido);
        StatusDTO responseDTO = (StatusDTO) pedidoService.editaPedido(pedidoDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, responseDTO.getPedido());
        assertEquals(Status.ITENS_INVALIDOS, responseDTO.getStatus().get(0));
    }

    @Test
    void deletaPedidoQuandoNumeroPedidoEhInvalido() {
        PedidoDTO pedidoDTO = TestUtils.montaPedidoDTO();
        when(pedidoRepository.findByCodigoPedido(pedidoDTO.getPedido())).thenReturn(null);
        StatusDTO statusDTO = (StatusDTO) pedidoService.deletaPedido(pedidoDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, statusDTO.getPedido());
        assertEquals(Status.CODIGO_PEDIDO_INVALIDO, statusDTO.getStatus().get(0));
    }

    @Test
    void deletaPedido() {
        PedidoDTO pedidoDTO = TestUtils.montaPedidoDTO();
        Pedido pedido = TestUtils.montaPedido();
        when(pedidoRepository.findByCodigoPedido(pedidoDTO.getPedido())).thenReturn(pedido);
        StatusDTO statusDTO = (StatusDTO) pedidoService.deletaPedido(pedidoDTO);
        assertEquals(TestUtils.NUMERO_PEDIDO, statusDTO.getPedido());
        assertEquals(Status.PEDIDO_DELETADO, statusDTO.getStatus().get(0));
    }


}