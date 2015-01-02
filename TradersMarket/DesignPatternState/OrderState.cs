using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPatternState
{
    public class OrderState 
    {
        public IOrderState CurrentState;

        public string OrderState()
        {
            return CurrentState = new NewOrder(this);
        }

        public string Dispatch()
        {
            return CurrentState.Shipped();
        }

        public string Register()
        {
            return CurrentState.Register();
        }

        public string Approve()
        {
            return CurrentState.Approve();
        }

    }
}
