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
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

builder.Services.AddScoped<IMuralVendasRepositorio, MuralVendasRepositorio>();






builder.Services.AddAuthentication("CookieAuth") .AddCookie("CookieAuth", config => { config.Cookie.Name = "UserLoginCookie"; config.LoginPath = "/Login"; });

builder.Services.AddAuthorization(options => { 
options.AddPolicy("Cliente", policy => policy.RequireRole("Cliente")); 
options.AddPolicy("Produtor", policy => policy.RequireRole("Produtor")); }); 

builder.Services.AddSession(options => { 
    options.IdleTimeout = TimeSpan.FromHours(1); 
    options.Cookie.HttpOnly = true; 
    options.Cookie.IsEssential = true; });



builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Cliente", policy => //cria uma politica de autorização para string Cliente
        policy.RequireRole("Cliente")); // o usuario que conter a Role Cliente terá acesso a pagina que contem a autorização

    options.AddPolicy("Produtor", policy =>
        policy.RequireRole("Produtor"));
});






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

app.UseAuthentication(); 
app.UseAuthorization(); 
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Index}/{id?}");

app.Run();
