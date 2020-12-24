package mercado.eletronico.backendchallenge.controller.v1;


import mercado.eletronico.backendchallenge.api.v1.model.BaseDTO;
import mercado.eletronico.backendchallenge.api.v1.model.PedidoDTO;
import mercado.eletronico.backendchallenge.service.PedidoService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.*;

@Controller
@RequestMapping("/api/pedido")
public class PedidoController {

    private final PedidoService pedidoService;

    public PedidoController(PedidoService pedidoService) {
        this.pedidoService = pedidoService;
    }

    @GetMapping
    public ResponseEntity<BaseDTO> getPedido(@RequestBody PedidoDTO pedido) {
        return new ResponseEntity<>(pedidoService.getPedido(pedido.getPedido()), HttpStatus.OK);
    }

    @PostMapping
    public ResponseEntity<BaseDTO> criaNovoPedido(@RequestBody PedidoDTO pedidoDTO) {
        return new ResponseEntity<>(pedidoService.criaNovoPedido(pedidoDTO), HttpStatus.CREATED);
    }

    @PutMapping
    public ResponseEntity<BaseDTO> editaPedido(@RequestBody PedidoDTO pedidoDTO) {
        return new ResponseEntity<>(pedidoService.editaPedido(pedidoDTO), HttpStatus.OK);
    }

    @DeleteMapping
    public ResponseEntity<BaseDTO> deletaPedido(@RequestBody PedidoDTO pedidoDTO) {
        return new ResponseEntity<>(pedidoService.deletaPedido(pedidoDTO), HttpStatus.OK);
    }

}
