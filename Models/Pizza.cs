namespace RogersPizza.Models;

public class Pizza {
    public int ID { get; set;}
    public string Name { get; set;}
    public string Size;
    public List<string> Crust;
    public List<string> Sauce;
    public List<string> Cheese;
    public List<string> Toppings;
    public string Bake;
    public List<string> Extras;
    public decimal Price; 
}