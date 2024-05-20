using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using Serilog;
using OrderDeliverySystem.UserAccess.Infrastructure.Startup;
using OrderDeliverySystem.Basket.Infrastructure.Startup;
using OrderDeliverySystem.Catalog.Infrastructure.Startup;
using OrderDeliverySystem.Ordering.Infrastructure.Startup;
using OrderDeliverySystem.Payments.Infrastructure.Startup;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Configure Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration)
   /* .WriteTo.Console()*/);

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    //.WriteTo.Console()
    .CreateLogger();


//Add Serilog logger
builder.Logging.AddSerilog();


builder.Services
    .AddUserAccessModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddCatalogModule(builder.Configuration)
    .AddOrderModule(builder.Configuration)
    .AddPaymentModule(builder.Configuration);


builder.Services.AddHostedService<IntegrationEventProcessorJob>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();



