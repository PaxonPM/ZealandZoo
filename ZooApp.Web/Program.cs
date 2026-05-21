using ZealandZoo.Repositories;
using ZealandZoo.Services;
using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Data.Repositories;
using ZooApp.Services;
using ZooApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using ZooApp.Data.Db;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Database connection helper
builder.Services.AddScoped<DbConnectionHelper>();

// Repositories
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();

// Services
builder.Services.AddScoped<GuestService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<InventoryService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IAdminService, AdminService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    //options.IdleTimeout = TimeSpan.FromMinutes(30);
});
// INSERTED: Entity Framework DbContext til Event update
builder.Services.AddDbContext<DbContextUpdateEvent>(options =>
    options.UseSqlServer(
        @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=dev_ZealandZoo_0_8;Integrated Security=True;Trust Server Certificate=True"
    ));

var app = builder.Build();
app.UseSession();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
