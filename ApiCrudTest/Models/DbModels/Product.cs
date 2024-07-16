using System.ComponentModel.DataAnnotations;

namespace ApiCrudTest.Models.DbModels
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }

        public ICollection<StoreProductMapping>? StoreProductMappings { get; set; }
    }
}
