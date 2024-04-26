using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Services
{
    public class TarefaDomainService : ITarefaDomainService
    {
        //atributo
        private readonly ITarefaRepository _tarefaRepository;

        //construtor para injeção de dependência
        public TarefaDomainService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public void CadastrarTarefa(Tarefa tarefa)
        {
            _tarefaRepository.Add(tarefa);
        }

        public void AtualizarTarefa(Tarefa tarefa)
        {
            _tarefaRepository.Update(tarefa);
        }

        public void ExcluirTarefa(Tarefa tarefa)
        {
            _tarefaRepository.Delete(tarefa);
        }

        public List<Tarefa> Consultar(DateTime dataMin, DateTime dataMax, Guid UsuarioId)
        {
            return _tarefaRepository.GetAll(dataMin, dataMax, UsuarioId);
        }

        public Tarefa? ObterPorId(Guid id)
        {
            return _tarefaRepository.GetById(id);
        }
    }
}
