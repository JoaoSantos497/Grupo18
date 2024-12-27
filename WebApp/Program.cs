using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;

class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Adiciona serviços ao contêiner
        builder.Services.AddControllersWithViews(); // Suporte para controladores e views
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<RegistoService>();
        builder.Services.AddScoped<LoginService>();
        builder.Services.AddScoped<IRegistoService, RegistoService>();


        // Configuração de sessões
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddSession(options =>
        {
            options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expiração da sessão
            options.Cookie.HttpOnly = true; // Segurança do cookie
            options.Cookie.IsEssential = true; // Necessário para funcionar em todos os ambientes
        });

        // Configuração de Autenticação
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
            options.LoginPath = "/Login";
        });

        // Adiciona o ApplicationDbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        var app = builder.Build();

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

        app.UseAuthorization();

        app.UseRouting();

        // Middleware de sessões
        app.UseSession();

        // Configuração de rotas
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run(); 
    }
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllersWithViews();
        services.AddSession(); // Ativa sessões
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseSession(); // Middleware de sessão
        app.UseRouting();
        app.UseEndpoints(endpoints => { endpoints.MapDefaultControllerRoute(); });
    }
}
