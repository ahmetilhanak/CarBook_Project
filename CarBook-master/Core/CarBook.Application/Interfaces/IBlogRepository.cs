using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetBlogWithCategoryAndAuthor();
        List<Blog> GetSomeBlogWithCategoryAndAuthor(int count);
        Blog GetBlogByIdWithCategoryAndAuthor(int id);
    }
}
