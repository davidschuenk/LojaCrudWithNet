using LojaWebApp.Data;
using LojaWebApp.Services;
using LojaWebApp.Services.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IProdutoService, ProdutoService>();

builder.Services.AddDbContext<LojaDbContext>();

var app = builder.Build();

//Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
app.UseHsts();
}

var context = new LojaDbContext();
context.Database.Migrate();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
