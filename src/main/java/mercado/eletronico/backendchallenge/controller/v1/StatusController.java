package mercado.eletronico.backendchallenge.controller.v1;


import mercado.eletronico.backendchallenge.api.v1.model.BaseDTO;
import mercado.eletronico.backendchallenge.api.v1.model.StatusUpdateDTO;
import mercado.eletronico.backendchallenge.service.PedidoService;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;

@Controller
@RequestMapping("/api/status")
public class StatusController {

    private final PedidoService pedidoService;

    public StatusController(PedidoService pedidoService) {
        this.pedidoService = pedidoService;
    }

    @PostMapping
    public ResponseEntity<BaseDTO> atualizaStatus(@RequestBody StatusUpdateDTO statusUpdateDTO) {
        return new ResponseEntity<>(pedidoService.atualizaStatus(statusUpdateDTO), HttpStatus.OK);
    }
}
