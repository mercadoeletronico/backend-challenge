using System.Collections.Generic;
using System.Linq;

namespace MercadoEletronico.Business.Notificacoes
{
    public class Notificador : Interfaces.INotificador
    {
        private List<Notificacao> _Notificacoes;

        public Notificador()
        {
            _Notificacoes = new List<Notificacao>();
        }

        public void Adicionar(Notificacao notificacao)
        {
            _Notificacoes.Add(notificacao);
        }

        public void Adicionar(string notificacao)
        {
            _Notificacoes.Add(new Notificacao(notificacao));
        }

        public List<Notificacao> ObterNotificacoes()
        {
            return _Notificacoes;
        }

        public bool TemNotificacao()
        {
            return _Notificacoes.Any();
        }
    }
}