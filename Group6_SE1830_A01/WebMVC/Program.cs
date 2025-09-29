using BLL.IServices;
using BLL.Mappings;
using BLL.Services;
using DAL;
using DAL.IRepository;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using WebMVC.BackgroundWorker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(AutoMappingProfile));

builder.Services.AddScoped<IInventoryRepo, InventoryRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IStaffRepo, StaffRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();
builder.Services.AddScoped<ITestDriveAppointmentRepo, TestDriveAppointmentRepo>();
builder.Services.AddScoped<ICustomerRepo, CustomerRepo>();  

builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ITestDriveAppointmentService, TestDriveAppointmentService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IStaffService, StaffService>();

builder.Services.AddHostedService<BackgroundServiceWorker>();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Staff}/{action=Login}/{id?}")
    .WithStaticAssets();


app.Run();
