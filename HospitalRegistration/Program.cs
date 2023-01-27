using HospitalRegistration.BusinessLogic.Services;
using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Dependency injections
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DatabaseContext>(
    options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
    );
builder.Services.AddScoped<IAppConfiguration, AppConfiguration>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
