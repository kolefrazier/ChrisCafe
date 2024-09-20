// NOTE: Order is important! Mind the middleware order!
// https://docs.microsoft.com/en-us/aspnet/core/fundamentals/middleware/?view=aspnetcore-6.0#middleware-order

using ChrisCafe.Providers;
using ChrisCafe.Data;
using ChrisCafe.Models.HealthChecks;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// CORS Setup
// With or without CORS, the map loads and the console still cries about CORS requests not working.
// CORS setup ref: https://docs.microsoft.com/en-us/aspnet/core/security/cors
//var GoogleOrigins = "GoogleOrigins";
//builder.Services.AddCors(options =>
//{
//    options.AddPolicy(name: GoogleOrigins, builder =>
//    {
//        builder.WithOrigins("https://www.googletagmanager.com", "https://www.google.com");
//    });
//});

// Configure forwarded headers
// Mind the forwarded headers middleware order!
// https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/proxy-load-balancer?view=aspnetcore-6.0#fhmo
builder.Services.Configure<ForwardedHeadersOptions>(options => 
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
});

builder.Services.AddScoped<IDateTimeProvider, DateTimeProvider>();
builder.Services
    .AddHealthChecks()
    .AddCheck<LiveCheck>("live")
    .AddCheck<IntegrityCheck>("integrity");

// Configure other host pieces.
//builder.WebHost.UseUrls("http://localhost:5001");

var app = builder.Build();

//app.UsePathBase(Directory.GetCurrentDirectory());

app.UseForwardedHeaders();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/home/error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// TODO: Is HTTPS and HSTS needed when behind Nginx (and/or cloudflare)?
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

// TODO: Enable a cookie policy (even a minimum one w/ GDPR check). Per these links:
// * MS Docs: https://docs.microsoft.com/en-us/aspnet/core/security/gdpr?view=aspnetcore-6.0
// * OWASP: https://cheatsheetseries.owasp.org/cheatsheets/DotNet_Security_Cheat_Sheet.html#a2-broken-authentication

app.UseRouting();
//app.UseCors(GoogleOrigins);

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.MapHealthChecks("/checkup", new HealthCheckOptions
{
    AllowCachingResponses = false
});

// Misc and Custom Setup Tasks
DataInitializer.InitializeAll();

// Start the server
app.Run();
