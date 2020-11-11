namespace HomeBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;
    using HomeBook.Data.Common.Models;

    public class Country : BaseDeletableModel<int>
    {
        public Country()
        {
            this.Cities = new HashSet<City>();
        }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.CountryNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
