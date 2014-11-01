using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;
using System.Data.Entity;
namespace DataAccess
{

   public class ConnectionClass
    {

       public TradersMarketplaceDBEntities MarketplaceEntity;

        public ConnectionClass()
        {
            MarketplaceEntity = new TradersMarketplaceDBEntities();
        }

    }
}
