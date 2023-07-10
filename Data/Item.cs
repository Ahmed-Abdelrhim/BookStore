namespace Core1.Data
{
    public class Item
    {

        public int ProductId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }
        public DateTime CreatedAT { get; set; } = DateTime.Now;

        public int CategotyId { get; set; }

        // public CategoryModel? Category { get; set; }
    }
}
