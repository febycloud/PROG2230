using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace musicstore.Models
{

    [ModelMetadataType(typeof(OrderMetadata))]
    public partial class Order { }
    public class OrderMetadata
    {
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        [Required]
        [Display(Name = "First Name")]
        [StringLength(15,MinimumLength =3)]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "L Name")]
        public string LastName { get; set; }
    
        public string Address { get; set; }
        public string City { get; set; }
        public string ProvinceCode { get; set; }
        public string PostalCode { get; set; }

        [RegularExpression(@"^/d{3}-/d{3}-/d{4}$")]
        public string CountryCode { get; set; }
        public string Phone { get; set; }
        [EmailAddress(ErrorMessage ="{0},input real address lolo")]
        public string Email { get; set; }
        public double Total { get; set; }

        public virtual Country CountryCodeNavigation { get; set; }
        public virtual Province ProvinceCodeNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetail { get; set; }
    }
}
