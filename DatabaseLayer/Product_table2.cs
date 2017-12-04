namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_table2
    {
        public int? BrandId { get; set; }

        [StringLength(255)]
        public string BrandName { get; set; }

        public int? CategoryId { get; set; }

        [StringLength(255)]
        public string CategoryName { get; set; }

        [StringLength(255)]
        public string Product_Description { get; set; }

        [StringLength(255)]
        public string Ean { get; set; }

        public bool? ExpectedRestock { get; set; }

        [StringLength(255)]
        public string Product_Name { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public double Price { get; set; }

        public double Original_Price { get; set; }
    }
}
