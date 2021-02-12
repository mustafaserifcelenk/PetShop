using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IBasketService
    {
        Task AddItemToBasketAsync(int basketId, int productId, decimal price, int quantity = 1);

        Task<bool> BasketExists(string buyerId);

        Task<int> CreateBasketAsync(string buyerId); //sepet oluşturup kullanıcı id döndürüyor
    }
}
