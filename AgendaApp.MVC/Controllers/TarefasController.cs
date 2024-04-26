using AgendaApp.MVC.Models.Tarefas;
using AgendaApp.MVC.Models.Usuario;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace AgendaApp.MVC.Controllers
{
    public class TarefasController : Controller
    {
        private string _apiEndpoint = "http://localhost:5032/api/tarefas";

        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(TarefasCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //capturar os dados da sessão e deserializar estes dados
                    var usuario = JsonConvert.DeserializeObject<UsuarioViewModel>
                        (HttpContext.Session.GetString("USUARIO"));

                    using (var httpClient = new HttpClient())
                    {
                        //adicionando o TOKEN no cabeçalho da requisição
                        httpClient.DefaultRequestHeaders.Authorization
                            = new AuthenticationHeaderValue("Bearer", usuario.AccessToken);

                        //serializando os dados que serão enviados para a API
                        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                        //enviando uma requisição para cadastro de tarefa
                        var response = httpClient.PostAsync(_apiEndpoint, content).Result;

                        if (response.IsSuccessStatusCode)
                        {
                            TempData["MensagemSucesso"] = $"Parabéns, {usuario.Nome}. Sua tarefa foi cadastrada com sucesso.";
                        }
                        else
                        {
                            TempData["MensagemErro"] = "Falha ao cadastrar tarefa";
                        }
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return View();
        }

        public IActionResult Consulta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Consulta(TarefasConsultaViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //capturar os dados da sessão e deserializar estes dados
                    var usuario = JsonConvert.DeserializeObject<UsuarioViewModel>
                        (HttpContext.Session.GetString("USUARIO"));

                    using (var httpClient = new HttpClient())
                    {
                        //adicionando o TOKEN no cabeçalho da requisição
                        httpClient.DefaultRequestHeaders.Authorization
                            = new AuthenticationHeaderValue("Bearer", usuario.AccessToken);

                        //enviando uma requisição para consulta de tarefas
                        var response = httpClient.GetAsync
                            ($"{_apiEndpoint}/{model.DataInicio?.ToString("yyyy-MM-dd")}/{model.DataFim?.ToString("yyyy-MM-dd")}")
                            .Result;

                        if (response.IsSuccessStatusCode)
                        {
                            //deserializar a lista de tarefas para exibir na página
                            TempData["Tarefas"] = JsonConvert.DeserializeObject<List<TarefasViewModel>>
                                (response.Content.ReadAsStringAsync().Result);
                        }
                        else
                        {
                            TempData["MensagemErro"] = "Falha ao consultar tarefa";
                        }
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = e.Message;
                }
            }

            return View();
        }
    }
}



