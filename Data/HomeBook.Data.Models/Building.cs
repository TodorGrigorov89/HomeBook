namespace HomeBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;
    using HomeBook.Data.Common.Models;

    public class Building : BaseDeletableModel<int>
    {
        public Building()
        {
            this.Apartments = new HashSet<Apartment>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.EntranceNumberMaxLength)]
        public string EntranceSign { get; set; }

        [MaxLength(GlobalConstants.DataValidations.BuildingMaxEntrances)]
        public int NumberOfEntrances { get; set; }

        [MaxLength(GlobalConstants.DataValidations.BuildingMaxFloors)]
        public int NumberOfFloors { get; set; }

        public int StreetId { get; set; }

        public virtual Street Street { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
