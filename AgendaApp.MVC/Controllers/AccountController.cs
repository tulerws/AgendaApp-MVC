using AgendaApp.MVC.Models.Account;
using AgendaApp.MVC.Models.Errors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AgendaApp.MVC.Controllers
{
    public class AccountController : Controller
    {
        private string _apiEndpoint = "http://localhost:5032/api/usuarios";

        //ROTA: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AccountLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        //serializar (JSON) os dados do formulário para envia-los para a API.
                        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                        //fazendo a requisição para a API e capturo a resposta
                        var response = httpClient.PostAsync($"{_apiEndpoint}/autenticar", content).Result;

                        //verificar se a resposta é sucesso ou não
                        if (response.IsSuccessStatusCode)
                        {
                            //capturar os dados obtidos da API
                            var result = response.Content.ReadAsStringAsync().Result;
                            //salvar os dados em sessão
                            HttpContext.Session.SetString("USUARIO", result);
                            //redirecionar para a página de consulta de tarefas da agenda
                            return RedirectToAction("Consulta", "Tarefas");
                        }
                        else
                        {
                            //deserializar o retorno de erro da API
                            var result = JsonConvert.DeserializeObject<ErrorResponseViewModel>
                                (response.Content.ReadAsStringAsync().Result);

                            TempData["MensagemErro"] = result.Message;
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

        //ROTA: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    using (var httpClient = new HttpClient())
                    {
                        //serializando os dados da model para o formato JSON (transformando em JSON)
                        var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");

                        //enviando uma requisição para o serviço de cadastro de usuário da API e pegando a resposta
                        var response = httpClient.PostAsync($"{_apiEndpoint}/criar", content).Result;

                        if (response.IsSuccessStatusCode)
                            TempData["MensagemSucesso"] = "Parabéns, sua conta de usuário foi criada com sucesso.";
                        else
                        {
                            //deserializar os dados retornados pela API
                            var result = JsonConvert.DeserializeObject<ErrorResponseViewModel>
                                (response.Content.ReadAsStringAsync().Result);

                            TempData["MensagemErro"] = result.Message;
                        }
                    }
                }
                catch (Exception e)
                {
                    TempData["MensagemErro"] = "Erro: " + e.Message;
                }
            }

            return View();
        }

        public IActionResult Logout()
        {
            //apagar os dados que estavam salvos na sessão
            HttpContext.Session.Remove("USUARIO");
            //redirecionar para a página de login
            return RedirectToAction("Login", "Account");
        }
    }
}



