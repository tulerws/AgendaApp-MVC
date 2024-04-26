using AgendaApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Interfaces.Services
{
    public interface IUsuarioDomainService
    {
        void CriarUsuario(Usuario usuario);
        Usuario? AutenticarUsuario(string email, string senha);
    }
}
