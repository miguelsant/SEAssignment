﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace TradersMarket.ObserverPattern.Observer
{
    public interface ISubscribe
    {
        void Notify();
    }
}
