using AgendaApp.API.Models.Tarefas;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Enums;
using AgendaApp.Domain.Interfaces.Services;
using AgendaApp.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AgendaApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefaDomainService _tarefaDomainService;

        public TarefasController(ITarefaDomainService tarefaDomainService)
        {
            _tarefaDomainService = tarefaDomainService;
        }

        [HttpPost]
        public IActionResult Post(CadastrarTarefasRequestModel model)
        {
            try
            {
                var tarefa = new Tarefa
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    DataHora = model.DataHora,
                    Prioridade = (PrioridadeTarefa)model.Prioridade,
                    UsuarioId = Guid.Parse(User.Identity.Name)
                };

                _tarefaDomainService.CadastrarTarefa(tarefa);

                return StatusCode(201, new { Mensagem = "Tarefa cadastrada com sucesso" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(EditarTarefasRequestModel model)
        {
            try
            {
                var tarefa = new Tarefa
                {
                    Id = model.Id.Value,
                    Nome = model.Nome,
                    DataHora = model.DataHora,
                    Prioridade = (PrioridadeTarefa)model.Prioridade,
                    UsuarioId = Guid.Parse(User.Identity.Name)
                };

                _tarefaDomainService.AtualizarTarefa(tarefa);

                return StatusCode(201, new { Mensagem = "Tarefa atualizada com sucesso" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var tarefa = _tarefaDomainService.ObterPorId(id);
                _tarefaDomainService.ExcluirTarefa(tarefa);

                return StatusCode(201, new { Mensagem = "Tarefa excluída com sucesso" });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{dataMin}/{dataMax}")]
        public IActionResult GetAll(DateTime dataMin, DateTime dataMax)
        {
            try
            {
                var tarefas = _tarefaDomainService.Consultar(dataMin, dataMax, Guid.Parse(User.Identity.Name));
                var response = new List<ConsultarTarefasResponseModel>();

                foreach (var item in tarefas)
                {
                    response.Add(new ConsultarTarefasResponseModel
                    {
                        Id = item.Id,
                        Nome = item.Nome,
                        DataHora = item.DataHora,
                        Prioridade = (int)item.Prioridade,
                        UsuarioId = item.UsuarioId
                    });
                }

                return StatusCode(200, tarefas);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var tarefa = _tarefaDomainService.ObterPorId(id);

                var response = new ConsultarTarefasResponseModel
                {
                    Id = tarefa.Id,
                    Nome = tarefa.Nome,
                    DataHora = tarefa.DataHora,
                    Prioridade = (int)tarefa.Prioridade,
                    UsuarioId = tarefa.UsuarioId
                };

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}



