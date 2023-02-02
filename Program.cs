namespace Bioscoop_app;
using Deel1.Domain;
class Program
{
    static void Main(string[] args)
    {
        Movie movie1 = new Movie("Revenge of the Sith");
        MovieScreening movieScreening1 = new MovieScreening(movie1, DateTime.Now, 10);
        movie1.AddScreening(movieScreening1); Order order = new Order(7, false);
        order.AddSeatReservation(new MovieTicket(movieScreening1, 1, 1, true)); 
        Console.WriteLine(order.CalculatePrice());
        order.Export(TicketExportFormat.JSON);

        // DirectoryInfo di = new DirectoryInfo("./Deel1/");

        // string pathString = di.FullName + "Orders";

        // string fileName = "test" + ".txt";
        // pathString = System.IO.Path.Combine(pathString, fileName);

        // // Verify the path that you have constructed.
        // Console.WriteLine("Path to my file: {0}\n", pathString);
        // if (!System.IO.File.Exists(pathString))
        // {
        //     using (System.IO.FileStream fs = System.IO.File.Create(pathString))
        //     {
        //         for (byte i = 0; i < 100; i++)
        //         {
        //             fs.WriteByte(i);
        //         }
        //     }
        // }
        // else
        // {
        //     Console.WriteLine("File \"{0}\" already exists.", fileName);
        //     return;
        // }

        // // Read and display the data from your file.
        // try
        // {
        //     byte[] readBuffer = System.IO.File.ReadAllBytes(pathString);
        //     foreach (byte b in readBuffer)
        //     {
        //         Console.Write(b + " ");
        //     }
        //     Console.WriteLine();
        // }
        // catch (System.IO.IOException e)
        // {
        //     Console.WriteLine(e.Message);
        // }

        // // Keep the console window open in debug mode.
        // System.Console.WriteLine("Press any key to exit.");
        // System.Console.ReadKey();
    }
}
