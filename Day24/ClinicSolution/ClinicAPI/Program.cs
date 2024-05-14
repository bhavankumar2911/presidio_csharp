using ClinicAPI.Context;
using ClinicAPI.Models;
using ClinicAPI.Repository;
using ClinicAPI.Repository.Interfaces;
using ClinicAPI.Services;
using ClinicAPI.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ClinicAPI
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

            builder.Services.AddDbContext<ClinicContext>(
           options => options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"))
           );

            builder.Services.AddScoped<IRepository<int, Doctor>, DoctorRepository>();

            builder.Services.AddScoped<IDoctorService, DoctorService>();

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
