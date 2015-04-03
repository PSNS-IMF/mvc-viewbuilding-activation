﻿[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(Psns.Common.Mvc.ViewBuilding.Activation.App_Start.ViewBuildingActivator), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Psns.Common.Mvc.ViewBuilding.Activation.App_Start.ViewBuildingActivator), "Stop")]

namespace Psns.Common.Mvc.ViewBuilding.Activation.App_Start
{
    using System.Web.Http;

    using Newtonsoft.Json.Serialization;

    public static class ViewBuildingActivator
    {
        /// <summary>
        /// Registers the ViewBuilding WebApiConfig, Adds ViewBuilding Controllers namespace to Controller Builder
        /// and sets Json Serialization to use CamelCasePropertyNamesContractResolver.
        /// </summary>
        public static void Start()
        {
            Psns.Common.Mvc.ViewBuilding.Infrastructure.WebApiConfig.Register(GlobalConfiguration.Configuration);
            
            System.Web.Mvc.ControllerBuilder.Current.DefaultNamespaces.Add("Psns.Common.Mvc.ViewBuilding.Controllers");

            GlobalConfiguration.Configuration
                .Formatters
                .JsonFormatter
                .SerializerSettings
                .ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {

        }
    }
}
