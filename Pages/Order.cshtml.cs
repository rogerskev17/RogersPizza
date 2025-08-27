using System.Threading.Tasks;
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

        public IList<Pizza>? Pizzas { get; set; }

        [BindProperty]
        public Order? Order { get; set; }
        decimal remainingBalance;

        public OrderModel(RogersPizza.Data.StoreContext context, ILogger<OrderModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            await PopulateForm();
        }

        public async Task PopulateForm()
        {
            Pizzas = await _context.Pizzas.ToListAsync();
        }

        public async Task<IActionResult> OnPost()
        {
            _logger.LogInformation(
                "Received order: Name= {Order.Name}, Pizza={Order.Pizza}, Payment={Order.PaymentOption}, GiftCard={Order.GiftCardNumber}, ID={Order.ID}", Order?.Name,
                Order?.Pizza, Order?.PaymentOption, Order?.GiftCardNumber, Order?.ID);

            bool isValidOrder = ValidateOrder();

            if (isValidOrder)
            {
                AddOrder();
                return RedirectToPage("/Confirmation", "OrderPlaced", new { cashNeeded = remainingBalance });
            }
            else
            {
                await PopulateForm();
                return Page();
            }
        }

        private bool ValidateOrder()
        {
            decimal pizzaPrice = _context.Pizzas.Where(p => p.Name == Order!.Pizza).Select(p => p.Price).Single();
            _logger.LogInformation("pizzaPrice: " + pizzaPrice);

            if (Order?.PaymentOption == "giftCard")
            {
                _logger.LogInformation("PaymentOption: giftCard");
                _logger.LogInformation("Checking DB existence of Order.GiftCardNumber: " + Order.GiftCardNumber);
                bool isValidNumber = _context.GiftCards.Any(n => n.GiftCardNumber == Order.GiftCardNumber);
                _logger.LogInformation("isValidNumber: " + isValidNumber);
                if (!isValidNumber)
                {
                    _logger.LogInformation("Gift card number not found");
                    ModelState.AddModelError("Order.GiftCardNumber", "The gift card number you have entered is invalid.");
                    return false;
                }

                _logger.LogInformation("Checking balance");
                decimal giftCardBalance = _context.GiftCards.Where(n => n.GiftCardNumber == Order.GiftCardNumber).Select(b => b.GiftCardBalance).Single();
                _logger.LogInformation("giftCardBalance: " + giftCardBalance);

                _logger.LogInformation("Checking remaining balance");
                remainingBalance = pizzaPrice - giftCardBalance;
                _logger.LogInformation("remainingBalance: " + remainingBalance);

                if (remainingBalance > 0)
                {
                    GiftCard usedUpCard = _context.GiftCards.Single(g => g.GiftCardNumber == Order.GiftCardNumber);
                    _context.GiftCards.Remove(usedUpCard);
                    _context.SaveChanges();
                }
                else
                {
                    GiftCard usedCard = _context.GiftCards.Single(g => g.GiftCardNumber == Order.GiftCardNumber);
                    usedCard.GiftCardBalance = -remainingBalance;
                    _context.SaveChanges();
                }
            }
            else if (Order?.PaymentOption == "cash")
            {
                _logger.LogInformation("PaymentOption: cash");
                remainingBalance = pizzaPrice;
            }

            return true;
        }

        private void AddOrder()
        {
            _logger.LogInformation("Adding order to Database");
            _context.Add<Order>(Order!);
            _context.SaveChanges();
        }
    }
}