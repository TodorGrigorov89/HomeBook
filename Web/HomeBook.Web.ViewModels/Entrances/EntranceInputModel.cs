namespace HomeBook.Web.ViewModels.Entrances
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;

    public class EntranceInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.EntranceMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.EntranceAddressSignLength,
            MinimumLength = GlobalConstants.DataValidations.EntranceMinLength)]
        public string EntranceAddressSign { get; set; }

        public int BuildingId { get; set; }
    }
}
