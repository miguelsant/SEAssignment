using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternState
{

    

    public class Registered : IOrderState
    {
        private readonly OrderState Parent;

        public string NewOrderPlaced()
        {
            return "OrderState has already been placed";
        }

        public Registered(OrderState OrderState)
        {
            Parent = OrderState;
            this.Register();
        }

        public string Dispatch()
        {
            return "OrderState has not been registered yet";
        }

        public string Register()
        {
            return "Order has been registered.";
        }

        public void Approve()
        {
            Parent.CurrentState = new Approved(Parent);
        }



    }
}
