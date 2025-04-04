using RogersPizza.Models;


namespace RogersPizza.Data
{
    public static class DbInitializer
    {
        public static void Initialize(StoreContext context)
        {
            context.Database.EnsureCreated();

            if (context.Pizzas.Any())
            {
                return;
            }

            var Pizzas = new Pizza[]
            {
                new Pizza{},
                new Pizza{}
            };
        }
    }
}