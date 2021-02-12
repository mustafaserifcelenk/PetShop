using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels
{
    public class BasketViewModel
    {
        public string Id { get; set; }
        public string BuyerId { get; set; }
        public List<BasketItemViewModel> Items { get; set; }
        public decimal Total()
        {
            return Items.Sum(x => x.UnitPrice * x.Quantity);
        }
    }
}
