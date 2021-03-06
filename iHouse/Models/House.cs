//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iHouse.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class House
    {
        public int HouseId { get; set; }

        [Required(ErrorMessage = "Please input your user ID")]
        public int SellerId { get; set; }

        [Required(ErrorMessage = "Please input Region")]
        public string Region { get; set; }

        [Required(ErrorMessage = "Please input Suburb")]
        public string Suburb { get; set; }

        [Required(ErrorMessage = "Please input Location")]
        public string Location { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.##}")]
        [Required(ErrorMessage = "Please input the number of rooms")]
        public int Room { get; set; }

        [Required(ErrorMessage = "Please input the property type")]
        public string Type { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.##}")]
        [DisplayName("Floor Area (m?)")]
        [Required(ErrorMessage = "Please input the Floor area")]
        public decimal FloorArea { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.##}")]
        [DisplayName("Land Area (m?)")]
        [Required(ErrorMessage = "Please input the Lanf area")]
        public decimal LandArea { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.##}")]
        [DisplayName("RV ($)")]
        [Required(ErrorMessage = "Please input the RV")]
        public decimal RV { get; set; }

        [Required(ErrorMessage = "Please input a contact email")]
        [RegularExpression(@"^[A-Za-z0-9]+@[A-Za-z0-9]+(\.)+[A-Za-z0-9]{2,10}$", ErrorMessage = "Email is not valid")]
        public string Email { get; set; }

        public virtual Seller Seller { get; set; }
    }
}
