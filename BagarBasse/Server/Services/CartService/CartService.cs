using BagarBasse.DataAccess;
using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.Server.Services.CartService;

public class CartService : ICartService
{
    private readonly DataContext _context;

    public CartService(DataContext context)
    {
        _context = context;
    }
    public async Task<ServiceResponse<List<CartProductDto>>> GetCartProductsAsync(List<CartItem> cartItems)
    {
        var response = new ServiceResponse<List<CartProductDto>>
        {
            Data = new List<CartProductDto>()
        };
        foreach (var item in cartItems)
        {
            var product = await _context.Products.Where(p => p.Id == item.ProductId).FirstOrDefaultAsync();
            if (product == null)
            {
                continue;
            }

            var productVariant = await _context.ProductVariants
                .Where(v => v.ProductId == item.ProductId && v.ProductTypeId == item.ProductTypeId)
                .Include(v => v.ProductType)
                .FirstOrDefaultAsync();
            if (productVariant == null)
            {
                continue;
            }

            var cartProduct = new CartProductDto
            {
                ProductId = product.Id,
                Title = product.Title,
                ImageUrl = product.Image,
                Price = productVariant.Price,
                ProductTypeId = productVariant.ProductTypeId,
                ProductType = productVariant.ProductType.Name,
                Quantity = item.Quantity,
            };
            response.Data.Add(cartProduct);
        }
        return response;
    }
}