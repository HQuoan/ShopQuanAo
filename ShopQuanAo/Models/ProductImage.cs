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
    
    public partial class ProductImage
    {
        public int ImageID { get; set; }
        public int ProductID { get; set; }
        public string Image { get; set; }
        public bool isDefault { get; set; }
    
        public virtual Product Product { get; set; }
    }
}
