using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternState
{

    
    public class NewOrder : IOrderState
    {

         private readonly OrderState Parent;

            public NewOrder(OrderState OrderState)
            {
                Parent = OrderState;
                this.NewOrderPlaced();
               
            }

            public bool IsShipped
            {
                get { return false; }
            }

            public string NewOrderPlaced()
            {
                return "New order has been placed";
            }

            public void Dispatch()
            {
                Parent.CurrentState = new Shipped(Parent);
            }

            public void Register()
            {
                Parent.CurrentState = new Registered(Parent);
            }

            public void Approve()
            {
                Parent.CurrentState = new Approved(Parent);
            }


    }
}
