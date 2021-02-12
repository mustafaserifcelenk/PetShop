﻿using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    class BasketService : IBasketService
    {
        private readonly IAsyncRepository<Basket> _basketRepository;

        public BasketService(IAsyncRepository<Basket> basketRepository)
        {
           _basketRepository = basketRepository;
        }

        public Task AddItemToBasketAsync(int basketId, int productId, decimal price, int quantity = 1)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> BasketExists(string buyerId)
        {
            return await _basketRepository.CountAsync(new BasketExistsSpecification(buyerId)) > 0; //Normalde buraya yapıyorduk sorguyu şimdi direk spec yapıyoruz.
        }

        public Task<int> CreateBasketAsync(string buyerId)
        {
            throw new NotImplementedException();
        }
    }
}
