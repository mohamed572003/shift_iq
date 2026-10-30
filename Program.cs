
using Microsoft.EntityFrameworkCore;
using shiftIQ.API.Data;

namespace shiftIQ.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register Controllers
            builder.Services.AddControllers();

            // Register Database Context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                )
            );

            // Register Swagger
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Check Database Connection
            using (var scope = app.Services.CreateScope())
            {
                var db = scope.ServiceProvider
                    .GetRequiredService<AppDbContext>();

                try
                {
                    var canConnect = db.Database.CanConnect();

                    Console.WriteLine(
                        $"SQL Server connection successful: {canConnect}"
                    );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(
                        $"Database connection failed: {ex.Message}"
                    );
                }
            }

            // Configure Swagger
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // Configure Middleware
            app.UseHttpsRedirection();
            app.UseAuthorization();

            // Map Controllers
            app.MapControllers();

            app.Run();
        }
    }
}
