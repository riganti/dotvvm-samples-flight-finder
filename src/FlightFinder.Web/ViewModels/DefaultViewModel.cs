using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using FlightFinder.Shared;
using FlightFinder.Web.Api;

namespace FlightFinder.Web.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
        private readonly Client apiClient;


        [Bind(Direction.ServerToClientFirstRequest)]
        public IList<Airport> Airports { get; set; }

        [Bind(Direction.ServerToClientFirstRequest)]
        public IList<TicketClassData> TicketClasses => TicketClassData.All;

        [Bind(Direction.ServerToClientFirstRequest)]
        public IList<SortOrderData> SortOrders => SortOrderData.All;


        public IList<Itinerary> SearchResults { get; set; } = new List<Itinerary>();

        public List<Itinerary> Shortlist { get; set; } = new List<Itinerary>();

        public SearchCriteria Criteria { get; set; }

        public SortOrder SortOrder { get; set; }


        public DefaultViewModel(Api.Client apiClient)
        {
            this.apiClient = apiClient;
        }

        public override async Task Init()
        {
            if (!Context.IsPostBack)
            {
                Criteria = new SearchCriteria()
                {
                    FromAirport = "LHR",
                    ToAirport = "SEA",
                    OutboundDate = DateTime.Now.Date,
                    ReturnDate = DateTime.Now.Date.AddDays(7)
                };
                
                Airports = await apiClient.ApiAirportsGetAsync();
            }

            await base.Init();
        }

        public async Task Search()
        {
            var results = await apiClient.ApiFlightSearchPostAsync(Criteria);

            if (SortOrder == SortOrder.Price)
            {
                SearchResults = results.OrderBy(r => r.Price).ToList();
            }
            else
            {
                SearchResults = results.OrderBy(r => r.TotalDurationHours).ToList();
            }
        }

        public void AddToShortlist(Itinerary itinerary)
        {
            Shortlist.Add(itinerary);
        }

        public void RemoveFromShortlist(Itinerary itinerary)
        {
            Shortlist.Remove(itinerary);
        }

    }
}
