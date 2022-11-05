using EXAMEN.Entities;
using EXAMEN.Entities.Data;
using EXAMEN.Models.ViewModels.Order;
using EXAMEN.Models.ViewModels.OrderDetail;
using EXAMEN.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EXAMEN.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrdersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IActionResult> Index()
        {
            Expression<Func<Order, bool>> filter = p => p.Confirmed != true;

            var orders = await _unitOfWork.Order.Find(filter);

            var result = orders
                    .Select(order => new OrderViewModel
                    {
                        OrderId = order.OrderId,
                        OrderDate = order.OrderDate,
                        ContactName = order.Customer.ContactName ?? order.Customer.CompanyName,
                        Phone = order.Customer.Phone
                    })
                    .OrderByDescending(x => x.OrderDate);

            
            return View(result);
        }
        public async Task<IActionResult> Details(int? orderId)
        {
            if(orderId == null)
                return NotFound();

            OrderViewModelDetail order = new OrderViewModelDetail();

            var orderFound = (await _unitOfWork.Order.Find(x =>x.OrderId == orderId)).FirstOrDefault();

            if (orderFound is null)
                return NotFound();

            order.OrderId = orderFound.OrderId;
            order.ContactName = orderFound.Customer.ContactName;
            var orderDetails = (await _unitOfWork.OrderDetail.Find(x => x.OrderId == orderId)).ToList();
            order.OrderDetails = orderDetails.Select(x => new OrderDetailViewModelShort()
                                {
                                    OrderId = x.OrderId,
                                    ProductId = x.ProductId,
                                    UnitPrice = x.UnitPrice,
                                    Quantity = x.Quantity,
                                    Discount = x.Discount,
                                    ProductName = x.Product.ProductName,
                                });

            ViewData["TotalSum"] = orderDetails.Sum(x => x.Quantity * x.UnitPrice).ToString("0.##");
            OrderViewModelContainer result = new OrderViewModelContainer();
            result.OrderView = order;
            
            result.OrderViewToUpdate = new OrderViewModelForUpdate();
            result.OrderViewToUpdate.Confirmed = false;

            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, OrderViewModelContainer entity)
        {
            var order = new Order()
            {
                OrderId = id,
                ConfirmationDate = entity.OrderViewToUpdate.ConfirmationDate,
                Confirmed = entity.OrderViewToUpdate.Confirmed,
                Comments = entity.OrderViewToUpdate.Comments
            };
            await _unitOfWork.Order.Update(order);
            if (await _unitOfWork.CompleteAsync())
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Update));

        }
    }
}
