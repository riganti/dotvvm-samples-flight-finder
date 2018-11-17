using System;

namespace FlightFinder.Shared
{
    public class SearchCriteria
    {
        public string FromAirport { get; set; }
        public string ToAirport { get; set; }
        public DateTime OutboundDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public TicketClass TicketClass { get; set; }

    }
}
