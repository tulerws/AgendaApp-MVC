using AgendaApp.API.Models.Usuarios;
using AgendaApp.API.Security;
using AgendaApp.Domain.Entities;
using AgendaApp.Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioDomainService _usuarioDomainService;

        public UsuariosController(IUsuarioDomainService usuarioDomainService)
        {
            _usuarioDomainService = usuarioDomainService;
        }

        [Route("criar")]
        [HttpPost]
        public IActionResult Criar(CriarUsuarioRequestModel model)
        {
            try
            {
                var usuario = new Usuario
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = model.Senha
                };

                _usuarioDomainService.CriarUsuario(usuario);

                var response = new CriarUsuarioResponseModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    DataHoraCadastro = DateTime.Now
                };

                return StatusCode(201, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(400, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [Route("autenticar")]
        [HttpPost]
        public IActionResult Autenticar(AutenticarUsuarioRequestModel model)
        {
            try
            {
                var usuario = _usuarioDomainService.AutenticarUsuario(model.Email, model.Senha);

                var response = new AutenticarUsuarioResponseModel
                {
                    Id = usuario.Id,
                    Nome = usuario.Nome,
                    Email = usuario.Email,
                    AccessToken = TokenSecurity.GenerateToken(usuario.Id),
                    DataHoraAcesso = DateTime.Now
                };

                return StatusCode(200, response);
            }
            catch (ApplicationException e)
            {
                return StatusCode(401, new { e.Message });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

    }
}



