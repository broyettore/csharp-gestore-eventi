using csharp_gestore_eventi.Classes;

namespace csharp_gestore_eventi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Event myEvent = new("Paris conference", DateTime.Now.AddDays(1), 200);

            try
            {

            Console.WriteLine(myEvent.eventDate = DateTime.Now.AddMinutes(-10));
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}