namespace HomeBook.Web.ViewModels.Documents
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;
    using HomeBook.Data.Models.Enums;

    public class DocumentInputModel
    {
        [Required]
        [EnumDataType(typeof(DocumentType))]
        public DocumentType DocumentType { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.DescriptionMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.DescriptionLength,
            MinimumLength = GlobalConstants.DataValidations.DescriptionMinLength)]
        public string Description { get; set; }
    }
}
