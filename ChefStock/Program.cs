using Microsoft.EntityFrameworkCore;
using ChefStock.Models; // Seu contexto de dados
using ChefStock.Services; // Referência do serviço de GrupoProduto
using Microsoft.AspNetCore.Identity; // Usar Identity para autenticação

var builder = WebApplication.CreateBuilder(args);

// Configuração do Entity Framework Core com a Connection String
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registrar o serviço IGrupoProdutoService para injeção de dependência
builder.Services.AddScoped<IGrupoProdutoService, GrupoProdutoService>();

// Adiciona os serviços do Identity com configurações personalizadas
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Configurações de senha para fortalecer a segurança
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 8;  // Senha mínima de 8 caracteres
    options.Password.RequireNonAlphanumeric = false; // Pode ser alterado para true conforme necessário

    // Configurações de bloqueio e tentativas de login
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15); // Tempo de bloqueio após falhas
    options.Lockout.AllowedForNewUsers = true;

    // Configurações de confirmação de e-mail
    options.SignIn.RequireConfirmedEmail = true;

    // Configurações de usuário
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<AppDbContext>()
.AddDefaultTokenProviders(); // Adiciona os provedores de token padrão para recuperação de senha, etc.

// Adicionar o serviço de autenticação e autorizações
builder.Services.AddControllersWithViews(); // Adiciona o suporte a controllers e views MVC

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error"); // Tratamento de exceções para produção
    app.UseHsts(); // HSTS para segurança em conexões HTTPS
}

app.UseHttpsRedirection();
app.UseStaticFiles(); // Permite arquivos estáticos como CSS e JS

app.UseRouting();

// Adiciona autenticação e autorização ao pipeline de requisições
app.UseAuthentication();  // Necessário para autenticação de usuários
app.UseAuthorization();   // Necessário para autorização com base em roles e policies

// Configuração das rotas padrão para o MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
