namespace HomeBook.Web.ViewModels.ContactForm
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;

    public class ContactFormViewModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.ContactFormNameMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.ContactFormNameLength,
            MinimumLength = GlobalConstants.DataValidations.ContactFormNameMinLength)]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.ContactFormTitleMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.ContactFormTitleLength,
            MinimumLength = GlobalConstants.DataValidations.ContactFormTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.ContactFormContentMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.ContactFormContentLength,
            MinimumLength = GlobalConstants.DataValidations.ContactFormContentMinLength)]
        public string Content { get; set; }
    }
}
