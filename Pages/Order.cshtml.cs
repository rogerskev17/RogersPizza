using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RogersPizza.Models;

namespace RogersPizza.Pages
{
    [ValidateAntiForgeryToken]
    public class OrderModel : PageModel
    {
        private readonly RogersPizza.Data.StoreContext _context;
        private readonly ILogger<OrderModel> _logger;
        [BindProperty] public Order? Order { get; set; }

        public OrderModel(RogersPizza.Data.StoreContext context, ILogger<OrderModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IList<Pizza>? Pizzas { get; set; }
        public async Task OnGetAsync()
        {
            Pizzas = await _context.Pizzas.ToListAsync();
        }

        public IActionResult OnPost()
        {
            _logger.LogInformation(
                "Received order: Pizza={Order.Pizza}, Payment={Order.PaymentOption}, GiftCard={Order.GiftCardNumber}, ID={Order.ID}",
                Order.Pizza, Order.PaymentOption, Order.GiftCardNumber, Order.ID);
            return RedirectToPage("/Index");
        }

        // private bool ValidateOrder(Order order)
        // {
        //     return false;
        // }
    }
}