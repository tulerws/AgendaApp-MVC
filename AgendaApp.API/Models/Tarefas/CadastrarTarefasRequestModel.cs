using AgendaApp.Domain.Enums;

namespace AgendaApp.API.Models.Tarefas
{
    public class CadastrarTarefasRequestModel
    {
        public string? Nome { get; set; }
        public DateTime? DataHora { get; set; }
        public int? Prioridade { get; set; }
    }
}
