using HospitalRegistration.BusinessLogic;
using HospitalRegistration.BusinessLogic.Extensions;
using HospitalRegistration.BusinessLogic.Services;
using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using HospitalRegistration.Pages;
using HospitalRegistration.Tests.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Dependency injections
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DatabaseContext>(options => { options.UseSqlServer($@"Data Source = LAZYBASTARD\; MultipleActiveResultSets=true; Initial Catalog = HospitalDB; Integrated Security = True"); }, ServiceLifetime.Transient);
builder.Services.AddScoped<IGeneratorService, DbMockDataGeneratorService>();
builder.Services.AddScoped<IndexModel>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IIlnessRepository, IllnessRepository>();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<IHospitalService, HospitalService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<UnitOfWork>();
builder.Services.AddScoped<DbInitializerService>();
builder.Services.AddScoped<IDoctorPatientRepository, DoctorPatientRepository>();

var app = builder.Build();

app.UseItToSeedSqlServer();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
