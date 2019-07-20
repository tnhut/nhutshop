using AutoMapper;
using NhutShop.Common;
using NhutShop.Model.Models;
using NhutShop.Service;
using NhutShop.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace NhutShop.Web.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        IProductService _productService;
        public ShoppingCartController(IProductService productService)
        {
            this._productService = productService;
        }
        public ActionResult Index()
        {
            if(Session[CommonConstants.SessionCart]==null)
                Session[CommonConstants.SessionCart] = new List<ShoppingCartViewModel>();
            return View();
        }

        public JsonResult GetAll()
        {
            if (Session[CommonConstants.SessionCart] == null)
                Session[CommonConstants.SessionCart] = new List<ShoppingCartViewModel>();
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            return Json(new
            {
                data = cart,
                status=true
            },JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(int id)
        {
            var cart = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            if (cart == null)
            {
                cart= new List<ShoppingCartViewModel>();
            }
            if (cart.Any(x => x.ProductId == id)){
                foreach(var item in cart)
                {
                    if(item.ProductId== id)
                    {

                    }
                }
            
            }
            else
            {
                ShoppingCartViewModel newItem = new ShoppingCartViewModel();
                newItem.ProductId = id;
                var product = _productService.GetById(id);
                newItem.Product = Mapper.Map<Product, ProductViewModel>(product);
                newItem.Quantity = 1;
                cart.Add(newItem);
            }

            Session[CommonConstants.SessionCart] = cart;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult DeleteItem(int id)
        {
            var cartSession = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            if(cartSession!=null)
            {
                cartSession.RemoveAll(x => x.ProductId == id);
                Session[CommonConstants.SessionCart] = cartSession;
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }
        [HttpPost]
        public JsonResult Update(string cartData)
        {
            var cartViewModel = new JavaScriptSerializer().Deserialize<List<ShoppingCartViewModel>>(cartData);
            var cartSession = (List<ShoppingCartViewModel>)Session[CommonConstants.SessionCart];
            foreach(var item in cartSession)
            {
                foreach(var jitem in cartViewModel)
                {
                    if(item.ProductId==jitem.ProductId)
                    {
                        item.Quantity = jitem.Quantity;
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
            Session[CommonConstants.SessionCart] = new List<ShoppingCartViewModel>();
            return Json(new
            {
                status = true
            });
        }
    }
}