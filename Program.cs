using CrudMySQL.Classic.Data;
using Microsoft.EntityFrameworkCore;
using CrudMySQL.Classic.Services;

var builder = WebApplication.CreateBuilder(args);

// =====================
// Connexion MySQL
// =====================
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    )
);

// =====================
// Services personnalisés
// =====================
builder.Services.AddScoped<IExportService, ExportService>();
builder.Services.AddScoped<ILanguageService, LanguageService>();
builder.Services.AddHttpContextAccessor();

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// =====================
// Création DB au démarrage
// =====================
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
    Console.WriteLine(" Base de données MySQL prête");
}

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

// =====================
// Routes d'export
// =====================
app.MapControllerRoute(
    name: "export",
    pattern: "{controller=Export}/{action=Index}");

app.Run();
