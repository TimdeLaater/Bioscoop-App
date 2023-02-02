using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deel1.Domain
{
    public class MovieScreening
    {
        public List<MovieTicket> TicketsOrdered { get; set; }
        public DateTime DateAndTime { get; set; }
        private double PricePerSeat { get; set; }
        private Movie Movie { get; }
        public MovieScreening(Movie Movie, DateTime DateAndTime, double PricePerSeat)
        {
            this.Movie = Movie;
            this.DateAndTime = DateAndTime;
            this.PricePerSeat = PricePerSeat;
            TicketsOrdered = new List<MovieTicket>();
        }
        public double GetPricePerSeat()
        {
            return PricePerSeat;
        }

        public override string? ToString()
        {
            return $"{Movie.Title}, screening at: {DateAndTime}. Get Your tickets today for €{PricePerSeat}";
        }
    }
}
