using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Sail.Models
{
    [ModelMetadataType(typeof(FYMetaData))]
    public partial class Member: IValidatableObject
    {
        SailContext _context = new SailContext();


        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {


            if (FirstName.Trim().Length==0)
            {
                yield return new ValidationResult("FirstName cannot be empty or blank ", new[] { "FirstName" });
            }
            if (LastName.Trim().Length == 0)
            {
                yield return new ValidationResult("FirstName cannot be empty or blank ", new[] { "LastName" });
            }

            if (UseCanadaPost == true)
            {
                if (string.IsNullOrEmpty(Street))
                {
                    yield return new ValidationResult("Street is Required ", new[] { "Street" });
                }
                if (string.IsNullOrEmpty(City))
                {
                    yield return new ValidationResult("City is Required ", new[] { "City" });
                }
                Street = Street.Trim();
                City = City.Trim();

            }
            if (UseCanadaPost == false)
            {
                if (string.IsNullOrEmpty(Email))
                {
                    yield return new ValidationResult("Email is Required ", new[] { "Email" });
                }
                else
                {
                    Email = Email.Trim();
                }
            }






            // MemberId = _context.Member.Max(a => a.MemberId) + 1;
            //var memberid = _context.Member.Where(a => a.MemberId == MemberId).FirstOrDefault();
            //if (memberid != null)
            //{
            //    yield return new ValidationResult("Member is already on file", new[] { "MemberId" });
            //}
            ProvinceCode = ProvinceCode.Trim();
            ProvinceCode = ProvinceCode.ToUpper();
            if (ProvinceCode.Length != 2)
            {
                yield return new ValidationResult("ProvinceCode length is not match ", new[] { "ProvinceCode" });
            }
            var province = _context.Member.Where(a => a.ProvinceCode == ProvinceCode).FirstOrDefault();
            if(province==null)
            {
                yield return new ValidationResult("ProvinceCode is not match ", new[] { "ProvinceCode" });
            }
            if (!string.IsNullOrEmpty(PostalCode))
            {
                PostalCode = PostalCode.ToUpper().Trim();
                Regex PostalValidation = new Regex(@"^(?!.*[DFIOQU])[A-VXY][0-9][A-Z][0-9][A-Z][0-9]$");
                if (!PostalValidation.IsMatch(PostalCode))
                {
                    yield return new ValidationResult("PostalCode is not match ", new[] { "PostalCode" });
                }
                else
                {
                    PostalCode = PostalCode.Insert(3, " ");
                }
            }
            if (!string.IsNullOrEmpty(HomePhone))
            {
                HomePhone = HomePhone.Trim();
                Regex PhoneValidation = new Regex(@"^\(?[0-9]{3}(\-|\)) ?[0-9]{3}-[0-9]{4}$");

              
                if (HomePhone.Length != 10&& !PhoneValidation.IsMatch(HomePhone))
                {
                    yield return new ValidationResult("Home Phone should only be 10 digits", new[] { "HomePhone" });
                }
                else
                {
                    HomePhone = HomePhone.Insert(3, "-");
                    HomePhone = HomePhone.Insert(7, "-");
                }
           }

            if (!string.IsNullOrEmpty(SpouseFirstName))
            {
                if (!string.IsNullOrEmpty(SpouseLastName))
                {
                    SpouseFirstName = SpouseFirstName.Trim();
                    SpouseLastName = SpouseLastName.Trim();
                    FullName = LastName + ", " + FirstName + "&" + SpouseLastName + ", " + SpouseFirstName;
                }
                else
                {
                    FullName = LastName + ", " + FirstName + "&" + SpouseFirstName ;
                }
            }
            else
            {
                FirstName = FirstName.Trim();
                LastName = LastName.Trim();             
                FullName = LastName + ", " + FirstName;
            }

           




        }


    }
    public class FYMetaData
    {
        public int MemberId { get; set; }
        
        public string FullName { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string SpouseFirstName { get; set; }
        public string SpouseLastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        [Required]
        public string ProvinceCode { get; set; }
        public string PostalCode { get; set; }
        public string HomePhone { get; set; }
        public string Email { get; set; }
        public int? YearJoined { get; set; }
        public string Comment { get; set; }
        public bool TaskExempt { get; set; }
        public bool UseCanadaPost { get; set; }
    }
}
