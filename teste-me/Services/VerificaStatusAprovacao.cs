using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using teste_me.Models.RequestModels;
using teste_me.Models.ResponseModels;

namespace teste_me.Services
{
    public class VerificaStatusAprovacao
    {
        public void Verificar(RequestModelMudancaStatusPedido request, ResponseModelMudancaStatusPedido response, decimal valorTotal, int quantidadeItens)
        {
            if (request.Status.Contains("REPROVADO"))
            {
                response.Status.Add("REPROVADO");
            }
            else if (true)
            {
                if (request.ItensAprovados == quantidadeItens && request.ValorAprovado == valorTotal)
                {
                    response.Status.Add("APROVADO");
                }
                if (request.ValorAprovado < valorTotal && request.Status.Contains("APROVADO"))
                {
                    response.Status.Add("APROVADO_VALOR_A_MENOR");
                }
                if (request.ItensAprovados < quantidadeItens && request.Status.Contains("APROVADO"))
                {
                    response.Status.Add("APROVADO_QTD_A_MENOR");
                }
                if (request.ValorAprovado > valorTotal && request.Status.Contains("APROVADO"))
                {
                    response.Status.Add("APROVADO_VALOR_A_MAIOR");
                }
                if (request.ItensAprovados > quantidadeItens && request.Status.Contains("APROVADO"))
                {
                    response.Status.Add("APROVADO_QTD_A_MAIOR");
                }

            }
            if (response.Status.Count == 0)
            {
                response.Status.Add("STATUS_NAO_ENCONTRADO");
            }
        }
    }
}
