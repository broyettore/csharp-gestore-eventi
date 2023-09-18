using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_gestore_eventi.Classes
{
    public class Event
    {
        // ATTRIBUTES
        private string title;
        private DateTime date;
        private int maxCapacity;
        private int bookedSeats;

        // CONSTRUCT
        public Event(string title, DateTime date, int maxcapacity)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("title field can not be empty");
            this.title = title;

            if (date < DateTime.Now.AddMinutes(-1))
                throw new ArgumentException($"this date {date} is not correct");
            this.date = date;

            if (maxcapacity <= 0)
                throw new ArgumentException("Max capacity has to be a positive number");
            this.maxCapacity = maxcapacity;

            this.bookedSeats = 0;
        }

        // Getters only

        public int GetEventMaxCapacity()
        {
            return maxCapacity;
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
                if (this.date < DateTime.Now.AddMinutes(-1))
                {
                    throw new ArgumentException($"this date {value} is not correct");
                }
                this.date = value;
            }
        }



        // METHODS
        public int bookSeats(int numberOfSeatsToBook)
        {
            if (this.date < DateTime.Now.AddMinutes(-1))
            {
                throw new ArgumentException("the event has already passed");
            }
            if (this.bookedSeats + numberOfSeatsToBook > this.maxCapacity)
            {
                throw new ArgumentException("I'm sorry but we are fully booked");
            }
            if (numberOfSeatsToBook < 0)
            {
                throw new ArgumentException("Specify a number bigger than 0");
            }

            this.bookedSeats += numberOfSeatsToBook;  // Updates bookedSeats

            return this.bookedSeats;
        }

        public int cancelSeatBooking(int numberOfSeatsToCancel)
        {
            if (this.date < DateTime.Now.AddMinutes(-1))
            {
                throw new ArgumentException("the event has already ended");
            }
            if (this.bookedSeats < numberOfSeatsToCancel)
            {
                throw new ArgumentException("Booked seats do not match the seats you want to cancel");
            }
            if (numberOfSeatsToCancel < 0)
            {
                throw new ArgumentException("Specify a number bigger than 0");
            }

            this.bookedSeats -= numberOfSeatsToCancel;  // Updates bookedSeats after cancel

            return this.bookedSeats;
        }

        public override string ToString()
        {
            string formatDate = this.date.ToString("dd/MM/yyyy");
            return $"Event Date: {formatDate} - Event Title: {this.title}";
        }

    }
}
