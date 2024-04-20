using Autofac;
using OrderDeliverySystem.UserAccess.Application.Contracts;
using OrderDeliverySystem.UserAccess.Infrastructure;
using OrderDeliverySystem.UserAccess.Infrastructure.Configuration;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserAccessModule, UserAccessModule>();


// Configure Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration));

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();



// Add Serilog logger
builder.Logging.AddSerilog();

// Configure Autofac
var containerBuilder = new ContainerBuilder();

// Register dependencies
containerBuilder.RegisterType<HttpContextAccessor>().As<IHttpContextAccessor>().SingleInstance();

// Register IConfiguration
containerBuilder.RegisterInstance(builder.Configuration).As<IConfiguration>();

// Register UserAccessAutofacModule
//containerBuilder.RegisterModule(new UserAccessAutofacModule());

//ConfigureContainer(containerBuilder);

// Build the Autofac container
var container = containerBuilder.Build();

// Set the Autofac container as the default dependency resolver for ASP.NET Core
builder.Services.AddSingleton(container);

InitializeModules(container, logger, builder.Configuration.GetConnectionString("DefaultConnection"));

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


static void InitializeModules(ILifetimeScope container, Serilog.ILogger logger, string connectionString)
{
    var httpContextAccessor = container.Resolve<IHttpContextAccessor>();
    // var executionContextAccessor = new ExecutionContextAccessor(httpContextAccessor);

    // Resolve IConfiguration
    //var configuration = container.Resolve<IConfiguration>();

    // Initialize modules with resolved dependencies
    UserAccessStartup.Initialize(
        connectionString,
        logger,
        null);
}

static void ConfigureContainer(ContainerBuilder containerBuilder)
{
    //containerBuilder.RegisterModule(new UserAccessAutofacModule());
    containerBuilder.RegisterType<UserAccessModule>().As<IUserAccessModule>().InstancePerLifetimeScope();
}

//using Autofac;
//using Microsoft.Extensions.Configuration;
//using OrderDeliverySystem.UserAccess.Infrastructure.Configuration;
//using Serilog;
//using Autofac.Extensions.DependencyInjection;

//var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();



//builder.Host.ConfigureContainer(container =>
//{
//    container.RegisterModule(UserAccessStartup); // Замените на ваш реальный модуль(и)
//});


//var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

//var container = app.ApplicationServices.GetAutofacRoot();

//InitializeModules();


//app.UseHttpsRedirection();

//app.UseAuthorization();

//app.MapControllers();

//app.Run();

//static void InitializeModules(ILifetimeScope container, Serilog.ILogger logger)
//{
//    var httpContextAccessor = container.Resolve<IHttpContextAccessor>();
//    var executionContextAccessor = new ExecutionContextAccessor(httpContextAccessor);

//    var emailsConfiguration = new EmailsConfiguration(_configuration["EmailsConfiguration:FromEmail"]);

//    UserAccessStartup.Initialize(
//        "_configuration.GetConnectionString(MeetingsConnectionString)",
//        logger,
//        null);

//}