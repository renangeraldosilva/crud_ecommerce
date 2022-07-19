namespace ECommerceSite.API.Models
{
    public class Product
    {
        public Product( string descripition, decimal price)
        {
            Descripition = descripition;
            Price = price;
        }

        public int Id { get; set; }
        public string Descripition { get; set; }
        public decimal Price { get; set; }
    }
}
