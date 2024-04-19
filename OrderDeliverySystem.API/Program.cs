using Autofac;
using Microsoft.Extensions.Configuration;
using OrderDeliverySystem.UserAccess.Infrastructure.Configuration;
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

static void InitializeModules(ILifetimeScope container, Serilog.ILogger logger)
{
    var httpContextAccessor = container.Resolve<IHttpContextAccessor>();
   // var executionContextAccessor = new ExecutionContextAccessor(httpContextAccessor);

   // var emailsConfiguration = new EmailsConfiguration(_configuration["EmailsConfiguration:FromEmail"]);
  
    UserAccessStartup.Initialize(
        "_configuration.GetConnectionString(MeetingsConnectionString)",
        logger,
        null);
  
}