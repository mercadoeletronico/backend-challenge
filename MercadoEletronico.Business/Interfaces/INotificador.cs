using System.Collections.Generic;

namespace MercadoEletronico.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();

        List<Notificacoes.Notificacao> ObterNotificacoes();

        void Adicionar(Notificacoes.Notificacao notificacao);

        void Adicionar(string notificacao);
    }
}
