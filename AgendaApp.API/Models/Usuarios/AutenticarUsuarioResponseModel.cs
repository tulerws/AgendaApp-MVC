namespace AgendaApp.API.Models.Usuarios
{
    public class AutenticarUsuarioResponseModel
    {

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? AccessToken { get; set; }
        public DateTime? DataHoraAcesso { get; set; }
    }
}
