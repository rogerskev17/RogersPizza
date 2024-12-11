namespace RogersPizza.Models;

public class Pizza {
    public int Id { get; set;}
    public string? Name { get; set;}
    public string? Size;
    public string? Crust;
    public string[]? CrustOptions;
    public string? Sauce;
    public string[]? SauceOptions;
    public string? Cheese;
    public string[]? CheeseOptions;
    public string[]? Toppings;
    public string[]? ToppingsOptions;
    public string? Bake;
    public decimal Price; 
}