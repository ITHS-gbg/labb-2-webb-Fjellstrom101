using System.Security.Claims;
using System.Xml;
using BagarBasse.DataAccess;
using BagarBasse.Server.Services.CartService;
using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using Microsoft.EntityFrameworkCore;
using BagarBasse.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;

namespace BagarBasse.Server.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly DataContext _context;
    private readonly ICartService _cartService;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public OrderService(DataContext context, ICartService cartService, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _cartService = cartService;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task<ServiceResponse<bool>> PlaceOrder(List<CartItem> cartItems)
    {

        Console.WriteLine();

        var products = (await _cartService.GetCartProductsAsync(cartItems)).Data;
        decimal totalPrice = 0;
        products.ForEach(p => totalPrice += p.Price * p.Quantity);

        var orderItems = new List<OrderItem>();
        products.ForEach(p => orderItems.Add(new OrderItem
        {
            ProductId = p.ProductId,
            ProductTypeId = p.ProductTypeId,
            Quantity = p.Quantity,
            TotalPrice = p.Price * p.Quantity
        }));

        var order = new Order
        {
            UserId = GetUserId(),
            TotalPrice = totalPrice,
            OrderItems = orderItems
        };
        _context.Orders.Add(order);

        await _context.SaveChangesAsync();

        return new ServiceResponse<bool>
        {
            Data = true
        };
    }

    public async Task<ServiceResponse<List<OrderOverviewDto>>> GetOrders()
    {
        var response = new ServiceResponse<List<OrderOverviewDto>>();

        var orders = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Where(o => o.UserId == GetUserId())
            .OrderByDescending(o => o.OrderDate)
            .ToListAsync();

        var orderResponse = new List<OrderOverviewDto>();

        orders.ForEach(o => orderResponse.Add(new OrderOverviewDto
        {
            Id = o.Id,
            OrderDate = o.OrderDate,
            TotalPrice = o.TotalPrice,
            Product = o.OrderItems.Count > 1 ?
                $"{o.OrderItems.First().Product.Title} och " +
                $"{o.OrderItems.Count - 1} andra produkter..." :
                o.OrderItems.First().Product.Title,
            ProductImageUrl = o.OrderItems.First().Product.Image
        }));
        response.Data = orderResponse;

        return response;
    }

    public async Task<ServiceResponse<OrderDetailsDto>> GetOrderDetails(int orderId)
    {
        var response = new ServiceResponse<OrderDetailsDto>();
        var order = await _context.Orders
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.ProductType)
            .Where(o => o.UserId == GetUserId() && o.Id == orderId)
            .OrderByDescending(o => o.OrderDate)
            .FirstOrDefaultAsync();

        if (order == null)
        {
            response.Success = false;
            response.Message = "Ordern hittades inte";
            return response;
        }

        var orderDetailsDto = new OrderDetailsDto
        {
            OrderDate = order.OrderDate,
            TotalPrice = order.TotalPrice,
            Products = new List<OrderDetailsProductDto>()
        };

        order.OrderItems.ForEach(o => orderDetailsDto.Products.Add(new OrderDetailsProductDto
        {
            ProductId = o.ProductId,
            ImageUrl = o.Product.Image,
            ProductType = o.ProductType.Name,
            Quantity = o.Quantity,
            Title = o.Product.Title,
            TotalPrice = o.TotalPrice
        }));

        response.Data = orderDetailsDto;

        return response;
    }
    private Guid GetUserId() => Guid.Parse(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

}