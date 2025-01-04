using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adiciona servi�os ao cont�iner
        builder.Services.AddControllersWithViews(); // Suporte para controladores e views
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IRegistoService, RegistoService>();
        builder.Services.AddScoped<RegistoService>();
        builder.Services.AddScoped<LoginService>();
        builder.Services.AddScoped<IPasswordHashingService, PasswordHashingService>();


        // Configura��o de sess�es
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expira��o da sess�o
            options.Cookie.HttpOnly = true; // Seguran�a do cookie
            options.Cookie.IsEssential = true; // Necess�rio para funcionar em todos os ambientes
        });

        // Configura��o de autentica��o
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "localhost",
                ValidAudience = "localhost",
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("gettech"))
            };
        })
        .AddCookie("CookieAuth", options =>
        {
            options.Cookie.Name = "UserAuthCookie";
            options.LoginPath = "/Auth/Login"; // Caminho da p�gina de login
        });

        // Configura��o do banco de dados
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

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

        // Middleware de autentica��o e autoriza��o
        app.UseAuthentication();
        app.UseAuthorization();

        // Middleware de sess�es
        app.UseSession();

        // Top-Level Route Registrations
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
