using ABCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Model.EF;

namespace ABCApplication.Controllers
{
    public class CartController : BaseController
    {
        private const string CartSession = "CartSession";
        // GET: Admin/Cart
        public ActionResult Index()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if(cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public JsonResult RemoveAll()
        {
            Session[CartSession] = null;
            return Json(new
            {
                status = true
            });
        }

        public JsonResult Remove(int id)
        {
            var sessionCart = (List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Product.ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });
        }

        [HttpGet]
        public ActionResult AddOrder()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            } 
            return View(list);
        }

        [HttpPost]
        public ActionResult AddOrder(string cusName, string cusPhone, string cusEmail, string cusAddress)
        {
            var order = new Order();
            order.CusName = cusName;
            order.CusPhone = cusPhone;
            order.CusEmail = cusEmail;
            order.CusAddress = cusAddress;
            order.OrderDate = DateTime.Now;

            try
            {
                var id = new OrderController().Insert(order);
                var cart = (List<CartItem>)Session[CartSession];
                var detailController = new OrderDetailController();
                foreach (var item in cart)
                {
                    var orderDetail = new OrderDetail();
                    orderDetail.ProductID = item.Product.ID;
                    orderDetail.OrderID = id;
                    orderDetail.Quantity = item.Quantity;
                    detailController.Insert(orderDetail);
                }
            }
            catch (Exception ex)
            {
                throw;
            }            
            return Redirect("/complete");
        }

        public ActionResult Success()
        {
            Session[CartSession] = null;
            return View();
        }

        public ActionResult AddItem(int productId, int quantity)
        {
            var product = new ProductController().ViewDetail(productId);
            var cart = Session[CartSession];
            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if(list.Exists(c => c.Product.ID == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.ID == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.Quantity = quantity;
                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                //create new object cart item
                var item = new CartItem();
                item.Product = product;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item); 
                Session[CartSession] = list;
            }
            return RedirectToAction("Index");
        }

    }
}