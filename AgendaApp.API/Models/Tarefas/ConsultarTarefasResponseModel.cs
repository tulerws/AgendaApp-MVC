namespace AgendaApp.API.Models.Tarefas
{
    public class ConsultarTarefasResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataHora { get; set; }
        public int? Prioridade { get; set; }
        public Guid? UsuarioId { get; set; }
    }
}
