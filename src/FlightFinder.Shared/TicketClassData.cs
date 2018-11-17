using System;
using System.Collections.Generic;
using System.Linq;

namespace FlightFinder.Shared
{
    public class TicketClassData
    {
        public string Name { get; set; }

        public TicketClass Value { get; set; }

        public static IList<TicketClassData> All { get; } = new[]
        {
            new TicketClassData() { Name = "Economy", Value = TicketClass.Economy },
            new TicketClassData() { Name = "PremiumEconomy", Value = TicketClass.PremiumEconomy },
            new TicketClassData() { Name = "Business", Value = TicketClass.Business },
            new TicketClassData() { Name = "First", Value = TicketClass.First }
        };

        public static TicketClassData Get(TicketClass ticketClass)
        {
            return All.Single(i => i.Value == ticketClass);
        }
    }
}