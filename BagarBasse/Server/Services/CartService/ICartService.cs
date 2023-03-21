using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;
using BagarBasse.Shared;

namespace BagarBasse.Server.Services.CartService;

public interface ICartService
{
    Task<List<CartProductDto>> GetCartProductsAsync(List<CartItem> cartItems);
}