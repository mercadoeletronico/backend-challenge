using System;
using System.Collections.Generic;
using System.Text;

namespace ME.Pedido.Domain
{
    public enum PedidoStatus
    {
        PENDENTE = 0,
        APROVADO = 10,
        APROVADO_VALOR_A_MENOR = 11,
        APROVADO_VALOR_A_MAIOR = 12,
        APROVADO_QTD_A_MENOR = 13,
        APROVADO_QTD_A_MAIOR = 14,
        REPROVADO = 20
    }
}
