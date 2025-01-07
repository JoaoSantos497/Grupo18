using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApp.Controllers;
using Microsoft.Exchange.WebServices.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        
        // Adiciona serviços ao contêiner
        builder.Services.AddControllersWithViews(); // Suporte para controladores e views

        // Injeção de dependências
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IRegistoService, RegistoService>();
        builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        builder.Services.AddScoped<LoginService>();
        builder.Services.AddScoped<ILoginService, LoginService>();

        // Configuração de sessões
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expiração da sessão
            options.Cookie.HttpOnly = true; // Segurança do cookie
            options.Cookie.IsEssential = true; // Necessário para funcionar em todos os ambientes
        });

        // Configuração de autenticação
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Role1Policy", policy => policy.RequireRole("1"));
            options.AddPolicy("Role2Policy", policy => policy.RequireRole("2"));

        });

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       
        .AddCookie("UserCookie", options =>
        {
            options.Cookie.Name = "UserCookie"; // Nome do cookie para utilizador comum
            options.LoginPath = "/Login"; // Caminho da página de login normal
            options.AccessDeniedPath = "/Login"; // Caminho em caso de acesso negado
            options.LogoutPath = "/Login/Logout";
        })
        .AddCookie("AdminCookie", options =>
        {
        options.Cookie.Name = "AdminCookie"; // Nome do cookie para admin
        options.LoginPath = "/Admin"; // Caminho da página de login admin
        options.AccessDeniedPath = "/Admin"; // Caminho em caso de acesso negado
        options.LogoutPath = "/Admin/Logout";
        });

        // Configuração do banco de dados
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        app.UseMiddleware<UnauthorizedRedirectMiddleware>();

        // Configuração do pipeline de middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        // Middleware de sessões
        app.UseSession();
        
        // Middleware de autenticação e autorização
        app.UseAuthentication();
        app.UseAuthorization();
        

        // Configuração de rotas
        app.MapControllerRoute(
            name: "admin",
            pattern: "Admin/{action=Index}/{id?}",
            defaults: new { controller = "Admin" });

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }
}
