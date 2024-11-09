using Microsoft.EntityFrameworkCore;
using MercadoRaiz.Configuration;
using MercadoRaiz.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var Configuration = builder.Configuration;

//Conexao Banco de Dados
builder.Services.AddDbContext<BancoContext>(options =>
options.UseNpgsql(Configuration.GetConnectionString("DataBase")));

//Injeção Dependencia 
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();//Toda vez que minha IUsuarioRepositorio for chamada quero que ele use todos atributos e metodos da Usuario










var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
