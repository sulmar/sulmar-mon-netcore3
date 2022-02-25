namespace Domain
{
    public static class ProductExtensions
    {
        public static PriceThreshold GetPriceThreshold(this Product product)
        {
            if (product.UnitPrice < 200) return PriceThreshold.Low;
            else if (product.UnitPrice > 500) return PriceThreshold.Hight;
            else return PriceThreshold.Regular;
        }
    }

    public class Product : BaseEntity
    {        
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal UnitPrice { get; set; }
        public Size Size { get; set; }
        public bool IsRemoved { get; set; }
        public Customer Brand { get; set; }

        public Size OverSize = Size.L;
        public bool IsOverSize => Size >= OverSize;

        //public PriceThreshold PriceThreshold
        //{
        //    get
        //    {
        //        if (UnitPrice < 200) return PriceThreshold.Low;
        //        else if (UnitPrice > 500) return PriceThreshold.Hight;
        //        else return PriceThreshold.Regular;
        //    }
        //}

        // > C# 9.0
        //public PriceThreshold PriceThreshold2 => 
        //    UnitPrice switch
        //    {
        //        < 200 => PriceThreshold.Low,
        //        > 500 => PriceThreshold.Hight
        //        _ => PriceThreshold.Regular
        //    }
        

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

    public enum PriceThreshold
    {
        Low,
        Regular,
        Hight
    }
}
