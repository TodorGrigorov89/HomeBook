namespace HomeBook.Web.ViewModels.Cities
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;

    public class CityInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.CityNameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.CityNameLength,
            MinimumLength = GlobalConstants.DataValidations.CityNameMinLength)]
        public string Name { get; set; }

        public int CountryId { get; set; }
    }
}
