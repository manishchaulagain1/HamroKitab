using HamroKitab.Model;

namespace HamroKitab.Model
{
    public class ShoppingCartItem
    {
        public int Id { get; set; }
        public Books Book { get; set; }
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; }

    }
}
