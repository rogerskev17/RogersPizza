using RogersPizza.Models;

namespace RogersPizza.Data
{
    public class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pizzas.Any())
            {
                return;
            }

            var pizzas = new Pizza[]
            {
                new Pizza{ID = 1, Name = "Hand Tossed Pepperoni", Size = "Large", Crust = ["Hand Tossed", "Garlic"], Sauce = ["Tomato", "All"], Cheese = ["Mozzarella", "All"], Toppings = ["Pepperoni", "Whole"], Bake = "Normal", Price = 10.99m},
                new Pizza{ID = 2, Name = "Vegetable Supreme", Size = "Large", Crust = ["Hand Tossed", "Garlic"], Sauce = ["Tomato", "All"], Cheese = ["Mozzarella", "All"], Toppings = ["Black Olives", "Green Bell Peppers", "Mushrooms", "Spinach"], Bake = "Normal", Price = 12.99m}
            };

            var giftCards = new GiftCard[]
            {
                new GiftCard {ID = 1, GiftCardNumber = "1111222233334444", GiftCardBalance = 15},
                new GiftCard {ID = 2, GiftCardNumber = "4444333322221111", GiftCardBalance = 5}
            };

            context.Pizzas.AddRange(pizzas);
            context.SaveChanges();
        }
    }
}