namespace HomeBook.Web.ViewModels.Buildings
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;

    public class BuildingInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.BuildingFullAddressMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.BuildingFullAddressLength,
            MinimumLength = GlobalConstants.DataValidations.BuildingFullAddressMinLength)]
        public string BuildingFullAddress { get; set; }

        [Range(
            GlobalConstants.DataValidations.BuildingMinEntrances,
            GlobalConstants.DataValidations.BuildingMaxEntrances)]
        public int NumberOfEntrances { get; set; }

        [Range(
            GlobalConstants.DataValidations.BuildingMinFloors,
            GlobalConstants.DataValidations.BuildingMaxFloors)]
        public int NumberOfFloors { get; set; }

        [Range(
            GlobalConstants.DataValidations.ApartmentMinNumber,
            GlobalConstants.DataValidations.ApartmentMaxNumber)]
        public int NumberOfApartments { get; set; }

        public int StreetId { get; set; }
    }
}
