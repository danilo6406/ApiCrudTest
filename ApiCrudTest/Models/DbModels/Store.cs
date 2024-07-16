using System.ComponentModel.DataAnnotations;

namespace ApiCrudTest.Models.DbModels
{
    public class Store
    { 
        [Key]
        public int StoreID { get; set; }
        public string StoreName { get; set; }

        public ICollection<StoreProductMapping>? StoreProductMappings { get; set; }
    }
}
