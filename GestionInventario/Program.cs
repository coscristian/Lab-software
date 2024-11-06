using AutoMapper;
using GestionInventario.Models;
using GestionInventario.Repositories;
using GestionInventario.Repositories.Interfaces;
using GestionInventario.Services;
using GestionInventario.Services.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace GestionInventario
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            
            var config = new MapperConfiguration(config =>
                {
                    config.AllowNullCollections = true;
                    config.AllowNullDestinationValues = true;
                    config.AddProfile(new AutoMapperProfile.AutoMapperProfile());
                }    
            );

            var mapper = config.CreateMapper();
            

            builder.Services.AddControllers();

            builder.Services.AddSingleton(mapper);
            builder.Services.AddScoped<IUserServices, UserService>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IProductService, ProductService>();
            builder.Services.AddScoped<IProductRepository, ProductRepository>();
            builder.Services.AddScoped<IMovementService, MovementService>();
            builder.Services.AddScoped<IMovementRepository, MovementRepository>();

            builder.Services.AddDbContext<MyDbContext>(options =>
            {
                options.UseMySQL(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();

        }
    }

}






