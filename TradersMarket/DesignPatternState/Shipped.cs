using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternState
{

    
    public class Shipped : IOrderState
    {
        private readonly OrderState Parent;

        public void NewOrderPlaced()
        {
            throw new Exception("OrderState has already been placed");
        }

        public Shipped(OrderState OrderState)
        {
            Parent = OrderState;
            this.Dispatch();
        }

        public string Dispatch()
        {
            return "Order has been dispatched.";
        }

        public void Register()
        {
            throw new Exception("OrderState has already been registered");
        }

        public void Approve()
        {
            Parent.CurrentState = new Approved(Parent);
        }



    }
}
