using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RogersPizza.Pages
{
    public class ConfirmationModel : PageModel
    {
        private readonly ILogger<ConfirmationModel> _logger;
        public decimal cashToBring;

        public ConfirmationModel(ILogger<ConfirmationModel> logger)
        {
            _logger = logger;
        }

        public void OnGetOrderPlaced(decimal cashNeeded)
        {
            cashToBring = cashNeeded;
            _logger.LogInformation("cashToBring: " + cashToBring);
        }
    }
}