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
                //To Do: Add Order to Database
                AddOrder();
                return RedirectToPage("/Index");
            }
            else
            {
                await PopulateForm();
                return Page();
            }
        }

        private bool ValidateOrder()
        {
            if (Order?.PaymentOption == "giftCard")
            {
                _logger.LogInformation("Checking DB existence of Order.GiftCardNumber: " + Order.GiftCardNumber);
                bool isValidNumber = _context.GiftCards.Any(n => n.GiftCardNumber == Order.GiftCardNumber);
                _logger.LogInformation("isValidNumber: " + isValidNumber);
                if (!isValidNumber)
                {
                    _logger.LogInformation("Gift card number not found");
                    return false;
                }

                _logger.LogInformation("Checking balance");
                decimal giftCardbalance = _context.GiftCards.Where(n => n.GiftCardNumber == Order.GiftCardNumber).Select(b => b.GiftCardBalance).Single();
                _logger.LogInformation("balance: " + giftCardbalance);
                decimal pizzaPrice = _context.Pizzas.Where(p => p.Name == Order.Pizza).Select(p => p.Price).Single();
                _logger.LogInformation("pizzaPrice: " + pizzaPrice);

                _logger.LogInformation("Checking remaining balance");
                decimal remainingBalance = pizzaPrice - giftCardbalance;
                _logger.LogInformation("remainingBalance: " + remainingBalance);

                // bool isCashNeeded = false;
                if (remainingBalance > 0)
                {
                    // isCashNeeded = true;
                    GiftCard usedUpCard = _context.GiftCards.Single(g => g.GiftCardNumber == Order.GiftCardNumber);
                    _context.GiftCards.Remove(usedUpCard);
                    _context.SaveChanges();

                    //To Do: Inform customer of remaining balance they have to pay in cash
                }
                else
                {
                    GiftCard usedCard = _context.GiftCards.Single(g => g.GiftCardNumber == Order.GiftCardNumber);
                    usedCard.GiftCardBalance = -remainingBalance;
                    _context.SaveChanges();
                }
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