using MinhaApiCompleta.Business.Notificacoes;
using System.Collections.Generic;

namespace MinhaApiCompleta.Business.Intefaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
