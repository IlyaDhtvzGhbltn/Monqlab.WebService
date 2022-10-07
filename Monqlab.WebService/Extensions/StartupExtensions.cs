using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monqlab.WebService.Entities;
using Monqlab.WebService.Infrastructure;
using Monqlab.WebService.Infrastructure.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monqlab.WebService.Extensions
{
    public static class StartupExtensions
    {
        /// <summary>
        /// Registers a context factory.
        /// Adds a context specifying a connection string
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration) 
        {
            IFactory<MonqlabDbContext> factory = CreateFactoryDBContext(configuration);
            services.AddSingleton<IFactory<MonqlabDbContext>>(factory);
            services.AddDbContext<MonqlabDbContext>(x => x.UseSqlServer(configuration[Settings.ConnectionString]));
        }

        /// <summary>
        /// Adds IMailService service implementation to middleware
        /// </summary>
        /// <param name="services">IServiceCollection</param>
        /// <param name="configuration">IConfiguration</param>
        public static void AddServices(this IServiceCollection services, IConfiguration configuration) 
        {
            string host = configuration[Settings.SmtpHost];
            string sender = configuration[Settings.SmtpSender];
            int port = int.Parse(configuration[Settings.SmtpPort]);
            var smtpSettings = new DTO.SmtpSettings(host, port, sender);

            services.AddSingleton<IMailService>(new MailService(smtpSettings));
        }

        private static IFactory<MonqlabDbContext> CreateFactoryDBContext(IConfiguration configuration)
        {
            return new DbFactory<MonqlabDbContext>(() =>
            {
                var optBuilder = new DbContextOptionsBuilder<MonqlabDbContext>();
                string connectionString = configuration[Settings.ConnectionString];
                optBuilder.UseSqlServer(connectionString);
                optBuilder.EnableSensitiveDataLogging();
                return new MonqlabDbContext(optBuilder.Options);
            });
        }

    }
}
