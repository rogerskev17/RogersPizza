using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RogersPizza.Models;

namespace RogersPizza.Pages
{
    public class OrderModel : PageModel
    {
        private readonly RogersPizza.Data.StoreContext _context;

        public OrderModel(RogersPizza.Data.StoreContext context)
        {
            _context = context;
        }

        public IList<Pizza>? Pizzas { get; set; }
        public async Task OnGetAsync()
        {
            Pizzas = await _context.Pizzas.ToListAsync();
        }

    }
}