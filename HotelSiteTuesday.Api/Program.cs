using HotelSiteTuesday.Infraestructure.Context;
using HotelSiteTuesday.Infraestructure.Interfaces;
using HotelSiteTuesday.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        //Connection String
        builder.Services.AddDbContext<HotelContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("HotelContext")));

        //Repositories

        builder.Services.AddScoped<IRecepcionRepository, RecepcionRepository>();

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
 