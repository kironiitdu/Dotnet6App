using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace SwaggerWebAPIApp.Models
{
    public partial class Product
    {

        [Key]
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string ProductName { get; set; } = null!;

        public int? SupplierId { get; set; }

        public int? CategoryId { get; set; }
        [DisplayName("Quantity Per Unit")]
        public string? QuantityPerUnit { get; set; }
        [DataType(DataType.Currency)]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public virtual Categories? Category { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails
        {
            get;
        } = new List<OrderDetail>();

        public virtual Suppliers? Supplier { get; set; }
    }
}
