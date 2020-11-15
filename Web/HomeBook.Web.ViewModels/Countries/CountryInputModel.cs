namespace HomeBook.Web.ViewModels.Countries
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;

    public class CountryInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.CountryNameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.CountryNameLength,
            MinimumLength = GlobalConstants.DataValidations.CountryNameMinLength)]
        public string Name { get; set; }
    }
}
