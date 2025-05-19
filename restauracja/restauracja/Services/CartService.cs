using restauracja.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using System.Linq;

public class CartService
{
    private readonly ProtectedSessionStorage _sessionStorage;
    private const string CartKey = "cart";
    public List<Dish> Cart { get; private set; } = new();

    public event Action? OnChange;

    public decimal TotalPrice => Cart.Sum(item => item.Price);
    public int TotalItemsCount => Cart.Count;

    public CartService(ProtectedSessionStorage sessionStorage)
    {
        _sessionStorage = sessionStorage;
        _ = LoadCart();
    }

    public async Task AddToCart(Dish dish, int quantity)
    {
        for (int i = 0; i < quantity; i++)
        {
            // Tworzymy nowy obiekt Dish, aby unikn¹æ problemów z referencjami,
            // jeœli oryginalny obiekt Dish pochodzi np. z Entity Framework Context.
            Cart.Add(new Dish { DishId = dish.DishId, Name = dish.Name, Price = dish.Price });
        }
        await SaveCart();
        OnChange?.Invoke();
    }

    // Usuwa jedno wyst¹pienie dania o podanym ID
    public async Task RemoveOneItem(int dishId)
    {
        var itemToRemove = Cart.FirstOrDefault(d => d.DishId == dishId);
        if (itemToRemove != null)
        {
            Cart.Remove(itemToRemove);
            await SaveCart();
            OnChange?.Invoke();
        }
    }

    // Usuwa wszystkie wyst¹pienia dania o podanym ID
    public async Task RemoveAllInstancesOfItem(int dishId)
    {
        int itemsRemoved = Cart.RemoveAll(d => d.DishId == dishId);
        if (itemsRemoved > 0)
        {
            await SaveCart();
            OnChange?.Invoke();
        }
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
        Cart = result.Success && result.Value != null ? result.Value : new List<Dish>();
        OnChange?.Invoke(); // Wa¿ne, aby UI zaktualizowa³o siê po za³adowaniu koszyka
    }

    public async Task SaveCart()
    {
        await _sessionStorage.SetAsync(CartKey, Cart);
    }

    // Zwraca zgrupowane pozycje koszyka (Danie, Iloœæ, Suma dla grupy)
    public IEnumerable<CartItemGroup> GetGroupedCartItems()
    {
        return Cart.GroupBy(dish => dish.DishId)
                   .Select(group => new CartItemGroup
                   {
                       // Zak³adamy, ¿e wszystkie dania o tym samym DishId maj¹ tê sam¹ nazwê i cenê
                       DishItem = group.First(), 
                       Quantity = group.Count(),
                       GroupTotalPrice = group.Sum(d => d.Price)
                   });
    }
}

// Pomocnicza klasa do reprezentowania zgrupowanych pozycji w koszyku
public class CartItemGroup
{
    public Dish DishItem { get; set; }
    public int Quantity { get; set; }
    public decimal GroupTotalPrice { get; set; }
}