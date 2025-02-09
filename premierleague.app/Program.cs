using Microsoft.EntityFrameworkCore;
using premierleague.efcore;
using premierleague.efcore.IRepository;
using premierleague.service.IService;
using premierleague.service.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IDataService, DataService>();
builder.Services.AddScoped<IDataRepository, premierleague.efcore.Repository.DataRepository>();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql("Server=127.0.0.1;Port=5432;Userid=postgres;Password=root;Database=premier-league-matches"));

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
