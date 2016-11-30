namespace otlnal.Models
{    
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;    

    public class DbModel : DbContext
    {
        private static DbModel _dbModel;
        public static DbModel Create()
        {
            return new DbModel();
        }

        public DbModel()
            : base("name=DbModel")
        {
        }
        
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductType> ProductTypes { get; set; }
    }
    
    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        public ProductType Type { get; set; }
        [Display(Name = "Количество")]
        public int Count { get; set; }
    }
    
    public class ProductType
    {
        public int Id { get; set; }
        [Display(Name = "Тип")]
        public string Name { get; set; }
    }
}