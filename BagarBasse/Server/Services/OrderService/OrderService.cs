using System.Security.Claims;
using System.Xml;
using BagarBasse.DataAccess;
using BagarBasse.Server.Services.CartService;
using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using Microsoft.EntityFrameworkCore;
using BagarBasse.Server.Models;
using BagarBasse.Server.Services.AuthService;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Components.Authorization;

namespace BagarBasse.Server.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly StoreUnitOfWork _storeUnitOfWork;
    private readonly ICartService _cartService;
    private readonly IAuthService _authService;

    public OrderService(StoreUnitOfWork storeUnitOfWork, ICartService cartService, IAuthService authService)
    {
        _storeUnitOfWork = storeUnitOfWork;
        _cartService = cartService;
        _authService = authService;
    }

    public async Task<bool> PlaceOrderAsync(List<CartItem> cartItems)
    {
        if(cartItems == null || cartItems.Count==0)
            return false;

        var products = (await _cartService.GetCartProductsAsync(cartItems));
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
            UserId = _authService.GetUserId(),
            TotalPrice = totalPrice,
            OrderItems = orderItems
        };
        await _storeUnitOfWork.OrderRepository.InsertAsync(order);

        await _storeUnitOfWork.SaveChangesAsync();

        return true;
    }

    public async Task<List<OrderOverviewDto>> GetOrdersAsync()
    {

        var orders = await _storeUnitOfWork.OrderRepository.Get()
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Where(o => o.UserId == _authService.GetUserId())
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
        return orderResponse;
    }

    public async Task<OrderDetailsDto> GetOrderDetailsAsync(int orderId)
    {
        var order = await _storeUnitOfWork.OrderRepository.Get()
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.ProductType)
            .Where(o => o.UserId == _authService.GetUserId() && o.Id == orderId)
            .OrderByDescending(o => o.OrderDate)
            .FirstOrDefaultAsync();

        if (order == null)
        {
            return null;
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

        return orderDetailsDto;
    }

    public async Task<List<OrderOverviewDto>> GetAdminOrdersAsync()
    {

        var orders = await _storeUnitOfWork.OrderRepository.Get()
            .Include(o => o.OrderItems)
            .ThenInclude(oi => oi.Product)
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
        return orderResponse;
    }


}