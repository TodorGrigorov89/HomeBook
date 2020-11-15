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
            this.Entrances = new HashSet<Entrance>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.BuildingFullAddressMaxLength)]
        public string BuildingFullAddress { get; set; }

        [MaxLength(GlobalConstants.DataValidations.BuildingMaxEntrances)]
        public int NumberOfEntrances { get; set; }

        [MaxLength(GlobalConstants.DataValidations.BuildingMaxFloors)]
        public int NumberOfFloors { get; set; }

        [MaxLength(GlobalConstants.DataValidations.ApartmentMaxNumber)]
        public int NumberOfApartments { get; set; }

        public int StreetId { get; set; }

        public virtual Street Street { get; set; }

        public virtual ICollection<Entrance> Entrances { get; set; }
    }
}
