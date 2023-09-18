using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace csharp_gestore_eventi.Classes
{
    public class Conference : Event
    {
        public string Speaker { get; private set; }
        public double Price { get; private set; }

        public Conference(string title, DateTime date, int maxcapacity, string speaker, double price) : base(title, date, maxcapacity)
        {
            Speaker = speaker;
            Price = price;
        }


        // METHODS

        // formats price
        public string FormatPrice()
        {
            return Price.ToString("0.00") + "€";
        }

        // formats date
        public string FormatDate()
        {
            return this.eventDate.ToString("dd MMMM yyyy hh:mm");
        }

        public override string ToString()
        {
            string formattedPrice = FormatPrice();
            string formattedDate = FormatDate();
            return $"{formattedDate} - {this.eventTitle} - {this.Speaker} - {formattedPrice}";
        }
    }

}
