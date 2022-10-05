using ForumApp.Data;
using ForumApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    public class PostController : Controller
    {
        private readonly ForumAppDbContext context;

        public PostController(ForumAppDbContext _context)
        {
            context=_context;
        }
        
        public async Task<IActionResult> Index()
        {
            var model = await context.Posts
                .Select(p=> new PostViewModel()
                {
                    Id=p.Id,
                    Title = p.Title,
                    Content = p.Content
                }) 
                .ToListAsync();  
            return View();
        }
    }
}
