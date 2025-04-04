namespace RogersPizza.Models;

public class Pizza {
    public int ID { get; set;}
    public List<string> Name { get; set;}
    public List<string> Size;
    public List<string> Crust;
    public List<string> CrustOptions;
    public string Sauce;
    public List<string> SauceOptions;
    public string Cheese;
    public List<string> CheeseOptions;
    public List<string> Toppings;
    public List<string> ToppingsOptions;
    public string Bake;
    public List<string> Extras;
    public decimal Price; 
}