namespace HomeBook.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;
    using HomeBook.Data.Common.Models;

    public class ContactForm : BaseModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.DataValidations.ContactFormNameMaxLength)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.ContactFormTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.ContactFormContentMaxLength)]
        public string Content { get; set; }
    }
}
