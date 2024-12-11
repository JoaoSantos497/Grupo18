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
        builder.Services.AddScoped<IUserService, UserService>(); // Inje��o do servi�o IUserService
        builder.Services.AddScoped<IAuthService, AuthService>(); // Inje��o do servi�o IAuthService
        //builder.Services.AddScoped<AuthService, AuthService>(); // Inje��o do servi�o AuthService
        builder.Services.AddEndpointsApiExplorer();

        // Adicione o ApplicationDbContext
        builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        // Authentication
        //builder.Services.AddAuthentication(options =>
        //{
            // Define o esquema padr�o como Bearer
            //options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            //options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        //})

        //.AddJwtBearer(options =>
         //{
             // Configura��es para o JWT Bearer Token
             //options.TokenValidationParameters = new TokenValidationParameters
             //{
                 //ValidateIssuerSigningKey = true,
                 //IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("TI2024/2025")),
                 //ValidateIssuer = false,
                 //ValidateAudience = false
             //};
         //});


        var app = builder.Build();

        // Configura��o do pipeline de middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage(); // P�gina detalhada de erros no modo de desenvolvimento
        }
        else
        {
            app.UseExceptionHandler("/Home/Error"); // P�gina de erro personalizada
            app.UseHsts(); // Habilita HSTS para produ��o
        }

        app.UseHttpsRedirection(); // Redireciona para HTTPS
        app.UseStaticFiles(); // Habilita o uso de arquivos est�ticos (CSS, JS, etc.)
        app.UseRouting(); // Configura o roteamento
        app.UseAuthorization(); // Adiciona middleware de autoriza��o

        // Configurar rotas
        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}"); // Rota padr�o

        // Outra rota adicional, se necess�rio, com nome diferente
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
