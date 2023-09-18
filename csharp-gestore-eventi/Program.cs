using csharp_gestore_eventi.Classes;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {    
            try
            {
                Event myEvent = new("Paris conference", DateTime.Now.AddDays(1), 100);
                myEvent.bookSeats(80);
                myEvent.cancelSeatBooking(70);
                Console.WriteLine(myEvent.GetTotalBookedSeats());
                Console.WriteLine(myEvent);
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}