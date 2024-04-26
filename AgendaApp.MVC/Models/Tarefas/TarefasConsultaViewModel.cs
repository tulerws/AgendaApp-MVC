using System.ComponentModel.DataAnnotations;

namespace AgendaApp.MVC.Models.Tarefas
{
    public class TarefasConsultaViewModel
    {
        [Required(ErrorMessage = "Por favor, informe a data de início.")]
        public DateTime? DataInicio { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de fim.")]
        public DateTime? DataFim { get; set; }
    }
}