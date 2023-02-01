using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deel1.Domain
{
    public class MovieTicket
    {
        private int RowNr;
        private int SeatNr;
        private bool IsPremium;
        private bool isStudentOrder;
        public MovieScreening MovieScreening { get; }

        public MovieTicket(MovieScreening movieScreening, int rowNr, int seatNr, bool isPremiumReservation)
        {
            MovieScreening = movieScreening;
            RowNr = rowNr;
            SeatNr = seatNr;
            IsPremium = isPremiumReservation;
        }
        public bool IsPremiumTicket()
        {
            return IsPremium;
        }
        public double GetPrice()
        {
            return MovieScreening.GetPricePerSeat();
        }

        public override string? ToString()
        {
            return base.ToString();
        }
    }
}
