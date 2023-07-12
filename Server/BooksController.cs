using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using BlazorApp.Server.Data;
using BlazorApp.Server.Models;
using BlazorApp.Shared.Models;
using IdentityModel;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext context;
        private readonly ApplicationDbContext appContext;

        //private readonly UserManager<ApplicationUser> _userManager;


        public BooksController(AppDbContext context, ApplicationDbContext appContext)//, UserManager<ApplicationUser> userManager
        {
            this.context = context;
            this.appContext = appContext;
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<Book>>> ListAsync()
        {

            var books = await context.Books.ToListAsync();
            var booklist = new List<Book>();
            var userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
                foreach (var book in books)
                {
                if (book.UserId == userid)
                {
                        booklist.Add(book);
                    }
                }
            return Ok(booklist);
        }
        //追加
        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<Book>> GetAsync(int id)
        {
            var book = await context.Books.SingleOrDefaultAsync(b => b.BookId.Equals(id));

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Book>> CreateAsync(Book book)
        {
            if (book.BookId != 0)
            {
                return BadRequest();
            }
            book.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            context.Books.Add(book);

            await context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = book.BookId }, book);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var book = await context.Books.SingleOrDefaultAsync(b => b.BookId.Equals(id));
            book.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (book == null)
            {
                return NotFound();
            }

            context.Books.Remove(book);
            await context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(Book book)
        {
            if (await context.Books.AsNoTracking().SingleOrDefaultAsync(b => b.BookId == book.BookId) == null)
            {
                return NotFound();
            }
            book.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            context.Entry(book).State = EntityState.Modified;
            await context.SaveChangesAsync();
            return NoContent();
        }
    }
}

