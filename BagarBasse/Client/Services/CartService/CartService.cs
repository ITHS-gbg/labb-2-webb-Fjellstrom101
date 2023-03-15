using BagarBasse.Shared.DTOs;
using BagarBasse.Shared.Models;
using BagarBasse.Shared;
using System.Net.Http.Json;
using Blazored.LocalStorage;

namespace BagarBasse.Client.Services.CartService;

public class CartService : ICartService
{
    private readonly ILocalStorageService _localStorage;
    private readonly HttpClient _http;

    public CartService(ILocalStorageService localStorage, HttpClient http)
    {
        _localStorage = localStorage;
        _http = http;
    }

    public event Action? OnChange;

    public async Task AddToCart(CartItem cartItem)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            cart = new List<CartItem>();
        }

        var sameItem = cart.Find(c => c.ProductId == cartItem.ProductId && c.ProductTypeId == cartItem.ProductTypeId);
        if (sameItem == null)
        {
            cart.Add(cartItem);
        }
        else
        {
            sameItem.Quantity += cartItem.Quantity;
        }


        await _localStorage.SetItemAsync("cart", cart);
        OnChange.Invoke();
    }

    public async Task<List<CartItem>> GetCartItemsAsync()
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            cart = new List<CartItem>();
        }

        return cart;
    }

    public async Task<List<CartProductDto>> GetCartProductsAsync()
    {
        var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        var response = await _http.PostAsJsonAsync("api/cart/products", cartItems);
        var cartProducs = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductDto>>>();
        return cartProducs.Data;
    }

    public async Task RemoveProductFromCart(int productId, int productTypeId)
    {
        var cartItems = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cartItems == null)
        {
            return;
        }

        var cartItem = cartItems.Find(p => p.ProductId == productId && p.ProductTypeId == productTypeId);

        if (cartItem != null)
        {
            cartItems.Remove(cartItem);
            await _localStorage.SetItemAsync("cart", cartItems);
            OnChange.Invoke();
        }

    }

    public async Task UpdateQuantity(CartProductDto product)
    {
        var cart = await _localStorage.GetItemAsync<List<CartItem>>("cart");
        if (cart == null)
        {
            return;
        }
        var cartItem = cart.Find(p => p.ProductId == product.ProductId
                                      && p.ProductTypeId == product.ProductTypeId);

        if (cartItem != null)
        {
            cartItem.Quantity = product.Quantity;
            await _localStorage.SetItemAsync("cart", cart);
        }
    }
}