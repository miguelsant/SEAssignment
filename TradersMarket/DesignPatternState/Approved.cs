using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternState
{
    
    public class Approved: IOrderState
    {
        private readonly OrderState Parent;

        public Approved(OrderState OrderState)
        {
            Parent = OrderState;
            this.Approve();
        }

        public string NewOrderPlaced()
        {
            return "Order has already been placed";
        }

        public void Shipped()
        {
            Parent.CurrentState = new Shipped(Parent);
        }

        public string Register()
        {
            return "Order has already been registered";
        }

        public string Approve()
        {
            return "Order has been Approved.";
        }


    }
}
