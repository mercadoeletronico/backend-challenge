using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using teste_me.Models.RequestModels;
using teste_me.Models.ResponseModels;
using teste_me.Services;
using Xunit;

namespace XUnitTestME
{
    
    public class FakeVerificaStatusAprovacao 
    {
        VerificaStatusAprovacao _statusAprovado;
        RequestModelMudancaStatusPedido _request;
        ResponseModelMudancaStatusPedido _response;
        public FakeVerificaStatusAprovacao()
        {
            _statusAprovado = new VerificaStatusAprovacao();
            _request = new RequestModelMudancaStatusPedido();
            _response = new ResponseModelMudancaStatusPedido();

        }
        [Fact]
        public void StatusAprovado()
        {
            _request.Status = "APROVADO";
            _request.ItensAprovados = 1;
            _request.ValorAprovado = 10;
            _statusAprovado.Verificar(_request, _response, 10, 1);

            Assert.Contains("APROVADO", _response.Status);
            
        }
        [Fact]
        public void StatusReprovado()
        {
            _request.Status = "REPROVADO";
            _request.ItensAprovados = 2;
            _request.ValorAprovado = 10;
            _statusAprovado.Verificar(_request, _response, 15, 1);

            Assert.Contains("REPROVADO", _response.Status);
        }
        [Fact]
        public void StatusNaoEncontrado()
        {
            _request.Status = "ARPOVADO";
            _request.ItensAprovados = 2;
            _request.ValorAprovado = 10;
            _statusAprovado.Verificar(_request, _response, 15, 1);

            Assert.Contains("STATUS_NAO_ENCONTRADO", _response.Status);
        }
        [Fact]
        public void StatusAprovadoQuantidadeMenor()
        {
            _request.Status = "APROVADO";
            _request.ItensAprovados = 1;
            _request.ValorAprovado = 10;
            _statusAprovado.Verificar(_request, _response, 10,2);

            Assert.Contains("APROVADO_QTD_A_MENOR", _response.Status);
        }
        [Fact]
        public void StatusAprovadoQuantidadeMaior()
        {
            _request.Status = "APROVADO";
            _request.ItensAprovados = 2;
            _request.ValorAprovado = 10;
            _statusAprovado.Verificar(_request, _response, 10, 1);

            Assert.Contains("APROVADO_QTD_A_MAIOR", _response.Status);
        }
        [Fact]
        public void StatusAprovadoValorMenor()
        {
            _request.Status = "APROVADO";
            _request.ItensAprovados = 2;
            _request.ValorAprovado = 10;
            _statusAprovado.Verificar(_request, _response, 15, 1);

            Assert.Contains("APROVADO_VALOR_A_MENOR", _response.Status);
        }
        [Fact]
        public void StatusAprovadoValorMaior()
        {
            _request.Status = "APROVADO";
            _request.ItensAprovados = 2;
            _request.ValorAprovado = 15;
            _statusAprovado.Verificar(_request, _response, 10, 1);

            Assert.Contains("APROVADO_VALOR_A_MAIOR", _response.Status);
        }
        [Fact]
        public void StatusAprovadoQuantidadeMaiorValorMaior()
        {
            _request.Status = "APROVADO";
            _request.ItensAprovados = 2;
            _request.ValorAprovado = 15;
            _statusAprovado.Verificar(_request, _response, 10, 1);

            List<string> status = new List<string>();
            status.Add("APROVADO_VALOR_A_MAIOR");
            status.Add("APROVADO_QTD_A_MAIOR");

            Assert.Equal(status, _response.Status);

        }
        [Fact]
        public void StatusAprovadoQuantidadeMenorValorMaior()
        {
            _request.Status = "APROVADO";
            _request.ItensAprovados = 1;
            _request.ValorAprovado = 15;
            _statusAprovado.Verificar(_request, _response, 10, 2);

            List<string> status = new List<string>();
            status.Add("APROVADO_QTD_A_MENOR");
            status.Add("APROVADO_VALOR_A_MAIOR");


            Assert.Equal(status, _response.Status);

        }
        [Fact]
        public void StatusAprovadoQuantidadeMaiorValorMenor()
        {
            _request.Status = "APROVADO";
            _request.ItensAprovados = 2;
            _request.ValorAprovado = 5;
            _statusAprovado.Verificar(_request, _response, 10, 1);

            List<string> status = new List<string>();
            status.Add("APROVADO_VALOR_A_MENOR");
            status.Add("APROVADO_QTD_A_MAIOR");

            Assert.Equal(status, _response.Status);

        }


    }
}
