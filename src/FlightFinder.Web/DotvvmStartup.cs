﻿using DotVVM.Framework.Configuration;
using DotVVM.Framework.ResourceManagement;
using DotVVM.Framework.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace FlightFinder.Web
{
    public class DotvvmStartup : IDotvvmStartup, IDotvvmServiceConfigurator
    {
        // For more information about this class, visit https://dotvvm.com/docs/tutorials/basics-project-structure
        public void Configure(DotvvmConfiguration config, string applicationPath)
        {
            ConfigureRoutes(config, applicationPath);
            ConfigureControls(config, applicationPath);
            ConfigureResources(config, applicationPath);

            config.RegisterApiClient(typeof(Api.Client), Startup.FlightsApiUrl, "js/ApiClient.js", "_myApi");
        }

        private void ConfigureRoutes(DotvvmConfiguration config, string applicationPath)
        {
            config.RouteTable.Add("Default", "", "Views/Default.dothtml");
            config.RouteTable.AutoDiscoverRoutes(new DefaultRouteStrategy(config));    
        }

        private void ConfigureControls(DotvvmConfiguration config, string applicationPath)
        {
            // register code-only controls and markup controls
            config.Markup.AddMarkupControl("cc", "GreyOutZone", "Controls/GreyOutZone.dotcontrol");
            config.Markup.AddMarkupControl("cc", "Search", "Controls/Search.dotcontrol");
            config.Markup.AddMarkupControl("cc", "SearchResultFlightSegment", "Controls/SearchResultFlightSegment.dotcontrol");
            config.Markup.AddMarkupControl("cc", "SearchResults", "Controls/SearchResults.dotcontrol");
            config.Markup.AddMarkupControl("cc", "Shortlist", "Controls/Shortlist.dotcontrol");
            config.Markup.AddMarkupControl("cc", "ShortlistFlightSegment", "Controls/ShortlistFlightSegment.dotcontrol");
        }

        private void ConfigureResources(DotvvmConfiguration config, string applicationPath)
        {
            // register custom resources and adjust paths to the built-in resources
        }
		public void ConfigureServices(IDotvvmServiceCollection options)
        {
            options.AddDefaultTempStorages("temp");
		}
    }
}
