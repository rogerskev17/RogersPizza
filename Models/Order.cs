using System.ComponentModel.DataAnnotations;

namespace RogersPizza.Models
{
    public class Order
    {
        [Key]
        public int? ID { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Pizza { get; set; }

        [Required]
        public required string PaymentOption { get; set; }

        public string? GiftCardNumber { get; set; }
    }
}