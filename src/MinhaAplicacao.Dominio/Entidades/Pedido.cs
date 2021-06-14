using System.Collections.Generic;
using System.Linq;

namespace MinhaAplicacao.Dominio.Entidades
{
    public class Pedido : EntidadeBase<int>
    {
        public Pedido()
        {
        }

        public Pedido(string numero)
        {
            this.Numero = numero;
        }

        public string Numero { get; set; }

        public virtual IEnumerable<ItemPedido> ItensPedidos { get; set; }

        public void Atualizar(Pedido pedido)
        {
            this.Numero = pedido.Numero;
        }

        #region Itens Aprovados

        public bool ValidarIgualItemAprovado(int itensAprovados)
        {
            return itensAprovados == this.CalcularQuantidadeTotal();
        }

        public bool ValidarMenorItemAprovado(int itensAprovados)
        {
            return itensAprovados < this.CalcularQuantidadeTotal();
        }

        public bool ValidarMaiorItemAprovado(int itensAprovados)
        {
            return itensAprovados > this.CalcularQuantidadeTotal();
        }

        #endregion

        #region Valor Aprovado

        public bool ValidarIgualValorAprovado(decimal valorAprovado)
        {
            return valorAprovado == this.CalcularValorTotal();
        }

        public bool ValidarMenorValorAprovado(decimal valorAprovado)
        {
            return valorAprovado < this.CalcularValorTotal();
        }

        public bool ValidarMaiorValorAprovado(decimal valorAprovado)
        {
            return valorAprovado > this.CalcularValorTotal();
        }

        #endregion

        private decimal CalcularValorTotal()
        {
            return this.ItensPedidos.Sum(ip => ip.PrecoUnitario * ip.Quantidade);
        }

        private decimal CalcularQuantidadeTotal()
        {
            return this.ItensPedidos.Sum(ip => ip.Quantidade);
        }
    }
}
