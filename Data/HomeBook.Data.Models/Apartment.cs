namespace HomeBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;
    using HomeBook.Data.Common.Models;

    public class Apartment : BaseDeletableModel<int>
    {
        public Apartment()
        {
            this.ApartmentUsers = new HashSet<UserApartment>();
            this.Payments = new HashSet<Payment>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.ApartmentNumberMaxLengh)]
        public string ApartmentNumber { get; set; }

        [MaxLength(GlobalConstants.DataValidations.BuildingMaxFloors)]
        public int Floor { get; set; }

        [MaxLength(GlobalConstants.DataValidations.ApartmentResidentsMaxNumber)]
        public int NumberOfResidents { get; set; }

        public decimal Area { get; set; }

        public int BuildingId { get; set; }

        public virtual Building Building { get; set; }

        public virtual ICollection<UserApartment> ApartmentUsers { get; set; }

        public virtual ICollection<Payment> Payments { get; set; }
    }
}
