using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Data.Repositories;
using ZooApp.Services.Interfaces;
using ZooApp.Services.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<GuestService>();

// Database connection helper
builder.Services.AddScoped<DbConnectionHelper>();
// Repository
builder.Services.AddScoped<IEventRepository, EventRepository>();
// Service
builder.Services.AddScoped<IEventService, EventService>();


var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
