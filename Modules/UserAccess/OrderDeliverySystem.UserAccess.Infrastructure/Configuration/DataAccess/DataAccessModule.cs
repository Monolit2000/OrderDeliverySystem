using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using OrderDeliverySystem.UserAccess.Infrastructure.Persistence;


namespace OrderDeliverySystem.UserAccess.Infrastructure.Configuration.DataAccess
{
    public class DataAccessModule : Autofac.Module
    {
        private readonly string _databaseConnectionString;
        private readonly ILoggerFactory _loggerFactory;

        internal DataAccessModule(string databaseConnectionString, ILoggerFactory loggerFactory)
        {
            _databaseConnectionString = databaseConnectionString;
            _loggerFactory = loggerFactory;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DispatchDomainEventsInterceptor>()
                .As<ISaveChangesInterceptor>()
                .InstancePerLifetimeScope();


            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<UserAccessContext>();
                optionsBuilder.UseSqlServer(_databaseConnectionString, b => b.MigrationsAssembly("OrderDeliverySystem.UserAccess.Infrastructure"));
                optionsBuilder.UseLoggerFactory(_loggerFactory);
              

                var interceptor = c.Resolve<ISaveChangesInterceptor>();
                optionsBuilder.AddInterceptors(interceptor);

                return new UserAccessContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();


            var infrastructureAssembly = typeof(UserAccessContext).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());
        }

    }
}
