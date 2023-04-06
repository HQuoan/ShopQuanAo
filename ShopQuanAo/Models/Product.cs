//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShopQuanAo.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Status = true;
            this.Comments = new HashSet<Comment>();
            this.Feedbacks = new HashSet<Feedback>();
            this.OrderDetails = new HashSet<OrderDetail>();
            this.Warehouses = new HashSet<Warehouse>();
            this.ProductImages = new HashSet<ProductImage>();
        }
    
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public Nullable<double> PromotionPrice { get; set; }
        public string ListImages { get; set; }
        public string Video { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public Nullable<int> ViewCount { get; set; }
        public int CatID { get; set; }
        public System.DateTime CreateDate { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public bool isSale { get; set; }
        public bool isHot { get; set; }
        public string Title { get; set; }
    
        public virtual Category Category { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Comment> Comments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Warehouse> Warehouses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}