using AdministrativoEscolar.CORE.Entities.Base;

namespace AdministrativoEscolar.CORE.Entities
{
    public class StatusUsuarioHistorico : BaseEntitie
    {
        public int IdUsuario { get; set; }
        public int IdStatusUsuario { get; set; }
        public bool FlStatusAtual { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual StatusUsuario? StatusUsuario { get; set; }
    }
}
