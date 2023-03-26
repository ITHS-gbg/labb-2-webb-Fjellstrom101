using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;

namespace BagarBasse.Client.Services.CartService;

public interface ICartService
{
    event Action OnChange;
    Task AddToCart(CartItem cartItem);
    Task<List<CartItem>> GetCartItemsAsync();
    Task<List<CartProductDto>> GetCartProductsAsync();
    Task RemoveProductFromCart(int productId, int productTypeId);
    Task UpdateQuantity(CartProductDto product);

    Task ClearCart();

}