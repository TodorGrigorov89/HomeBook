namespace HomeBook.Web.ViewModels.BlogPosts
{
    using System;

    using HomeBook.Data.Models;
    using HomeBook.Services.Mapping;

    public class BlogPostViewModel : IMapFrom<BlogPost>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
