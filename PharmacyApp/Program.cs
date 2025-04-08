using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using PharmacyApp.Constants;
using PharmacyApp.Data;
using PharmacyApp.Models;
using PharmacyApp.Repositories;
using PharmacyApp.Services;
using PharmacyApp.ViewModels;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<ApplicationdbContext>(); 



// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationdbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.")));

builder.Services.AddScoped<IRepository<Customers>, CustomerRepository>();
builder.Services.AddScoped<IRepository<Products>, ProductRepository>();
builder.Services.AddScoped<IRepository<PrescriptionOrders>, PrescriptionOrderRepository>();
builder.Services.AddScoped<IRepository<Payments>, PaymentRepository>();  
builder.Services.AddScoped<IRepository<OrderDetails>, OrderDetailsRepository>();
builder.Services.AddScoped<IRepository<FeedbackForm>, FeedbackFormRepository>();
builder.Services.AddScoped<IRepository<Form2>, Form2Repository>();

builder.Services.AddScoped<IAuthService<CustomerViewModel>, AuthService>();
builder.Services.AddScoped<IProductService<ProductViewModel>, ProductService>();
builder.Services.AddScoped<IPaymentService<PaymentViewModel>, PaymentService>();
builder.Services.AddScoped<IFeedbackFormService<FeedBackFormViewModel>, FeedbackFormService>();
builder.Services.AddScoped<IForm2Service<Form2ViewModel>, Form2Service>();

builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<ICartService<CartViewModel>, CartService>();
builder.Services.AddScoped<IFeedbackFormService<FeedBackFormViewModel>, FeedbackFormService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


builder.Services.AddDistributedMemoryCache(); 
builder.Services.AddSession(options =>
{
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
    options.IdleTimeout = TimeSpan.FromMinutes(30); 
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    RoleSeeder.SeedRolesAsync(services).Wait();
    UserSeeder.SeedUsersAsync(services).Wait();


}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession(); 


app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
