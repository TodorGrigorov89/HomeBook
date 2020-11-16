namespace HomeBook.Web.ViewModels.Entrances
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;

    public class EntranceInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.EntranceAddressMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.EntranceAddressSignLength,
            MinimumLength = GlobalConstants.DataValidations.EntranceAddressMinLength)]
        public string EntranceAddressSign { get; set; }

        public int BuildingId { get; set; }
    }
}
