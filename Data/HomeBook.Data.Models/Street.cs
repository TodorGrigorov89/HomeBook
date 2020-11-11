namespace HomeBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;
    using HomeBook.Data.Common.Models;

    public class Street : BaseDeletableModel<int>
    {
        public Street()
        {
            this.Buildings = new HashSet<Building>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.StreetNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.StreetNumberMaxLength)]
        public string StreetNumber { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Building> Buildings { get; set; }
    }
}
