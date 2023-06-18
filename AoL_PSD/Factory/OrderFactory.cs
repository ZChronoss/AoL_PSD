using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AoL_PSD.Model;

namespace AoL_PSD.Factory
{
    public class OrderFactory
    {
        public static Order CreateOrder(User user, DateTime date)
        {
            Order newOrder = new Order()
            {
                UserId = user.Id,
                Date = date
            };

            return newOrder;
        }
    }
}