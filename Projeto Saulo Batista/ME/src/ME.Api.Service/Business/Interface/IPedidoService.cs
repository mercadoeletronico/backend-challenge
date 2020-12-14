using ME.Api.Models.DataModels;
using ME.Api.Models.View.Pedido;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.Api.Service.Business.Interface
{
    public interface IPedidoService
    {

        IActionResult Get(PedidoGetAllRequest request);
        IActionResult Get(PedidoGetRequest request);
        IActionResult Post(Pedido request);
        IActionResult Update(PedidoUpdateRequest request);
        IActionResult Delete(PedidoDeleteRequest request);
        IActionResult PostStatus(PedidoStatusRequest request);
    }
}
