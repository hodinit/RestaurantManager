using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManager.Data;
using RestaurantManager.Services;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<RestaurantManagerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RestaurantManagerContext") ?? throw new InvalidOperationException("Connection string 'RestaurantManagerContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<IPriceRecommenderService, PriceRecommenderService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:57858/");
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
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
