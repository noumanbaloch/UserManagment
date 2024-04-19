
using UserManagement.Application;
using UserManagement.Infrastructure;

namespace UserManagmenet.API;

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


        // This is just for local demo normaly we only allow specfic clients
        // Add CORS service
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAllOrigins", builder =>
            {
                builder.AllowAnyOrigin() // Allow all origins
                       .AllowAnyMethod() // Allow all HTTP methods
                       .AllowAnyHeader(); // Allow all headers
            });
        });


        builder.Services.AddApplicationServices();
        builder.Services.AddPersistenceServices(builder.Configuration);

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseCors("AllowAllOrigins");

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}
