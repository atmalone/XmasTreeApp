using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using XmasTreeApplication.Common.Entities;
using XmasTreeApplication.Common.Repositories;
using XmasTreeApplication.Data;
using XmasTreeApplication.ViewModels;

namespace XmasTreeApplication.Controllers
{
    [Route("/api/orders/{orderid}/items")]
    public class OrderItemsController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<OrderItemsController> _logger;
        private readonly IMapper _mapper;

        public OrderItemsController(IOrderRepository orderRepository,
            ILogger<OrderItemsController> logger,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get(int orderId)
        {
            var order = _orderRepository.GetOrderById(orderId);
            if (order != null) return Ok(_mapper.Map<IEnumerable<OrderItem>, IEnumerable<OrderItemViewModel>>(order.Items));
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int orderId, int id)
        {
            var order = _orderRepository.GetOrderById(orderId);
            if (order == null) return NotFound();
            var item = order.Items.Where(i => i.Id == id).FirstOrDefault();
            if (item != null)
            {
                return Ok(_mapper.Map<OrderItem, OrderItemViewModel>(item));
            }
            return NotFound();

        }
    }
}