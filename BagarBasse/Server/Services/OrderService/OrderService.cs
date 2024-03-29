﻿using BagarBasse.OrderDataAccess.UnitOfWork;
using BagarBasse.Server.Services.CartService;
using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;
using Microsoft.EntityFrameworkCore;
using BagarBasse.Server.Services.AuthService;
using BagarBasse.Shared.DTOs.OrderDTOs;

namespace BagarBasse.Server.Services.OrderService;

public class OrderService : IOrderService
{
    private readonly StoreUnitOfWork _storeUnitOfWork;
    private readonly OrderUnitOfWork _orderUnitOfWork;
    private readonly ICartService _cartService;
    private readonly IAuthService _authService;

    public OrderService(StoreUnitOfWork storeUnitOfWork, OrderUnitOfWork orderUnitOfWork, ICartService cartService, IAuthService authService)
    {
        _storeUnitOfWork = storeUnitOfWork;
        _orderUnitOfWork = orderUnitOfWork;
        _cartService = cartService;
        _authService = authService;
    }

    public async Task<IResult> PlaceOrderAsync(List<CartItem> cartItems)
    {
        if(cartItems == null || cartItems.Count==0)
            return TypedResults.UnprocessableEntity("Cart is null or empty.");

        var products = (await _cartService.GetCartProductsAsListAsync(cartItems));
        var orderItems = new List<OrderItemDto>();

        foreach (var product in products)
        {
            var variant = await _storeUnitOfWork.ProductVariantRepository.Get()
                .Where(pv => pv.ProductId == product.ProductId && pv.ProductTypeId == product.ProductTypeId)
                .Include(pv => pv.ProductType)
                .FirstOrDefaultAsync();

            orderItems.Add(new OrderItemDto
            {
                Id = product.ProductId,
                Title = product.Title,
                Image = product.ImageUrl,
                Quantity = product.Quantity,
                ProductVariant = variant.ProductType.Name,
                OriginalPrice = variant.OriginalPrice,
                Price = variant.Price
            });
        }

        var user = await _storeUnitOfWork.UserRepository
            .Get(u => u.Id == _authService.GetUserId())
            .Include(u => u.UserInfo)
            .FirstOrDefaultAsync();

        _orderUnitOfWork.OrderRepository.Add(new OrderDto
        {
            UserId = user.Id,
            OrderItems = orderItems,
            TotalPrice = products.Sum(p => (p.Price * p.Quantity)),
            User = new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                DateCreated = user.DateCreated,
                Role = string.Empty,
                UserInfo = user.UserInfo
            }
        });

        await _orderUnitOfWork.SaveChangesAsync();

        return TypedResults.Ok("Order has been created");
    }

    public async Task<IResult> GetOrdersAsync()
    {
        var userId = _authService.GetUserId();
        var orderList = (await _orderUnitOfWork.OrderRepository.GetAll())
            .Where(o => o.UserId == userId)
            .OrderByDescending(o => o.OrderDate)
            .ToList();

        if (orderList == null || !orderList.Any())
            return TypedResults.NoContent();

        var overviewList = orderList.Select(order => new OrderOverviewDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Product = order.OrderItems.Count > 1
                    ? $"{order.OrderItems.First().Title} och " + $"{order.OrderItems.Count - 1} andra produkter..."
                    : order.OrderItems.First().Title,
                ProductImageUrl = order.OrderItems.First().Image
            })
            .ToList();

        return TypedResults.Ok(overviewList);
    }

    public async Task<IResult> GetOrderDetailsAsync(string orderId)
    {
        var orderIdGuid = Guid.Parse(orderId);
        var order = (await _orderUnitOfWork.OrderRepository.GetAll())
            .Where( o => o.User.Id == _authService.GetUserId() && o.Id.Equals(orderIdGuid))
            .FirstOrDefault();

        if (order == null)
        {
            return TypedResults.UnprocessableEntity("Order not found.");
        }


        return TypedResults.Ok(order);

    }

    public async Task<IResult> GetAdminOrdersAsync()
    {
        var orderList = (await _orderUnitOfWork.OrderRepository.GetAll())
            .OrderByDescending(o => o.OrderDate);

        var orderResponse = orderList.Select(order => new OrderOverviewDto
            {
                Id = order.Id,
                OrderDate = order.OrderDate,
                TotalPrice = order.TotalPrice,
                Product = order.OrderItems.Count > 1
                    ? $"{order.OrderItems.First().Title} och " + $"{order.OrderItems.Count - 1} andra produkter..."
                    : order.OrderItems.First().Title,
                ProductImageUrl = order.OrderItems.First().Image
            })
            .ToList();

        if (orderResponse.Count > 0)
            return TypedResults.Ok(orderResponse);

        return TypedResults.NoContent();
    }


}