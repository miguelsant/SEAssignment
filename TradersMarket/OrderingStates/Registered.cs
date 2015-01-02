using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderingStates
{
    public class Registered : IOrderState
    {
        private readonly OrderState _Parent;
        public string NewOrderPlaced()
        {
            return "OrderState has already been placed";
        }
        public Registered(OrderState OrderState)
        {
            _Parent = OrderState;
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
        public string Approve()
        {
            _Parent._CurrentState = new Approved(_Parent);
            return _Parent._CurrentState.Approve();
        }
    }
}
