using System.ComponentModel.DataAnnotations;

namespace RogersPizza.Models
{
    public class GiftCard
    {
        [Key]
        public required int ID { get; set; }
        public required string GiftCardNumber { get; set; }
        public required decimal GiftCardBalance { get; set; }
    }
}