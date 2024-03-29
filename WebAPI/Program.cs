
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolver.Autofac;

namespace WebAPI
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
            //builder.Services.AddSingleton<ICarService, CarManager>();
            //builder.Services.AddSingleton<ICarDal,EfCarDal>();
            //builder.Services.AddSingleton<IUserService,UserManager>();
            //builder.Services.AddSingleton<IUserDal,EfUserDal>();
            //builder.Services.AddSingleton<ICustomerService,CustomerManager>();
            //builder.Services.AddSingleton<ICustomerDal,EfCustomerDal>();
            //builder.Services.AddSingleton<IRentalService,RentalManager>();
            //builder.Services.AddSingleton<IRentalDal,EfRentalDal>();
            builder.Host
       .UseServiceProviderFactory(new AutofacServiceProviderFactory())
       .ConfigureContainer<ContainerBuilder>(builder =>
       {
           builder.RegisterModule(new AutofacBusinessModule());
       });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
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
