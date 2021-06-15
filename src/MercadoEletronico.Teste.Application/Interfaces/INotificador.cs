using MercadoEletronico.Teste.Application.Notificacoes;
using System.Collections.Generic;

namespace MercadoEletronico.Teste.Application.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}