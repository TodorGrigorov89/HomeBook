namespace HomeBook.Web.ViewModels.BlogPosts
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;
    using HomeBook.Web.ViewModels.ValidationAttributes;
    using Microsoft.AspNetCore.Http;

    public class BlogPostInputModel
    {
        [Required]
        [StringLength(
            GlobalConstants.DataValidations.BlogTitleMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.BlogTitleLength,
            MinimumLength = GlobalConstants.DataValidations.BlogTitleMinLength)]
        public string Title { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.BlogContentMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.BlogContentLength,
            MinimumLength = GlobalConstants.DataValidations.BlogContentMinLength)]
        public string Content { get; set; }

        [Required]
        [StringLength(
            GlobalConstants.DataValidations.BlogAuthorMaxLength,
            ErrorMessage = GlobalConstants.ErrorMessages.BlogAuthorNameLength,
            MinimumLength = GlobalConstants.DataValidations.BlogAuthorMinLength)]
        public string Author { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [ImageValidationAttribute(ErrorMessage = GlobalConstants.ErrorMessages.ImageFormatAndSize)]
        public IFormFile Image { get; set; }
    }
}
