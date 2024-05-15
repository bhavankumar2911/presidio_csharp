using Microsoft.EntityFrameworkCore;
using PizzaAPI.Context;
using PizzaAPI.Models;
using PizzaAPI.Repositories;
using PizzaAPI.Repositories.Interfaces;
using PizzaAPI.Services;
using PizzaAPI.Services.Interfaces;

namespace PizzaAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            #region context
            builder.Services.AddDbContext<PizzaShopContext>(
           options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
           );
            #endregion

            #region repositories
            builder.Services.AddScoped<IRepository<int, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, Pizza>, PizzaRepository>();
            #endregion

            #region services
            builder.Services.AddScoped<IPizzaService, PizzaService>();
            #endregion

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
        }
    }
}
