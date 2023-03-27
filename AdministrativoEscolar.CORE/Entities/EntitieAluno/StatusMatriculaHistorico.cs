using AdministrativoEscolar.CORE.Entities.Base;

namespace AdministrativoEscolar.CORE.Entities
{
    public class StatusMatriculaHistorico : BaseEntitie
    {
        public int IdMatricula { get; set; }
        public int IdStatusMatricula { get; set; }
        public bool FlStatusAtual { get; set; }
        public virtual Matricula? Matricula { get; set; }
        public virtual StatusMatricula? StatusMatricula { get; set; }
    }
}
