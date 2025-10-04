using DotNetEnv;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// ✅ Load .env variables FIRST, before anything else
Env.Load();

// ✅ Add environment variables to configuration immediately
var connectionString = Environment.GetEnvironmentVariable("SUPABASE_CONNECTION");
var jwtKey = Environment.GetEnvironmentVariable("JWT_KEY");
var jwtIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
var jwtAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");

builder.Configuration["ConnectionStrings:Supabase"] = connectionString;
builder.Configuration["Jwt:Key"] = jwtKey;
builder.Configuration["Jwt:Issuer"] = jwtIssuer;
builder.Configuration["Jwt:Audience"] = jwtAudience;

// Add services to the container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// Register your SupabaseService for dependency injection (if needed)
// builder.Services.AddSingleton<SupabaseService>();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Digital Logbook API",
        Version = "v1",
        Description = "API for managing digital logbook data with Supabase backend."
    });
});

// ✅ Build the app AFTER all configuration is done
var app = builder.Build();

// ✅ Test Supabase connection (if you need this)
// var service = new SupabaseService();
// await service.TestConnectionAsync();

// Configure the HTTP request pipeline
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Digital Logbook API v1");
    c.RoutePrefix = string.Empty; // Makes Swagger UI appear at the root URL
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// ✅ Open browser after starting the app
var lifetime = app.Services.GetRequiredService<IHostApplicationLifetime>();
lifetime.ApplicationStarted.Register(() =>
{
    var url = app.Urls.FirstOrDefault() ?? "https://localhost:5001";
    Console.WriteLine($"🚀 Application started at: {url}");

    try
    {
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
        {
            FileName = url,
            UseShellExecute = true
        });
    }
    catch
    {
        Console.WriteLine($"⚠️ Please open {url} manually.");
    }
});

app.Run();