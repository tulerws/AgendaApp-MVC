using System.ComponentModel.DataAnnotations;

namespace AgendaApp.MVC.Models.Tarefas
{
    public class TarefasCadastroViewModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome da tarefa.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data e hora da tarefa.")]
        public DateTime? DataHora { get; set; }

        [Required(ErrorMessage = "Por favor, informe a prioridade da tarefa.")]
        public int? Prioridade { get; set; }
    }
}



