namespace RogersPizza.Models;

public class Pizza {
    public required int ID { get; set; }
    public required string Name { get; set; }
    public string? Size { get; set; } 
    public List<string>? Crust { get; set; }
    public List<string>? Sauce { get; set; }
    public List<string>? Cheese { get; set; }
    public List<string>? Toppings { get; set; }
    public string? Bake { get; set; }
    public List<string>? Extras { get; set; }
    public decimal? Price { get; set; } 
}