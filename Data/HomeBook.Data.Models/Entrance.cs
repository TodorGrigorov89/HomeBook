namespace HomeBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;
    using HomeBook.Data.Common.Models;

    public class Entrance : BaseDeletableModel<int>
    {
        [MaxLength(GlobalConstants.DataValidations.EntranceAddressMaxLength)]
        public string EntranceAddressSign { get; set; }

        public int BuildingId { get; set; }

        public virtual Building Building { get; set; }

        public virtual ICollection<Apartment> Apartments { get; set; }
    }
}
