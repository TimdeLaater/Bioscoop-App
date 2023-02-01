using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Deel1.Domain
{
    public class Order
    {
        private int Id { get; set; }
        private int OrderNr { get; set; }
        private bool IsStudentOrder;
        private MovieTicket? MovieTicket;

        private MovieTicket Ticket { get; set; }

        public Order(int orderNr, bool isStudentOrder)
        {
            OrderNr = orderNr;
            IsStudentOrder = isStudentOrder;
        }
        public void AddSeatReservation(MovieTicket ticket)
        {
            this.Ticket = ticket;
            ticket.MovieScreening.TicketsOrdered.Add(Ticket);
        }
        public double CalculatePrice()
        {
            double premiumExtra = 0;

            if (Ticket.IsPremiumTicket())
            {
                if (IsStudentOrder)
                    premiumExtra = 2;
                else
                    premiumExtra = 3;
            }

            bool weekend = DateTime.Today.DayOfWeek == DayOfWeek.Sunday
                || DateTime.Today.DayOfWeek == DayOfWeek.Saturday
                || DateTime.Today.DayOfWeek == DayOfWeek.Friday;

            if (weekend && IsStudentOrder)
            {
                int Count = 0;
                while (OrderNr % 2 == 0 && OrderNr != 0)
                {
                    Count++;
                    OrderNr = OrderNr - 2;
                }
                return (Count + OrderNr) * (Ticket.GetPrice() + premiumExtra);
            }
            if (weekend && !IsStudentOrder && OrderNr >= 6)
                return (OrderNr) * (Ticket.GetPrice() + premiumExtra) * 0.9;
            return (OrderNr) * (Ticket.GetPrice() + premiumExtra);
        }

        public void Export(TicketExportFormat exportFormat)
        {
            DirectoryInfo di = new DirectoryInfo("./Deel1/");
            string pathString = di.FullName + "Orders";

            string fileName = this.OrderNr.ToString() + ".txt";
            pathString = System.IO.Path.Combine(pathString, fileName);

            // Verify the path that you have constructed.
            Console.WriteLine("Path to my file: {0}\n", pathString);
            //Get the 
            string[] exportData =
            {
               "Ordernummer: "+ this.OrderNr.ToString(),"Prijs: €"+ CalculatePrice().ToString()
            };
            byte[] bytes = Encoding.UTF8.GetBytes(exportData);
            if (!System.IO.File.Exists(pathString))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                {

                    for (int i = 0; i < bytes.Length; i++)
                    {
                        fs.Write(bytes[i]);
                    }
                }
            }
            else
            {
                Console.WriteLine("File \"{0}\" already exists.", fileName);
                return;
            }

            // Read and display the data from your file.
            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
                foreach (byte b in readBuffer)
                {
                    Console.Write(b + " ");
                }
                Console.WriteLine();
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

