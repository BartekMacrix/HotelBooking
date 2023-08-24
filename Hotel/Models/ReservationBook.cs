using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservoom.Exceptions;

namespace Hotel.Models
{
    class ReservationBook
    {
        private readonly List<Reservation> _roomsReservations;

        public ReservationBook() {

            _roomsReservations = new  List<Reservation>();
        }

        public IEnumerable<Reservation> GetAllReservations() { 
        return _roomsReservations;
        }

        public void AddReservation(Reservation reservation) {
            foreach (Reservation existingReservation in _roomsReservations)
            {
                if (existingReservation.Conflicts(reservation))
                {
                    throw new ReservationConflictException(existingReservation, reservation);
                }
            }
            _roomsReservations.Add(reservation);
        }
    }
}
