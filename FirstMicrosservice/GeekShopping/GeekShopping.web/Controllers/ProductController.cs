﻿using GeekShopping.web.Models;
using GeekShopping.web.Services.IServices;
using GeekShopping.web.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GeekShopping.web.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> ProductIndex()
        {
            var product = await _productService.FindAllProducts();
            return View(product);
        }
        public async Task<IActionResult> ProductCreate()
        {
            return View();
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductModel model)
        {
            if (ModelState.IsValid) 
            {
                var response = await _productService.CreateProduct(model);
                if (response != null) 
                {
                    return RedirectToAction(nameof(ProductIndex));                
                }
                else
                {
                    return View(model);
                }
            }
     
            return View(model);
        }

        public async Task<IActionResult> ProductUpdate(int id)
        {
            var model = await _productService.FindProductById(id);
            if (model != null) return View(model);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductModel model)
        {
            if (ModelState.IsValid)
            {
                var response = await _productService.UpdateProduct(model);
                if (response != null) return RedirectToAction(
                     nameof(ProductIndex));
            }
            return View(model);
        }

        [Authorize(Roles =Role.Admin)]
        [HttpPost]
        public async Task<IActionResult> ProductDelete(ProductModel model)
        {
     
                var response = await _productService.DeleteProductById(model.Id);
                if (response) return RedirectToAction(nameof(ProductIndex));
                  return View(model);
        }
    }
}