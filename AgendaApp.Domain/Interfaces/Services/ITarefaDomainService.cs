using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Services
{
    public interface ITarefaDomainService
    {
        void CadastrarTarefa(Tarefa tarefa);
        void AtualizarTarefa(Tarefa tarefa);
        void ExcluirTarefa(Tarefa tarefa);

        List<Tarefa> Consultar(DateTime dataMin,  DateTime dataMax, Guid UsuarioId);
        Tarefa? ObterPorId(Guid id);
    }
}
