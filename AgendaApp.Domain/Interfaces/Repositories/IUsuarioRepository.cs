using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        void Add(Usuario usuario);

        Usuario? Get(string email);
        Usuario? Get(string email, string senha);
    }
}
