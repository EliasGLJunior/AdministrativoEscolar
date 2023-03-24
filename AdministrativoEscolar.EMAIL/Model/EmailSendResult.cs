using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdministrativoEscolar.EMAIL.Model
{
    public record EmailSendResult
    {
        public bool Success => Error == null;
        public string Error { get; init; }
    }
}
