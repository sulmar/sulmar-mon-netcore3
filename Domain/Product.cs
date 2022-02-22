namespace Domain
{
    public class Product : BaseEntity
    {        
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public Size Size { get; set; }
        public bool IsRemoved { get; set; }

        public Product()
        {
            Size = Size.L;
        }
    }

    public enum Size
    {
        S,
        M,
        L,
        XL
    }
}
