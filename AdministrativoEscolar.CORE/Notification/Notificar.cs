using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.CORE.Notification
{
    public abstract class Notificar
    {
        private readonly INotificador _notificador;
        public Notificar(INotificador notificador)
        {
            _notificador = notificador ?? throw new ArgumentNullException(nameof(notificador));
        }

        protected void NotificarErro(string mensagem)
        {
            _notificador.Handle(new Notificacao(mensagem));
        }
    }
}
