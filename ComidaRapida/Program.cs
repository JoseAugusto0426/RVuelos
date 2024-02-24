using ComidaRapida.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using ComidaRapida.Services;
using ComidaRapida.Pages;
using ComidaRapida.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
Memoria.Facturas = new();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDbContext<IRVDbContext, RVDbContext>();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<IComidaService, ComidaService>();

var app = builder.Build();
using var context = app.Services.CreateScope()
                     .ServiceProvider.GetRequiredService<RVDbContext>();
context.Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
