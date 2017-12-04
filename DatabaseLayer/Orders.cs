namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    public class Orders
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderID { get; set; }

        [StringLength(255)]
        public string product_Name { get; set; }

        public int prodID { get; set; }

        public double price { get; set; }

        public int  qty { get; set; }
        
    }
}