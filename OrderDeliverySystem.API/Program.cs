using Autofac;
using Autofac.Core;
using Microsoft.EntityFrameworkCore;
using OrderDeliverySystem.Basket.Infrastructure;
using OrderDeliverySystem.Basket.Infrastructure.Persistence;
using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using OrderDeliverySystem.CommonModule.Infrastructure.EventBus;
using OrderDeliverySystem.UserAccess.Application.Contracts;
using OrderDeliverySystem.UserAccess.Infrastructure;
using OrderDeliverySystem.UserAccess.Infrastructure.Persistence;
using Serilog;
using System.Reflection;
using OrderDeliverySystem.UserAccess.Infrastructure.Startup;
using Microsoft.EntityFrameworkCore.Diagnostics;
using OrderDeliverySystem.Basket.Infrastructure.Startup;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// Configure Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration));

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();



// Add Serilog logger
builder.Logging.AddSerilog();




builder.Services.AddUserAccessModule(builder.Configuration)
    .AddBasketModule(builder.Configuration); 

//builder.Services.AddSingleton<IAsyncEventBus, AsyncEventBus>();

builder.Services.AddHostedService<IntegrationEventProcessorJob>();


// Configure Autofac
//var containerBuilder = new ContainerBuilder();

//containerBuilder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

//containerBuilder.RegisterInstance(builder.Configuration).As<IConfiguration>();
//var container = containerBuilder.Build();
//builder.Services.AddSingleton(container);






// Register UserAccessAutofacModule
//containerBuilder.RegisterModule(new UserAccessAutofacModule());

//ConfigureContainer(containerBuilder);

// Build the Autofac container

// Set the Autofac container as the default dependency resolver for ASP.NET Core




//builder.Services.AddHostedService<IntegrationEventProcessorJob>();


//services.AddScoped<IHostedService, ReceiverService>();


//InitializeModules(container, logger, builder.Configuration.GetConnectionString("DefaultConnection"));



//builder.Services.AddEventBusModule();

//builder.Services.AddScoped<IUserAccessModule, UserAccessModule>();



//builder.Services.AddEventBusModule();



//builder.Services.AddScoped<IntegrationEventProcessorJob>();



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

//static void InitializeModules(ILifetimeScope container, Serilog.ILogger logger, string connectionString)
//{
//    var httpContextAccessor = container.Resolve<IHttpContextAccessor>();
//    // var executionContextAccessor = new ExecutionContextAccessor(httpContextAccessor);

//    // Resolve IConfiguration
//    //var configuration = container.Resolve<IConfiguration>();

//    // Initialize modules with resolved dependencies
//    UserAccessStartup.Initialize(
//        connectionString,
//        logger,
//        null);

//    BasketStartup.Initialize(
//        connectionString,
//        logger,
//        null);


//}

static void ConfigureContainer(ContainerBuilder containerBuilder)
{
    //containerBuilder.RegisterModule(new UserAccessAutofacModule());
    containerBuilder.RegisterType<UserAccessModule>().As<IUserAccessModule>().InstancePerLifetimeScope();
}
