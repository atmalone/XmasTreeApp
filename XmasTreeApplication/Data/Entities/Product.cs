namespace XmasTreeApplication.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string TreeSize { get; set; }
        public decimal Price { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
    }
}