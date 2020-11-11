namespace HomeBook.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using HomeBook.Common;
    using HomeBook.Data.Common.Models;
    using HomeBook.Data.Models.Enums;

    public class Document : BaseDeletableModel<int>
    {
        public Document()
        {
            this.DocumentUsers = new HashSet<UserDocument>();
        }

        [Required]
        public DocumentType DocumentType { get; set; }

        [Required]
        [MaxLength(GlobalConstants.DataValidations.DescriptionMaxLength)]
        public string Description { get; set; }

        public virtual ICollection<UserDocument> DocumentUsers { get; set; }
    }
}
