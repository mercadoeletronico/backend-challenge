using ME.Api.Settings.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ME.Api.Models.Enums
{
    public enum StatusPedido
    {
		[FriendlyName("APROVADO")]
		APROVADO = 0,

		[FriendlyName("APROVADO_VALOR_A_MENOR")]
		APROVADO_VALOR_A_MENOR = 1,	

		[FriendlyName("APROVADO_VALOR_A_MAIOR")]
		APROVADO_VALOR_A_MAIOR = 3,

		[FriendlyName("APROVADO_QTD_A_MAIOR")]
		APROVADO_QTD_A_MAIOR = 4,

		[FriendlyName("REPROVADO")]
		REPROVADO = 5,

		[FriendlyName("CODIGO_PEDIDO_INVALIDO")]
		CODIGO_PEDIDO_INVALIDO = 6,

		[FriendlyName("APROVADO_QTD_A_MENOR")]
		APROVADO_QTD_A_MENOR = 7	

	}
}
