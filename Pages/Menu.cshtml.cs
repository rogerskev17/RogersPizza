using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RogersPizza.Data;
using RogersPizza.Models;

namespace RogersPizza.Pages
{
    public class MenuModel : PageModel
    {
        private readonly RogersPizza.Data.StoreContext _context;

        public MenuModel(RogersPizza.Data.StoreContext context)
        {
            _context = context;
        }

        public IList<Pizza> Pizzas { get; set; }
        public async Task OnGetAsync()
        {
            Pizzas = await _context.Pizzas.ToListAsync();
        }
    }
}