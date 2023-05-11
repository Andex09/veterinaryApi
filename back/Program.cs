using back.Models;
using back.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Cors
builder.Services.AddCors(options => options.AddPolicy("AllowWebapp",
                                    builder => builder.AllowAnyOrigin()
                                                    .AllowAnyHeader()
                                                    .AllowAnyMethod()));

//AppContext
builder.Services.AddDbContext<VeterinaryDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("cnVeterinary"));
});

//AutoMapper
builder.Services.AddAutoMapper(typeof(Program));

//Services
builder.Services.AddScoped<IPetRepository, PetRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowWebapp");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
