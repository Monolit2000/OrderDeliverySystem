using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using OrderDeliverySystem.CommonModule.Infrastructure.EventBus;
using OrderDeliverySystem.UserAccess.Infrastructure.Configuration.EventsBus;
using OrderDeliverySystem.UserAccess.Infrastructure.Configuration.Logging;
using OrderDeliverySystem.UserAccess.Infrastructure.Configuration.Mediation;
using Serilog;
using Autofac.Core;
using IContainer = Autofac.IContainer;
using OrderDeliverySystem.UserAccess.Infrastructure.Configuration.DataAccess;
using OrderDeliverySystem.UserAccess.Infrastructure.Configuration.Processing;

namespace OrderDeliverySystem.UserAccess.Infrastructure.Configuration
{
    public class UserAccessStartup
    {
        private static IContainer _container;

        public static void Initialize( string connectionString, ILogger logger,  IEventsBus eventsBus,
            long? internalProcessingPoolingInterval = null)
        {

            ConfigureCompositionRoot( connectionString, logger,   eventsBus);

            var moduleLogger = logger.ForContext("Module", "UserAccess");
            EventsBusStartup.Initialize(moduleLogger);

            //QuartzStartup.Initialize(moduleLogger, internalProcessingPoolingInterval);
        }

        private static void ConfigureCompositionRoot(
            string connectionString,
            ILogger logger,
            IEventsBus eventsBus)
        {
            var containerBuilder = new ContainerBuilder();


            containerBuilder.RegisterModule(new LoggingModule(logger.ForContext("Module", "UserAccess")));

            var loggerFactory = new Serilog.Extensions.Logging.SerilogLoggerFactory(logger);
            containerBuilder.RegisterModule(new DataAccessModule(connectionString, loggerFactory));
            containerBuilder.RegisterModule(new EventsBusModule(eventsBus));
            containerBuilder.RegisterModule(new MediatorModule());

            containerBuilder.RegisterModule(new ProcessingModule());

            _container = containerBuilder.Build();

            UserAccessCompositionRoot.SetContainer(_container);

            //containerBuilder.RegisterModule(new OutboxModule(new BiDictionary<string, Type>()));

            //containerBuilder.RegisterModule(new QuartzModule());
            //containerBuilder.RegisterModule(new EmailModule(emailsConfiguration, emailSender));
            //containerBuilder.RegisterModule(new SecurityModule(textEncryptionKey));

            //containerBuilder.RegisterInstance(executionContextAccessor);

        }
    }
}
