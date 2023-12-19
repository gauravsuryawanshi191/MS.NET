using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookAPI.Models;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookDbContext _context;

        public BookController(BookDbContext context)
        {
            _context = context;
        }

        // GET: api/Book
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TblBook>>> GetTblBooks()
        {
          if (_context.TblBooks == null)
          {
              return NotFound();
          }
            return await _context.TblBooks.ToListAsync();
        }

        //// GET: api/Book/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TblBook>> GetTblBook(int id)
        //{
        //  if (_context.TblBooks == null)
        //  {
        //      return NotFound();
        //  }
        //    var tblBook = await _context.TblBooks.FindAsync(id);

        //    if (tblBook == null)
        //    {
        //        return NotFound();
        //    }

        //    return tblBook;
        //}

        //// PUT: api/Book/5
        //// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTblBook(int id, TblBook tblBook)
        //{
        //    if (id != tblBook.BookId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(tblBook).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TblBookExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/Book
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TblBook>> PostTblBook(TblBook tblBook)
        {
          if (_context.TblBooks == null)
          {
              return Problem("Entity set 'BookDbContext.TblBooks'  is null.");
          }
            _context.TblBooks.Add(tblBook);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTblBook", new { id = tblBook.BookId }, tblBook);
        }

        //// DELETE: api/Book/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteTblBook(int id)
        //{
        //    if (_context.TblBooks == null)
        //    {
        //        return NotFound();
        //    }
        //    var tblBook = await _context.TblBooks.FindAsync(id);
        //    if (tblBook == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TblBooks.Remove(tblBook);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool TblBookExists(int id)
        {
            return (_context.TblBooks?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
