using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OrderingStates
{
    public class Approved : IOrderState
    {
        private readonly OrderState _Parent;
        public Approved(OrderState OrderState)
        {
            _Parent = OrderState;
            this.Approve();
        }
        public string NewOrderPlaced()
        {
            return "OrderState has already been placed";
        }
        public string Dispatch()
        {
            _Parent._CurrentState = new Dispatched(_Parent);
            return _Parent._CurrentState.Dispatch();
        }
        public string Register()
        {
            return "OrderState has already been registered";
        }
        public string Approve()
        {
            return "Order has been Approved.";
        }
    }
}
