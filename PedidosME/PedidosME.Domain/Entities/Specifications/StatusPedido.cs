using MercadoEletronico.Utilities.Enums;
using PedidosME.Domain.DTOs;
using PedidosME.Domain.PedidoAggregate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace PedidosME.Domain.Entities.Specifications
{
    public class StatusPedido
    {
        private readonly AtualizarStatusDTO atualizarStatusDTO;
        private enum StatusPedidoEnum
        {
            CODIGO_PEDIDO_INVALIDO = 1,
            REPROVADO = 2,
            APROVADO = 3,
            APROVADO_VALOR_A_MENOR = 4,
            APROVADO_QTD_A_MENOR = 5,
            APROVADO_VALOR_A_MAIOR = 6,
            APROVADO_QTD_A_MAIOR = 7

        }
        

        public StatusPedido(AtualizarStatusDTO atualizarStatusDTO)
        {
            this.atualizarStatusDTO = atualizarStatusDTO;
        }
        
        private bool PedidoInvalido(Pedido instance)
        {
            Expression<Func<Pedido, bool>> expression = f => f == null;
            var predicate = expression.Compile();
            return predicate(instance);
        }

        private bool PedidoReprovado(Pedido instance)
        {

            Expression<Func<Pedido, bool>> expression = f => f != null && 
                atualizarStatusDTO.Status == StatusPedidoEnum.REPROVADO.ToString();
            var predicate = expression.Compile();
            return predicate(instance);

        }

        private bool PedidoAprovado(Pedido instance)
        {

            Expression<Func<Pedido, bool>> expression = f => f != null &&
                        atualizarStatusDTO.ItensAprovados == f.Itens.Sum(x=> x.Quantidade) &&
                        atualizarStatusDTO.ValorAprovado == f.Itens.Sum(x => x.PrecoUnitario * x.Quantidade) &&
                        atualizarStatusDTO.Status == StatusPedidoEnum.APROVADO.ToString();
            var predicate = expression.Compile();
            return predicate(instance);
        }

        private bool PedidoAprovadoValorAMenor(Pedido instance)
        { 
            Expression<Func<Pedido,bool>> expression = f => f != null &&
                        atualizarStatusDTO.ValorAprovado < f.Itens.Sum(x => x.PrecoUnitario * x.Quantidade) &&
                        atualizarStatusDTO.Status == StatusPedidoEnum.APROVADO.ToString();
            var predicate = expression.Compile();
            return predicate(instance);
        }

        private bool PedidoAprovadoQuantidadeAMenor(Pedido instance)
        {
            Expression<Func<Pedido, bool>> expression = f => f != null &&
                        atualizarStatusDTO.ItensAprovados < f.Itens.Sum(x=> x.Quantidade) &&
                        atualizarStatusDTO.Status == StatusPedidoEnum.APROVADO.ToString();
            var predicate = expression.Compile();
            return predicate(instance);
        }

        private bool PedidoAprovadoValorAMaior(Pedido instance)
        {
            Expression<Func<Pedido, bool>> expression = f => f != null &&
                         atualizarStatusDTO.ValorAprovado > f.Itens.Sum(x => x.PrecoUnitario * x.Quantidade) &&
                         atualizarStatusDTO.Status == StatusPedidoEnum.APROVADO.ToString();
            var predicate = expression.Compile();
            return predicate(instance);
        }

        private bool PedidoAprovadoQuantidadeAMaior(Pedido instance)
        {
            Expression<Func<Pedido, bool>> expression = f => f != null &&
                        atualizarStatusDTO.ItensAprovados > f.Itens.Sum(x => x.Quantidade) &&
                        atualizarStatusDTO.Status == StatusPedidoEnum.APROVADO.ToString();
            var predicate = expression.Compile();
            return predicate(instance);
        }
        public IEnumerable<string> ObterStatus(Pedido instance)
        {
            var status = new List<string>();
            if (PedidoInvalido(instance)) status.Add(StatusPedidoEnum.CODIGO_PEDIDO_INVALIDO.ToString());
            if (PedidoReprovado(instance)) status.Add(StatusPedidoEnum.REPROVADO.ToString());
            if (PedidoAprovado(instance)) status.Add(StatusPedidoEnum.APROVADO.ToString());
            if (PedidoAprovadoValorAMenor(instance)) status.Add(StatusPedidoEnum.APROVADO_VALOR_A_MENOR.ToString());
            if (PedidoAprovadoQuantidadeAMenor(instance)) status.Add(StatusPedidoEnum.APROVADO_QTD_A_MENOR.ToString());
            if (PedidoAprovadoValorAMaior(instance)) status.Add(StatusPedidoEnum.APROVADO_VALOR_A_MAIOR.ToString());
            if (PedidoAprovadoQuantidadeAMaior(instance)) status.Add(StatusPedidoEnum.APROVADO_QTD_A_MAIOR.ToString());

            return status;
            
        }
    }
}
