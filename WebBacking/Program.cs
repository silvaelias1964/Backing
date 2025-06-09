using Microsoft.AspNetCore.Authentication.Cookies;
using WebBacking.Service;
using WebBacking.Service.IService;

var builder = WebApplication.CreateBuilder(args);

// Habilita CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermiteTodo",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});


// Agregar servicios en el contenedor.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAutenticarApiService, AutenticarApiService>();
builder.Services.AddScoped<ICriptosService, CriptosService>();

// Seguridad
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.LoginPath = "/Login/Login";
                   options.ExpireTimeSpan = TimeSpan.FromMinutes(20);
               });



// Sesiones
builder.Services.AddResponseCaching();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

app.UseCors("PermiteTodo"); // Aplica política de CORS


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
