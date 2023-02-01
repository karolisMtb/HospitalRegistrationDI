using HospitalRegistration.BusinessLogic;
using HospitalRegistration.BusinessLogic.Extensions;
using HospitalRegistration.BusinessLogic.Services;
using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using HospitalRegistration.Pages;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container. Dependency injections
builder.Services.AddRazorPages();
builder.Services.AddDbContext<DatabaseContext>();
builder.Services.AddScoped<IGeneratorService, DbMockDataGeneratorService>();
builder.Services.AddScoped<IndexModel>();
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
builder.Services.AddScoped<IIlnessRepository, IllnessRepository>();
builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
builder.Services.AddScoped<IDbService, DbService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<DbInitializerService>();

//Prideti Onconfiguration
//json file seedInitialData: false. kai bus seedinta, tai reikia nustatyti, kad butu true
//{ "SeedInitialData": false, }


var app = builder.Build();

app.UseItToSeedSqlServer();

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
