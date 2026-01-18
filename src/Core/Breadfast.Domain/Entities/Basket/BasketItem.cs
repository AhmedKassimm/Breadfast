using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Breadfast.Domain.Entities.Basket
{
    public class BasketItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; } =default!;
        public string PictureUrl { get; set; } =default!;
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string Brand { get; set; } = default!;
        public string Category { get; set; } = default!;    

    }
}