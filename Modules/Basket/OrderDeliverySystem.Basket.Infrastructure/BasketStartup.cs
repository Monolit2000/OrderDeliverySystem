using Autofac;
using OrderDeliverySystem.Basket.Infrastructure.Configuration;
using OrderDeliverySystem.Basket.Infrastructure.Configuration.DataAccess;
using OrderDeliverySystem.Basket.Infrastructure.Configuration.EventsBus;
using OrderDeliverySystem.Basket.Infrastructure.Configuration.Logging;
using OrderDeliverySystem.Basket.Infrastructure.Configuration.Mediation.cs;
using OrderDeliverySystem.CommonModule.Infrastructure.EventBus;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderDeliverySystem.Basket.Infrastructure
{
    public class BasketStartup
    {
        
            private static IContainer _container;

            public static void Initialize(
                string connectionString,
                ILogger logger,
                //string textEncryptionKey,
                IEventsBus eventsBus,
                long? internalProcessingPoolingInterval = null)
            {
                var moduleLogger = logger.ForContext("Module", "UserAccess");

                ConfigureCompositionRoot(
                    connectionString,
                    logger,
                    //textEncryptionKey,
                    eventsBus);

                //QuartzStartup.Initialize(moduleLogger, internalProcessingPoolingInterval);

                EventsBusStartup.Initialize(moduleLogger);
            }

            private static void ConfigureCompositionRoot(
                string connectionString,
                ILogger logger,
                //string textEncryptionKey,
                IEventsBus eventsBus)
            {
                var containerBuilder = new ContainerBuilder();


                containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "UserAccess")));

                var loggerFactory = new Serilog.Extensions.Logging.SerilogLoggerFactory(logger);
                containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
                containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
                containerBuilder.RegisterModule(new MediatorModule());

                _container = containerBuilder.Build();

                 BasketCompositionRoot.SetContainer(_container);

                //containerBuilder.RegisterModule(new ProcessingModule());
                //containerBuilder.RegisterModule(new OutboxModule(new BiDictionary<string, Type>()));

                //containerBuilder.RegisterModule(new QuartzModule());
                //containerBuilder.RegisterModule(new EmailModule(emailsConfiguration, emailSender));
                //containerBuilder.RegisterModule(new SecurityModule(textEncryptionKey));

                //containerBuilder.RegisterInstance(executionContextAccessor);

            }
        
    }
}
