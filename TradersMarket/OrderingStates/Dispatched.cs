using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderingStates
{
    public class Dispatched : IOrderState
    {
        private readonly OrderState _Parent;
        public string NewOrderPlaced()
        {
            return "OrderState has already been placed";
        }
        public Dispatched(OrderState OrderState)
        {
            _Parent = OrderState;
            this.Dispatch();
        }
        public string Dispatch()
        {
            return "Order has been dispatched.";
        }
        public string Register()
        {
            return "OrderState has already been registered";
        }
        public string Approve()
        {
            _Parent._CurrentState = new Approved(_Parent);
            return _Parent._CurrentState.Approve();
        }
    }
}
