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
        
        // Adiciona servi�os ao cont�iner
        builder.Services.AddControllersWithViews(); // Suporte para controladores e views

        // Inje��o de depend�ncias
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IRegistoService, RegistoService>();
        builder.Services.AddScoped<IPasswordHasherService, PasswordHasherService>();
        builder.Services.AddScoped<LoginService>();
        builder.Services.AddScoped<ILoginService, LoginService>();

        // Configura��o de sess�es
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expira��o da sess�o
            options.Cookie.HttpOnly = true; // Seguran�a do cookie
            options.Cookie.IsEssential = true; // Necess�rio para funcionar em todos os ambientes
        });

        // Configura��o de autentica��o
        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("Role1Policy", policy => policy.RequireRole("1"));
            options.AddPolicy("Role2Policy", policy => policy.RequireRole("2"));

        });

        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       
        .AddCookie("UserCookie", options =>
        {
            options.Cookie.Name = "UserCookie"; // Nome do cookie para utilizador comum
            options.LoginPath = "/Login"; // Caminho da p�gina de login normal
            options.AccessDeniedPath = "/Login"; // Caminho em caso de acesso negado
            options.LogoutPath = "/Login/Logout";
        })
        .AddCookie("AdminCookie", options =>
        {
        options.Cookie.Name = "AdminCookie"; // Nome do cookie para admin
        options.LoginPath = "/Admin"; // Caminho da p�gina de login admin
        options.AccessDeniedPath = "/Admin"; // Caminho em caso de acesso negado
        options.LogoutPath = "/Admin/Logout";
        });

        // Configura��o do banco de dados
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

        app.UseMiddleware<UnauthorizedRedirectMiddleware>();

        // Configura��o do pipeline de middleware
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

        // Middleware de sess�es
        app.UseSession();
        
        // Middleware de autentica��o e autoriza��o
        app.UseAuthentication();
        app.UseAuthorization();
        

        // Configura��o de rotas
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
