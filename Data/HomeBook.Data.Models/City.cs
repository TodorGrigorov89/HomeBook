namespace HomeBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;
    using HomeBook.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public City()
        {
            this.Streets = new HashSet<Street>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.CityNameMaxLength)]
        public string Name { get; set; }

        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<Street> Streets { get; set; }
    }
}
