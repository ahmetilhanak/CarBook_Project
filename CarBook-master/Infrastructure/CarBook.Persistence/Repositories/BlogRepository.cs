using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly CarBookContext _carBookContext;

        public BlogRepository(CarBookContext carBookContext)
        {
            _carBookContext = carBookContext;
        }

        public List<Blog> GetBlogWithCategoryAndAuthor()
        {
            return _carBookContext.Blogs.Include(b => b.Category).Include(b => b.Author).ToList();
        }

        public Blog GetBlogByIdWithCategoryAndAuthor(int id)
        {
            //return _carBookContext.Blogs.Include(b => b.Category).Include(b => b.Author).ToList();
            var value = _carBookContext.Blogs.Include(b => b.Category).Include(b => b.Author).ToList().Find(z=>z.BlogID==id);
            return value;
        }

        public List<Blog> GetSomeBlogWithCategoryAndAuthor(int count)
        {
            return _carBookContext.Blogs.Include(b => b.Category).Include(b => b.Author).OrderByDescending(z=>z.BlogID).Take(count).ToList();
        }
    }
}
