using ZealandZoo.Repositories;
using ZealandZoo.Services;
using ZooApp.Data.Db;
using ZooApp.Data.interfaces;
using ZooApp.Data.Repositories;
using ZooApp.Services;
using ZooApp.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSingleton<GuestService>();
//builder.Services.AddSingleton<UserService>();

// Database connection helper
builder.Services.AddScoped<DbConnectionHelper>();

// Repositories
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IAdminRepository, AdminRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();


// Service
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

var app = builder.Build();
app.UseSession();


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
