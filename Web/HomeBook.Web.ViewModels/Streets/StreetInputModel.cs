namespace HomeBook.Web.ViewModels.Streets
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;

    public class StreetInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.StreetNameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.StreetNameLength,
            MinimumLength = GlobalConstants.DataValidations.StreetNameMinLength)]
        public string Name { get; set; }

        public int CityId { get; set; }
    }
}
