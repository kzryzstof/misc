using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Hosting;
using NoSuchCompany.Diagnostics;

namespace NoSuchCompany.QualityTools.Service.Automation.Hosting
{
    #region Class

    [ExcludeFromCodeCoverage]
    public static class HostHelper
    {
        #region Public Methods

        /// <summary>
        /// Builds an instance of the specified <typeparamref name="TFunctionType"/>
        /// with the services defined in the <paramref name="startup"/> instance.
        /// </summary>
        /// <typeparam name="TFunctionType"></typeparam>
        /// <param name="startup"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if:
        /// - The <paramref name="startup" /> instance is not specified.
        /// </exception>
        public static TFunctionType Instantiate<TFunctionType>(Startup startup)
        {
            if(startup is null)
                throw new ArgumentNullException($"The parameter {nameof(startup)} instance is not specified.");
                
            IHost host = new HostBuilder().ConfigureWebJobs(startup.Configure).Build();

            return Instantiate<TFunctionType>(host);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Instantiates the specified <typeparamref name="TFunctionType"></typeparamref>.
        /// </summary>
        /// <typeparam name="TFunctionType"></typeparam>
        /// <param name="host"></param>
        /// <returns></returns>
        private static TFunctionType Instantiate<TFunctionType>(IHost host)
        {
            Type type = typeof(TFunctionType);

            ConstructorInfo constructorInfo = type.GetConstructors().FirstOrDefault();

            ParameterInfo[] parametersInfo = constructorInfo.GetParameters();

            object[] parameters = LookupServiceInstances(host, parametersInfo);

            return (TFunctionType) Activator.CreateInstance(type, parameters);
        }

        /// <summary>
        /// Gets all the parameters instances from the host's services.
        /// </summary>
        /// <param name="host"></param>
        /// <param name="parametersInfo"></param>
        /// <returns></returns>
        private static object[] LookupServiceInstances(IHost host, IReadOnlyList<ParameterInfo> parametersInfo)
        {
            return parametersInfo.Select(parameter => host.Services.GetService(parameter.ParameterType))
                                 .ToArray();
        }

        #endregion
    }

    #endregion
}
