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

            builder.Services.AddControllers();

            builder.Services.AddSingleton<IUserServices, UserService>();
            builder.Services.AddSingleton<IUserRepository, UserRepository>();
            

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






