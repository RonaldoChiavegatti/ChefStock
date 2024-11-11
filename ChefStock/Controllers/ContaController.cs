using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ChefStock.Models;  // Supondo que você tenha uma classe ApplicationUser
using System.Threading.Tasks;

namespace ChefStock.Controllers
{
    public class ContaController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public ContaController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // Exibir a página de login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Processar o login do usuário
        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Buscar o usuário pelo nome de usuário
            var user = await _userManager.FindByNameAsync(username);
            
            if (user != null)
            {
                // Tentar autenticar o usuário
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home"); // Redireciona para a home após o login bem-sucedido
                }
                else
                {
                    // Se a senha estiver incorreta
                    ViewData["ErrorMessage"] = "Senha incorreta.";
                    return View();
                }
            }
            else
            {
                // Se o usuário não for encontrado
                ViewData["ErrorMessage"] = "Nome de usuário não encontrado.";
                return View();
            }
        }

        // Exibir a página de registro
        [HttpGet]
        public IActionResult Registrar()
        {
            return View();
        }

        // Processar o registro do usuário
        [HttpPost]
        public async Task<IActionResult> Registrar(string username, string email, string password, string confirmPassword)
        {
            // Verificar se as senhas correspondem
            if (password != confirmPassword)
            {
                ViewData["ErrorMessage"] = "As senhas não correspondem.";
                return View();
            }

            // Criar o novo usuário
            var user = new ApplicationUser
            {
                UserName = username,
                Email = email,
                FullName = username // Definir o FullName aqui (se necessário, pode ser alterado para obter de algum outro campo)
            };

            // Criar o usuário no banco de dados
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Caso o usuário seja criado com sucesso, redireciona para a página de login
                ViewData["SuccessMessage"] = "Conta criada com sucesso! Agora você pode fazer login.";
                return RedirectToAction("Login", "Conta");
            }
            else
            {
                // Se ocorrer algum erro na criação do usuário, exibe as mensagens de erro
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View();
            }
        }

        // Método para logout
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync(); // Deslogar o usuário
            return RedirectToAction("Index", "Home"); // Redirecionar para a página inicial
        }
    }
}
