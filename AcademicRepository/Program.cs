using _2022_09_23.Entities.DbContextNamespace;
using _2022_09_23.Middleware;
using _2022_09_23.Services;
using _2022_09_23.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<ITrainCarService, TrainCarService>();
builder.Services.AddScoped<IAcademicService, AcademicService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISubjectUnitOfWork, SubjectUnitOfWork>();

builder.Services.AddDbContext<TrainCar2DbContext>(options =>
{
    options.UseSqlServer("Server=(local);Database=Traincar2;Trusted_Connection=True;MultipleActiveResultSets=true");
});

builder.Services.AddDbContext<Academic3DbContext>(options =>
{
    options.UseSqlServer("Server=(local);Database=Academic3;Trusted_Connection=True;MultipleActiveResultSets=true");
});

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<RequestResponseLoggingMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
