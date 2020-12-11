namespace HomeBook.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;
    using HomeBook.Data.Common.Models;

    public class BlogPost : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(GlobalConstants.DataValidations.BlogTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.BlogContentMaxLength)]
        public string Content { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.BlogAuthorMaxLength)]
        public string Author { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}
