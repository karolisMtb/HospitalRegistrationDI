using HospitalRegistration.BusinessLogic.Services;
using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using HospitalRegistration.Pages;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Dependency injections
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<IndexModel>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IGeneratorService<Department>, DepartmentGeneratorService>();
builder.Services.AddScoped<IGeneratorService<Patient>, PatientGeneratorService>();
builder.Services.AddScoped<IGeneratorService<Department>, DepartmentGeneratorService>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddSingleton<JsonTempObject<Patient>>();

//Prideti Onconfiguration
//json file seed initial data false
//{ "SeedInitialData": false, }





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
