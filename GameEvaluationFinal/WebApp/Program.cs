using AdministrationLibrary;
using Logic;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using DatabaseLibrary;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddRazorPages();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = new PathString("/Login");
        options.AccessDeniedPath = new PathString("/Login");
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy =>
        policy.RequireClaim("UserType", "Admin"));
});




builder.Services.AddScoped<IReviewDBHelper, ReviewDBHelper>();
builder.Services.AddScoped<IGameDBHelper, GameDBHelper>();
builder.Services.AddScoped<IUserDBHelper, UserDBHelper>();

builder.Services.AddScoped<IGameAdministration, GameAdministration>();
builder.Services.AddScoped<IReviewAdministration, ReviewAdministration>();
builder.Services.AddScoped<IUserAdministration, UserAdministration>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();