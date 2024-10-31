using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemGroup4
{
    internal class Grouproom : Local
    {
        public Grouproom() { }
        
        public Grouproom(string name, DateTime startTime, TimeSpan duration)
            : base(name, startTime, duration ) //får prop från base class
        {

        }
        public void BookRoom(string name, DateTime startTime, TimeSpan duration)
        {

            base.BookRoom(name, startTime, duration); //kör base class metod
            
        }
        
    }
}
