using BooksAPI.Models;
using BooksAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BooksAPI.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;    
        }

        // GET: book
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookRepository.GetAll();
        }

        // GET book/5
        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult Get(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST book
        [HttpPost]
        public IActionResult Post([FromBody]Book value)
        {
            if (value == null)
            {
                return BadRequest();
            }
            var createdBook = _bookRepository.Add(value);

            return CreatedAtRoute("GetBook", new { id = createdBook.Id }, createdBook);
        }

        // PUT book/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Book value)
        {
            if (value == null)
            {
                return BadRequest();
            }

            var note = _bookRepository.GetById(id);

            if (note == null)
            {
                return NotFound();
            }

            value.Id = id;
            _bookRepository.Update(value);

            return NoContent();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            _bookRepository.Delete(book);

            return NoContent();
        }
    }
}
