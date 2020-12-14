﻿using ME.Api.Models.DataModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace ME.Api.Models.View.Pedido
{
    public class PedidoGetRequest : IRequest<IActionResult>
    {
        public String NumPedido { get; set; }
    }
}
