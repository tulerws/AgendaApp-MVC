using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Helpers;
using AgendaApp.Domain.Interfaces.Repositories;
using AgendaApp.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        //atributo
        private readonly IUsuarioRepository _usuarioRepository;

        //construtor para injeção de dependência
        public UsuarioDomainService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public void CriarUsuario(Usuario usuario)
        {
            //verificar se já existe um usuário cadastrado com o email informado
            if(_usuarioRepository.Get(usuario.Email) != null)
                throw new ApplicationException("O email informado já está cadastrado, tente outro.");

                //criptografar a senha do usuário
                usuario.Senha = Sha256CryptoHelper.CalculateSHA256(usuario.Senha);

                //gravando o usuário no banco de dados
                _usuarioRepository.Add(usuario);
        }


        public Usuario? AutenticarUsuario(string email, string senha)
        {
            //consultar 1 usuário no banco de dados através do email e da senha
            var usuario = _usuarioRepository.Get(email, Sha256CryptoHelper.CalculateSHA256(senha));

            if (usuario == null)
                throw new ApplicationException("Acesso negado. Usuário não encontrado.");

            return usuario;
        }

 
    }
}
