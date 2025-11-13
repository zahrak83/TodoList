using ToDoList.Domain.Core.Contract.Repo;
using ToDoList.Domain.Core.Contract.Service;
using ToDoList.Domain.Service;
using ToDoList.Infra.Database;
using ToDoList.Infra.Repo;

var builder = WebApplication.CreateBuilder(args);

// -------------------------------
// Add services to the container.
// -------------------------------
builder.Services.AddControllersWithViews();

// Database
builder.Services.AddDbContext<AppDbContext>();

// Repositories
builder.Services.AddScoped<IToDoItemRepository, ToDoItemRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Services
builder.Services.AddScoped<IToDoItemService, ToDoItemService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IUserService, UserService>();

// ✅ اضافه کردن Session
builder.Services.AddDistributedMemoryCache(); // حافظه‌ی موقت برای نگهداری sessionها
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // زمان انقضای سشن
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// -------------------------------
// Configure the HTTP request pipeline.
// -------------------------------
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// ✅ فعال کردن Session
app.UseSession();

app.UseAuthorization();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

