using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Repositories
{
    public interface ITarefaRepository
    {
        void Add(Tarefa tarefa);
        void Update(Tarefa tarefa);
        void Delete(Tarefa tarefa);

        List<Tarefa>? GetAll(DateTime dataMin, DateTime dataMax, Guid UsuarioId);
        Tarefa? GetById(Guid id);

    }
}
