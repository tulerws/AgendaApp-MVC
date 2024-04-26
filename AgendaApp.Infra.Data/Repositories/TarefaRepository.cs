using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Infra.Data.Contexts;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Infra.Data.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        public void Add(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(tarefa);
                dataContext.SaveChanges();
            }
        }

        public void Update(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(tarefa);
                dataContext.SaveChanges();
            }
        }

        public void Delete(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(tarefa);
                dataContext.SaveChanges();
            }
        }

        public List<Tarefa>? GetAll(DateTime dataMin, DateTime dataMax, Guid usuarioId)
        {
            using (var dataContext = new DataContext())
            {
                /*
                return dataContext.Set<Tarefa>()
                    .Where(t => t.DataHora >= dataMin && t.DataHora <= dataMax && t.UsuarioId == usuarioId)
                    .OrderBy(t => t.DataHora)
                    .ToList();
                */

                var query = @"
                    SELECT 
                        ID          as Id,
                        NOME        as Nome,
                        DATAHORA    as DataHora,
                        PRIORIDADE  as Prioridade,
                        USUARIO_ID  as UsuarioId
                    FROM TAREFA 
                    WHERE DATAHORA BETWEEN @DataMin AND @DataMax AND USUARIO_ID = @UsuarioId
                    ORDER BY DATAHORA
                ";

                return dataContext.Database.GetDbConnection()
                    .Query<Tarefa>(query, new
                    {
                        @DataMin = dataMin,
                        @DataMax = dataMax,
                        @UsuarioId = usuarioId
                    }).ToList();
            }
        }

        public Tarefa? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                /*
                    return dataContext.Set<Tarefa>().Find(id);
                */

                var query = @"
                    SELECT 
                        ID          as Id,
                        NOME        as Nome,
                        DATAHORA    as DataHora,
                        PRIORIDADE  as Prioridade,
                        USUARIO_ID  as UsuarioId
                    FROM TAREFA 
                    WHERE ID = @Id
                ";

                return dataContext.Database.GetDbConnection()
                    .Query<Tarefa>(query, new
                    {
                        @Id = id
                    }).FirstOrDefault();
            }
        }
    }
}



