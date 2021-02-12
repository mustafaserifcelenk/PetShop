﻿using Infrastructure.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Web.Interfaces;
using Web.ViewModels;

namespace Web.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketViewModelService _basketViewModelService;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public BasketController(IBasketViewModelService basketViewModelService, SignInManager<ApplicationUser> signInManager)
        {
            _basketViewModelService = basketViewModelService;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddToBasket(int id, int quantity = 1)
        {
            // todo: ilgili ürünü getir
            var product = _basketViewModelService.GetProductDetails(id);

            //get/create user id
            string userId = GetOrCreateUserId();

            // todo: sepet yoksa oluştur


            // todo: oluşan sepete ilgili ürün ekle
            return Json(new { BasketItemCount = 0 });
        }

        private string GetOrCreateUserId()
        {
            if (_signInManager.IsSignedIn(User))
            {
                return User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            }
            else
            {
                if (Request.Cookies[Constants.BASKET_COOKIENAME] != null)
                {
                    return Request.Cookies[Constants.BASKET_COOKIENAME].ToString();
                }
                else
                {
                    var guid = Guid.NewGuid().ToString();
                    var cookieOptions = new CookieOptions();
                    cookieOptions.Expires = DateTime.Now.AddYears(1);
                    Response.Cookies.Append(Constants.BASKET_COOKIENAME, guid, cookieOptions);
                    return guid;
                }
            }
        }
    }
}
