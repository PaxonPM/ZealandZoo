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
builder.Services.AddScoped<IDbConnectionHelper, DbConnectionHelper>();

// Repositories
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IStaffRepository, StaffRepository>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();

// Services
builder.Services.AddScoped<InventoryService>();
builder.Services.AddSingleton<IUserAuthenticator, UserAuthenticator>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IGuestService, GuestService>();
builder.Services.AddScoped<IStaffService, StaffService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});


// INSERTED: Entity Framework DbContext til Event update
builder.Services.AddDbContext<DbContextUpdateEvent>(options =>
    options.UseSqlServer(
        @"Data Source=SHARK1-PC\SQLEXPRESS;Initial Catalog=dev_ZealandZoo_0_8;Integrated Security=True;Trust Server Certificate=True"
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
