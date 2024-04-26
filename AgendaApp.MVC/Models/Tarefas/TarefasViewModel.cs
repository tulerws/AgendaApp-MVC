namespace AgendaApp.MVC.Models.Tarefas
{
    public class TarefasViewModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public DateTime? DataHora { get; set; }
        public int? Prioridade { get; set; }
        public Guid? UsuarioId { get; set; }
    }
}