﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SwaggerWebAPIApp.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        [ForeignKey("Product")]
        public int ProdutctId { get; set; }
        public Product Produtct { get; set; }
        [ForeignKey("RawMaterial")]
        public int RawId { get; set; }
        public RawMaterial RawMaterial { get; set; }
        public int StockNumber { get; set; }
    }
}
