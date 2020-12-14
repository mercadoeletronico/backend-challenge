using ME.Api.Data;
using ME.Api.Models.DataModels;
using ME.Api.Models.Enums;
using ME.Api.Models.View.Pedido;
using ME.Api.Service.Business.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ME.Api.Service.Business.Service
{
    public class PedidoService : IPedidoService
    {

        private readonly ApiDbContext _context;
        public PedidoService(ApiDbContext context)
        {
            _context = context;
        }

        public IActionResult PostStatus(PedidoStatusRequest request)
        {
            try
            {

                var objPedido = _context.Pedidos.Where(x => x.NumPedido == request.NumPedido).FirstOrDefault();

                if (objPedido != null)
                {
                    return new OkObjectResult(ParseViewModel(request, objPedido));
                }
                else
                    throw new Exception("Pedido não existe!");
            }
            catch (Exception err)
            {
                return new BadRequestObjectResult(new { message = err.Message });
            }
        }

        public IActionResult Get(PedidoGetRequest request)
        {
            try
            {
                Pedido objPedido = _context.Pedidos.Include("Itens").Where(x => x.NumPedido == request.NumPedido).FirstOrDefault();
                if (objPedido != null)
                    return new OkObjectResult(objPedido);
                else
                    throw new Exception("Pedido Inexistente!");
            }
            catch (Exception err)
            {
                return new BadRequestObjectResult(new { message = err.Message });
            }
        }

        public IActionResult Post(Pedido request)
        {
            try
            {
                bool existePedido = _context.Pedidos.Include("Itens").Where(x => x.NumPedido == request.NumPedido).Any();

                if (!existePedido)
                {
                    _context.Pedidos.Add(request);
                    _context.SaveChanges();
                    return new OkObjectResult(request);
                }
                else
                    throw new Exception("Pedido já existe!");

            }
            catch (Exception err)
            {
                return new BadRequestObjectResult(new { message = err.Message });
            }
        }

        private static PedidoStatusViewModel ParseViewModel(PedidoStatusRequest request, Pedido obj)
        {
            var pedido = new PedidoStatusViewModel();
            pedido.NumPedido = request.NumPedido;
            pedido.Status = new List<string>();

            //pedido não for localizado no banco de dados.
            if (obj == null)
            {
                pedido.Status.Add(StatusPedido.CODIGO_PEDIDO_INVALIDO.ToString());

            }

            //pedido for localizado no banco de dados.
            //status for igual a REPROVADO
            if (obj != null && request.Status == "REPROVADO")
            {
                pedido.Status.Add(StatusPedido.REPROVADO.ToString());

            }


            //pedido for localizado no banco de dados.
            //itensAprovados for igual a quantidade de itens do pedido.
            //valorAprovado for igual o valor total do pedido.
            //status for igual a APROVADO.
            if (obj != null &&
                request.Status == "APROVADO" &&
                request.ItensAprovados == obj.Itens.Count &&
                request.ValorAprovado == obj.Itens.Sum(x => x.PrecoUnitario))
            {
                pedido.Status.Add(StatusPedido.APROVADO.ToString());

            }


            //pedido for localizado no banco de dados.
            //valorAprovado for menor que o valor total do pedido
            //status for igual a APROVADO
            if (obj != null &&
            request.Status == "APROVADO" &&

            request.ValorAprovado < obj.Itens.Sum(x => x.PrecoUnitario))
            {
                pedido.Status.Add(StatusPedido.APROVADO_VALOR_A_MENOR.ToString());

            }

            //pedido for localizado no banco de dados.
            //valorAprovado for menor que o valor total do pedido
            //status for igual a APROVADO
            if (obj != null &&
            request.Status == "APROVADO" &&
            request.ValorAprovado > obj.Itens.Sum(x => x.PrecoUnitario))
            {
                pedido.Status.Add(StatusPedido.APROVADO_VALOR_A_MAIOR.ToString());

            }

            //pedido for localizado no banco de dados.
            //itensAprovados for maior que a quantidade de itens do pedido.
            //status for igual a APROVADO
            if (obj != null &&
               request.Status == "APROVADO" &&
               request.ItensAprovados > obj.Itens.Count)
            {
                pedido.Status.Add(StatusPedido.APROVADO_QTD_A_MAIOR.ToString());

            }
            return pedido;
        }

        public IActionResult Update(PedidoUpdateRequest request)
        {
            try
            {
                bool existePedido = _context.Pedidos.Where(x => x.NumPedido == request.NumPedido).Any();

                if (existePedido)
                {
                    var pedido = _context.Pedidos.Where(x => x.NumPedido == request.NumPedido).FirstOrDefault();

                    bool existeNovoNumeroPedido = _context.Pedidos.Where(x => x.NumPedido == request.NovoNumPedido).Any();
                    if (!existeNovoNumeroPedido)
                    {
                        pedido.NumPedido = request.NovoNumPedido;
                        _context.SaveChanges();
                        return new OkObjectResult(request);
                    }
                    else
                        throw new Exception("Número do novo Pedido já existe!");
                }
                else
                    throw new Exception("Pedido não existe!");

            }
            catch (Exception err)
            {
                return new BadRequestObjectResult(new { message = err.Message });
            }
        }

        public IActionResult Delete(PedidoDeleteRequest request)
        {
            try
            {
                bool existePedido = _context.Pedidos.Where(x => x.NumPedido == request.NumPedido).Any();

                if (existePedido)
                {
                    var pedido = _context.Pedidos.Where(x => x.NumPedido == request.NumPedido).FirstOrDefault();
                    _context.Pedidos.Remove(pedido);
                    _context.SaveChanges();
                    return new OkObjectResult(request);

                }
                else
                    throw new Exception("Pedido não existe!");

            }
            catch (Exception err)
            {
                return new BadRequestObjectResult(new { message = err.Message });
            }
        }

        public IActionResult Get(PedidoGetAllRequest request)
        {
            try
            {
                var objPedido = _context.Pedidos.Include("Itens").AsQueryable();
                if (objPedido != null)
                    return new OkObjectResult(objPedido);
                else
                    throw new Exception("Não existe pedidos!");
            }
            catch (Exception err)
            {
                return new BadRequestObjectResult(new { message = err.Message });
            }
        }
    }
}
