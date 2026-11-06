using Microsoft.EntityFrameworkCore;
using FotaStock.Web.Context;
using FotaStock.Web.Repositories;
using FotaStock.Web.Services;
using System.Text;
using FotaStock.Web;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlString"));

});

var jwtConfig = builder.Configuration.GetSection("Jwt");
var key = Encoding.UTF8.GetBytes(jwtConfig["Key"]);

builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true, 
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidAudience = jwtConfig["Audience"],
        ValidIssuer = jwtConfig["Issuer"],
        IssuerSigningKey = new SymmetricSecurityKey(key)
    };   

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            context.Token = context.HttpContext.Request.Cookies["AuthToken"];
            return Task.CompletedTask;
        }
    };
});

builder.Services.AddScoped(typeof(GenericRepository<>));
builder.Services.AddScoped<CategoriaService>();
builder.Services.AddScoped<ArchivoImagenService>();

var app = builder.Build();

app.UseStatusCodePages(async context =>
{
    if(context.HttpContext.Response.StatusCode == 401)
    {
        context.HttpContext.Response.Redirect("/Auth/Login");
    }
});

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
