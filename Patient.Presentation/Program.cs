using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Patient.Application;
using Patient.Application.Services;
using Patient.Infrastructure;
using Patient.Infrastructure.Providers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
.AddNewtonsoftJson(options =>
{
    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
});


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IDbConnectionProvider, DbConnectionProvider>();

builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//app.UseAuthorization();
app.UseRouting();
app.MapControllers();

app.Run();
