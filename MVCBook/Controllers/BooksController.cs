using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCBook.Models;

namespace MVCBook.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookDbContext _context;

        public BooksController(BookDbContext context)
        {
            _context = context;
        }

        // GET: Books
        public IActionResult Index()
        {
              return View();
        }
        public async Task<IActionResult> ShowBooks()
        {
            return _context.TblBooks != null ?
                        View(await _context.TblBooks.ToListAsync()) :
                        Problem("Entity set 'BookDbContext.TblBooks'  is null.");
        }

        // GET: Books/Create
        public IActionResult AddBook()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook([Bind("BookId,BookName,BookAuthor,BookPrice")] TblBook tblBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblBook);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBook);
        }
        //// GET: Books/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null || _context.TblBooks == null)
        //    {
        //        return NotFound();
        //    }

        //    var tblBook = await _context.TblBooks
        //        .FirstOrDefaultAsync(m => m.BookId == id);
        //    if (tblBook == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tblBook);
        //}


        //// GET: Books/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.TblBooks == null)
        //    {
        //        return NotFound();
        //    }

        //    var tblBook = await _context.TblBooks.FindAsync(id);
        //    if (tblBook == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(tblBook);
        //}

        //// POST: Books/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("BookId,BookName,BookAuthor,BookPrice")] TblBook tblBook)
        //{
        //    if (id != tblBook.BookId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(tblBook);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!TblBookExists(tblBook.BookId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(tblBook);
        //}

        //// GET: Books/Delete/5
        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null || _context.TblBooks == null)
        //    {
        //        return NotFound();
        //    }

        //    var tblBook = await _context.TblBooks
        //        .FirstOrDefaultAsync(m => m.BookId == id);
        //    if (tblBook == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(tblBook);
        //}

        //// POST: Books/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    if (_context.TblBooks == null)
        //    {
        //        return Problem("Entity set 'BookDbContext.TblBooks'  is null.");
        //    }
        //    var tblBook = await _context.TblBooks.FindAsync(id);
        //    if (tblBook != null)
        //    {
        //        _context.TblBooks.Remove(tblBook);
        //    }

        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool TblBookExists(int id)
        {
          return (_context.TblBooks?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
