using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;

namespace BagarBasse.Server.Services.CartService;

public interface ICartService
{
    Task<IResult> GetCartProductsAsync(List<CartItem> cartItems);
    Task<List<CartProductDto>> GetCartProductsAsListAsync(List<CartItem> cartItems);
}