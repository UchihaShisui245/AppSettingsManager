using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppSettingsManager.Extensions
{
    public static class ConfigureExtension
    {
        public static void AddSectionConfiguration<T>(this IServiceCollection collection, IConfiguration configuration, string sectionParams = null) where T : class
        {
            if (string.IsNullOrEmpty(sectionParams))
            {
                sectionParams = typeof(T).Name;
            }

            var settings = Activator.CreateInstance<T>();
            new Microsoft.Extensions.Options.ConfigureFromConfigurationOptions<T>(configuration.GetSection(sectionParams)).Configure(settings);
            collection.AddSingleton(settings);

        }
    }
}
