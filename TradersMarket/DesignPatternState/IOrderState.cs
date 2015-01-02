using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternState
{
    public interface IOrderState
    {

        string NewOrderPlaced();
        string Register();
        string Shipped();
        string Approve();

    }
}
