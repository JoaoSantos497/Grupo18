using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;


internal class Program
{

    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddControllersWithViews(); // Adiciona suporte para controladores e views
        builder.Services.AddScoped<IUserService, UserService>(); // Injeção do serviço IUserService
        builder.Services.AddScoped<IAuthService, AuthService>(); // Injeção do serviço IAuthService
        //builder.Services.AddScoped<AuthService, AuthService>(); // Injeção do serviço AuthService
        builder.Services.AddEndpointsApiExplorer();

        // Adicione o ApplicationDbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Authentication
        //builder.Services.AddAuthentication(options =>
        //{
            // Define o esquema padrão como Bearer
            //options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //})

        //.AddJwtBearer(options =>
         //{
             // Configurações para o JWT Bearer Token
             //options.TokenValidationParameters = new TokenValidationParameters
             //{
                 //ValidateIssuerSigningKey = true,
                 //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TI2024/2025")),
                 //ValidateIssuer = false,
                 //ValidateAudience = false
             //};
         //});


        var app = builder.Build();

        // Configuração do pipeline de middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); // Página detalhada de erros no modo de desenvolvimento
        }
        else
        {
            app.UseExceptionHandler("/Home/Error"); // Página de erro personalizada
            app.UseHsts(); // Habilita HSTS para produção
        }

        app.UseHttpsRedirection(); // Redireciona para HTTPS
        app.UseStaticFiles(); // Habilita o uso de arquivos estáticos (CSS, JS, etc.)
        app.UseRouting(); // Configura o roteamento
        app.UseAuthorization(); // Adiciona middleware de autorização

        // Configurar rotas
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"); // Rota padrão

        // Outra rota adicional, se necessário, com nome diferente
        app.MapControllerRoute(
            name: "Wishlist",
            pattern: "{controller=Wishlist}/{action=Index}/{id?}");

        app.Run(); // Executa o aplicativo
    }

        // Configure the HTTP request pipeline.
        //if (app.Environment.IsDevelopment())
        //{
           // app.UseDeveloperExceptionPage();
       // }
        //else
        //{
            //app.UseExceptionHandler("/Home/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            //app.UseHsts();
        //}

        
        //app.UseStaticFiles();

        //app.UseRouting();

        //app.UseAuthorization();

        //app.MapControllerRoute(
            //name: "default",
            //pattern: "{controller=Home}/{action=Index}/{id?}");
        
        //app.MapControllerRoute(
            //name: "default",
            //pattern: "{controller=Wishlist}/{action=Index}/{id?}");
}   
