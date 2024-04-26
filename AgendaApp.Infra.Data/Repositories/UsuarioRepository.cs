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
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Add(Usuario usuario)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(usuario);
                dataContext.SaveChanges();
            }
        }

        public Usuario? Get(string email)
        {
            using (var dataContext = new DataContext())
            {
                /*
                return dataContext.Set<Usuario>()
                    .Where(u => u.Email.Equals(email))
                    .FirstOrDefault();
                */

                var query = @"
                    SELECT * FROM USUARIO 
                    WHERE EMAIL = @Email
                ";

                return dataContext.Database.GetDbConnection()
                    .Query<Usuario>(query, new
                    {
                        @Email = email
                    }).FirstOrDefault();
            }
        }

        public Usuario? Get(string email, string senha)
        {
            using (var dataContext = new DataContext())
            {
                /*
                return dataContext.Set<Usuario>()
                    .Where(u => u.Email.Equals(email) && u.Senha.Equals(senha))
                    .FirstOrDefault();
                */

                var query = @"
                    SELECT * FROM USUARIO 
                    WHERE EMAIL = @Email AND SENHA = @Senha
                ";

                return dataContext.Database.GetDbConnection()
                    .Query<Usuario>(query, new
                    {
                        @Email = email,
                        @Senha = senha
                    }).FirstOrDefault();
            }
        }
    }
}



