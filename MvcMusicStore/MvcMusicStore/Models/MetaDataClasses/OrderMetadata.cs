using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMusicStore.Models
{
    [ModelMetadataType(typeof(OrderMetadata))]
    public partial class Order
    { }

    public class OrderMetadata
    {
        [Remote("OrderDateNotFuture","Checkout")]
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        [Required]
        [Display(Name ="F Name")]
        [StringLength(20, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "L Name")]
        [StringLength(20)]
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string ProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string CountryCode { get; set; }
        [RegularExpression(@"^/d{3}-/d{3}-/d{4}$",ErrorMessage ="Not Valid Phone Number")]
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage ="{0} should be like aaa@aa.com")]
        public string Email { get; set; }
        public double Total { get; set; }

    }
}
