using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiCrudTest.Models.DbModels
{
    public class StoreProductMapping
    {
        [Key]
        public int MappingID { get; set; }

        [ForeignKey("Store")]
        public int StoreID { get; set; }
        public Store Store { get; set; }

        [ForeignKey("Product")]
        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int Stock { get; set; }
    }
}
