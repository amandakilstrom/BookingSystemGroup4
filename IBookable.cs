﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingSystemGroup4
{
    internal interface IBookable
    {
        void BookRoom(string name, DateTime startTime, TimeSpan duration, string bookingName); 
    }
}
