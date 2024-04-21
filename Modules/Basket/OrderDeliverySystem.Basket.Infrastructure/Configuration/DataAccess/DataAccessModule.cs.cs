using Autofac;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderDeliverySystem.Basket.Infrastructure.Persistence;

namespace OrderDeliverySystem.Basket.Infrastructure.Configuration.DataAccess
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

            builder.Register(c =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<BasketContext>();
                optionsBuilder.UseSqlServer(_databaseConnectionString, b => b.MigrationsAssembly("OrderDeliverySystem.UserAccess.Infrastructure"));
                optionsBuilder.UseLoggerFactory(_loggerFactory);
                return new BasketContext(optionsBuilder.Options);
            }).AsSelf().InstancePerLifetimeScope();


            var infrastructureAssembly = typeof(BasketContext).Assembly;

            builder.RegisterAssemblyTypes(infrastructureAssembly)
                .Where(type => type.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .FindConstructorsWith(new AllConstructorFinder());
        }

    }
}
