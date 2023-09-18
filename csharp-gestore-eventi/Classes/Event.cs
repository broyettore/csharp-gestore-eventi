using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi.Classes
{
    public class Event
    {
        private string title;
        private DateTime date;
        private int maxCapacity;
        private int bookedSeats;

        public Event(string title, DateTime date, int maxcapacity)
        {
            this.title = title;
            this.date = date;
            this.maxCapacity = maxcapacity;
            this.bookedSeats = 0;
        }

        // Getters only

        public int GetEventMaxCapacity // only read
        {
            get 
            { 
                return maxCapacity;
            }

            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Max Capacity must be a positive number");
                this.maxCapacity = value;
            }
        }

        public int GetTotalBookedSeats()
        {
            return this.bookedSeats;
        }

        //Getters and Setters
        public string eventTitle
        {
            get
            {
                return this.title;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("title field can not be empty");
                }
                this.title = value;
            }
        }

        public DateTime eventDate
        {
            get
            {
                return this.date;
            }

            set
            {
                if (value < DateTime.Now.AddMinutes(-1))
                {
                    throw new ArgumentException($"this date {value} is not correct");
                }
                this.date = value;
            }
        }

        // METHODS
        

    }
}
