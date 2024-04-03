using BusinessLogic;
using BusinessLogic.Extensions;
using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataAccess;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Pizzeria;

var builder = WebApplication.CreateBuilder(args);

var connStr = builder.Configuration.GetConnectionString("LocalDb")!;

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddCors();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddJWT(builder.Configuration);

builder.Services.AddDbContext(connStr);
builder.Services.AddIdentity();
builder.Services.AddRepositories();

builder.Services.AddAuthentication();

builder.Services.AddAutoMapper();
builder.Services.AddFluentValidators();

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

app.UseMiddleware<GlobalErrorHandler>();

app.UseCors(options =>
{
    options.WithOrigins("http://localhost:4200", "http://localhost:55756")
        .AllowAnyMethod()
        .AllowAnyHeader();
});


app.UseAuthorization();

app.MapControllers();

app.Run();



/*
//Піци
    ід
    назва
    ціна
    час приготування
    опис
    +категорія

//Замовлення ---
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
    ід
    назва
    грамовка (може)

//Розміри
    ід
    велика, середня, мала або в см


//Напої (додатково)
    ід
    назва
    ціна

//Клієнти (пізніше)----
    ід
    ім'я
    логін   
    пошта
    +замовлення

//Робітники (додатково)----
*/
