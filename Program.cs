using CRM_Koltes.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Ajouter le DbContext au conteneur
//Dans ASP.NET Core, les services tels que le contexte de base de donn�es doivent �tre inscrits
//aupr�s du conteneur d�injection de d�pendances. Le conteneur fournit le service aux contr�leurs.
builder.Services.AddDbContext<CrmKoltesDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

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
    pattern: "{controller=Structures}/{action=Index}/{id?}");

app.Run();
