using AutoMapper;
using Shop.Common;
using Shop.Models.Models;
using Shop.Service;
using ShopEcommerce.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ShopEcommerce.Web.Controllers
{
    public class CartController : Controller
    {
        private IProductService _productService;

        public CartController(IProductService productService)
        {
            this._productService = productService;
        }

        public ActionResult CartDetail()
        {
            Session[CommonConstants.SessionCart] = new List<CartViewModel>();
            // Khoi tao mot gia tri rong cho list
            return View();
        }

        public JsonResult GetAll()
        {
            var cart = (List<CartViewModel>)Session[CommonConstants.SessionCart];
            return Json(new
            {
                data = cart,
                status = true
            }, JsonRequestBehavior.AllowGet);
            // lay ra
        }

        [HttpPost]
        public JsonResult Add(int productID)
        {
            var cart = (List<CartViewModel>)Session[CommonConstants.SessionCart];
            if (cart.Any(x => x.ProductID == productID))
            {
                foreach (var item in cart)
                {
                    if (item.ProductID == productID)
                    {
                        item.Quantity += 1;
                    }
                }
            }
            else
            {
                CartViewModel newItem = new CartViewModel();
                newItem.ProductID = productID;
                var product = _productService.GetById(productID);
                newItem.Product = Mapper.Map<Product, ProductViewModel>(product);
                newItem.Quantity = 1;
            }

            Session[CommonConstants.SessionCart] = cart;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult Update(string cartData)
        {
            var cartClien = new JavaScriptSerializer().Deserialize<List<CartViewModel>>(cartData);
            var cartSession = (List<CartViewModel>)Session[CommonConstants.SessionCart];
            foreach (var item in cartSession)
            {
                foreach (var jItem in cartClien)
                {
                    if (item.ProductID == jItem.ProductID)
                    {
                        item.Quantity = jItem.Quantity;
                    }
                }
            }

            Session[CommonConstants.SessionCart] = cartSession;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.SessionCart] = new List<CartViewModel>();
            return Json(new
            {
                status = true
            });
        }
    }
}