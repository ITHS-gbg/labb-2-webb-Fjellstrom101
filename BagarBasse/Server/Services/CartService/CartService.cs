using BagarBasse.DataAccess;
using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using Microsoft.EntityFrameworkCore;

namespace BagarBasse.Server.Services.CartService;

public class CartService : ICartService
{
    private readonly StoreUnitOfWork _storeUnitOfWork;

    public CartService(StoreUnitOfWork storeUnitOfWork)
    {
        _storeUnitOfWork = storeUnitOfWork;
    }
    public async Task<List<CartProductDto>> GetCartProductsAsync(List<CartItem> cartItems)
    {
        var response = new List<CartProductDto>();

        foreach (var item in cartItems)
        {
            var product = await _storeUnitOfWork.ProductRepository.Get().Where(p => p.Id == item.ProductId).FirstOrDefaultAsync();

            if (product == null)
            {
                continue;
            }

            var productVariant = await _storeUnitOfWork.ProductVariantRepository.Get()
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

            response.Add(cartProduct);
        }

        return response;
    }
}