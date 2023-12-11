using Igreja.Dominio.Interfaces;
using Igreja.Dominio.Servicos;
using Igreja.Dados;
using Igreja.Dados.Repository;
using Igreja.Servico.Servicos;
using Igreja.Dados.EntityFramework;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Igreja.WebApp.Helper.Sessão;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Contexto>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ISessao, Sessao>();
builder.Services.AddScoped<IMembroCadastroRepository, MembroCadastroRepository>();
builder.Services.AddScoped<IMembroCadastroService, MembroCadastroService>();
//builder.Services.AddScoped<ILoginRepository, LoginService>();

builder.Services.AddSession(o =>
{
    o.Cookie.HttpOnly = true;
    o.Cookie.IsEssential = true;
});



builder.Services.AddControllers();

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
    pattern: "{controller=Login}/{action=Index}/{id?}");
app.Run();
