using BusinessLogic;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("LocalDb")!;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext(connStr);

builder.Services.AddAutoMapper();
//builder.Services.AddFluentValidators();

builder.Services.AddCustomServices();
builder.Services.AddScoped<IPizzaService, PizzasService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();



/*
//Піци
    ід
    назва
    ціна
    опис
    +категорія

//Замовлення
    ід
    клієнт
    повна вартість
    +піци
        сирний бортик +-
    +напої

//Категорія піци   
    ід
    веганська або ні

//Інградієнти

//Розміри


//Напої


//Клієнти

//Робітники
*/
