using LojaWebApp.Data;
using LojaWebApp.Services;
using LojaWebApp.Services.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Marcas");
    options.Conventions.AuthorizeFolder("/Categorias");
});

builder.Services.AddTransient<IProdutoService, ProdutoService>();

builder.Services.AddDbContext<LojaDbContext>();

builder.Services.
    AddDefaultIdentity<IdentityUser>(options => 
    options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<LojaDbContext>();

builder.Services.Configure<IdentityOptions>(options => {
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;
    
    options.Lockout.MaxFailedAccessAttempts = 30;
    options.Lockout.AllowedForNewUsers = true;
    
    options.User.RequireUniqueEmail = true;
});

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");

app.UseHsts();
}

var context = new LojaDbContext();
context.Database.Migrate();



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
