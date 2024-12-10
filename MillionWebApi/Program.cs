using MillionWebApi.Data;
using MillionWebApi.Services;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddCorsServices();
builder.Services.AddManagementDbContext(builder.Configuration);
builder.Services.AddMediatRServices();

builder.Services.AddOutputCache();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
    //app.UseSwaggerUI(c => c.SwaggerEndpoint("/openapi/v1.json", "MillionApi v1"));
}

using (var scope = app.Services.CreateScope())
{
    var seeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
    seeder.InitialiseDataContext();
    seeder.Seed();
}

app.UseOutputCache();

app.UseCors("ApiCorsPolicy");
app.UseHttpsRedirection();

app.MapRoutes();

app.Run();

