using restauracja.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

public class CartService
{
    private readonly ProtectedSessionStorage _sessionStorage;
    private const string CartKey = "cart";
    public List<Dish> Cart { get; private set; } = new();

    public event Action? OnChange;

    public CartService(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
        _ = LoadCart();
    }

    public async Task AddToCart(Dish dish, int quantity)
    {
        for (int i = 0; i < quantity; i++)
            Cart.Add(new Dish { DishId = dish.DishId, Name = dish.Name, Price = dish.Price });
        await SaveCart();
        OnChange?.Invoke();
    }

    public async Task ClearCart()
    {
        Cart.Clear();
        await SaveCart();
        OnChange?.Invoke();
    }

    public async Task LoadCart()
    {
        var result = await _sessionStorage.GetAsync<List<Dish>>(CartKey);
        if (result.Success && result.Value is not null)
            Cart = result.Value;
        else
            Cart = new List<Dish>();
        OnChange?.Invoke();
    }

    public async Task SaveCart()
    {
        await _sessionStorage.SetAsync(CartKey, Cart);
    }
}