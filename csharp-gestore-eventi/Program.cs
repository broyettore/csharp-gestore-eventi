using csharp_gestore_eventi.Classes;
using System.Globalization;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Event Handler 2.0 \n ");

            // asks user event name
            Console.WriteLine("How would you like to name your event");
            string eventName = Console.ReadLine();

            // asks user event date
            Console.WriteLine("When should the event take place (example: 10 january 2020 10:30)");
            DateTime parsedDate;

            // loop unitl date is written correctly
            while (DateTime.TryParseExact(Console.ReadLine(), "dd MMMM yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedDate) == false)
            {
                Console.WriteLine("Date is written wrong");
            }

            // asks user max capacity of the event
            Console.WriteLine("What shoulg be the max capacity of your event");
            int totalSeats;

            while (int.TryParse(Console.ReadLine(), out totalSeats) == false)
            {
                Console.WriteLine("Please insert a number");
            }

            try
            {
                // event instance created
                Event myEvent = new(eventName, parsedDate, totalSeats);

                //asks user if and how many seats should be booked
                Console.WriteLine("Would you like to book some seats (yes / no)");
                string answer = Console.ReadLine();

                if(answer == "yes")
                {
                    Console.WriteLine("How many seats should be booked");
                    int seatToBook = int.Parse(Console.ReadLine());

                    myEvent.bookSeats(seatToBook);
                } else
                {
                    Console.WriteLine("No seats booked then !");
                }

                int seatsBooked = myEvent.GetTotalBookedSeats();
                Console.WriteLine($"This is the number of seats booked: {seatsBooked}");
                
                myEvent.GetTotalBookedSeats();
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}