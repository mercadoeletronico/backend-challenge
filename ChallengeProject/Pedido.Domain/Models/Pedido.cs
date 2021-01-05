using System;
using System.Collections.Generic;
using System.Linq;

namespace Pedido.Domain.Models
{
    public class Pedido: Entidade
    {
        public Pedido()
        {
            ItemPedidos = new List<ItemPedido>();            

        }
        public long Id { get; private set; }

        public String NumeroPedido { get; set; }

        public IList<Status> StatusPedido { get; set; }

        public IList<ItemPedido> ItemPedidos { get; private set; }

        public void AddItemPedido(ItemPedido _item)
        {
            ItemPedidos.Add(_item);
        }

        public int QuantidadeItens()
        {
            return ItemPedidos.Sum(x => x.Quantidade);
        }

        public decimal TotalPedido()
        {
            return this.ItemPedidos
                .Select(x => x.PrecoUnitario * x.Quantidade)
                .Sum();
        }

        public Pedido AlterarStatusPedido(PedidoStatusRequest pedidoStatusRequest)
        {

            if (pedidoStatusRequest.Status == Status.REPROVADO)
                this.StatusPedido.Add(Status.REPROVADO);
            else
            {
                this.StatusPedido.Add(Status.APROVADO);


                if (this.ItemPedidos.Count() < pedidoStatusRequest.ItensAprovados)
                    this.StatusPedido.Add(Status.APROVADO_QTD_A_MAIOR);

                if (this.ItemPedidos.Count() > pedidoStatusRequest.ItensAprovados)
                    this.StatusPedido.Add(Status.APROVADO_QTD_A_MENOR);


                if (this.TotalPedido() < pedidoStatusRequest.ValorAprovado)                
                    this.StatusPedido.Add(Status.APROVADO_QTD_A_MENOR);                
                    
            }

            return this;
            
        }
        
        public Boolean IsValido()
        {
           return new Validators.ValidatorPedido().Validate(this).IsValid;
        }


    }

    public enum Status    
    {
        APROVADO,
        REPROVADO,
        CODIGO_PEDIDO_INVALIDO,
        VALOR_APROVADO_A_MENOR,
        APROVADO_QTD_A_MENOR,
        APROVADO_VALOR_A_MAIOR, 
        APROVADO_QTD_A_MAIOR

    }

}
