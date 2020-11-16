namespace HomeBook.Web.ViewModels.Apartments
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;

    public class ApartmentInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.ApartmentNumberMaxLengh,
            ErrorMessage = GlobalConstants.ErrorMessages.ApartmentNumberLength,
            MinimumLength = GlobalConstants.DataValidations.ApartmentNumberMinLength)]
        public string ApartmentNumber { get; set; }

        [Range(
            GlobalConstants.DataValidations.ApartmentFloorMinNumber,
            GlobalConstants.DataValidations.ApartmentFloorMaxNumber)]
        public int Floor { get; set; }

        [Range(
            GlobalConstants.DataValidations.ApartmentResidentsMinNumber,
            GlobalConstants.DataValidations.ApartmentResidentsMaxNumber)]
        public int NumberOfResidents { get; set; }

        [Range(
            GlobalConstants.DataValidations.ApartmentMinArea,
            GlobalConstants.DataValidations.ApartmentMaxArea)]
        public double Area { get; set; }

        public int EntranceId { get; set; }
    }
}
