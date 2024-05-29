using OrderDeliverySystem.CommonModule.Infrastructure.AsyncEventBus;
using Serilog;
using OrderDeliverySystem.UserAccess.Infrastructure.Startup;
using OrderDeliverySystem.Basket.Infrastructure.Startup;
using OrderDeliverySystem.Catalog.Infrastructure.Startup;
using OrderDeliverySystem.Ordering.Infrastructure.Startup;
using OrderDeliverySystem.Payments.Infrastructure.Startup;
using OrderDeliverySystem.Notifications.Infrastructure.Startup;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();

// Add Swagger/OpenAPI services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Configure Serilog
builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
    .ReadFrom.Configuration(hostingContext.Configuration));

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();


//Add Serilog logger
builder.Logging.AddSerilog();



// Configure CORS to allow all origins, methods, and headers
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});



builder.Services
    .AddUserAccessModule(builder.Configuration)
    .AddBasketModule(builder.Configuration)
    .AddCatalogModule(builder.Configuration)
    .AddOrderModule(builder.Configuration)
    .AddPaymentModule(builder.Configuration)
    .AddNotificationModule(builder.Configuration);



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

// Use CORS policy to allow all
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();



