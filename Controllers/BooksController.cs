using BookDepo.Api.Data;
using BookDepo.Api.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookDepo.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BooksDbContext _bookDbContext;

    public BooksController(BooksDbContext bookDbContext) => _bookDbContext = bookDbContext;



//fetch all products
[HttpGet]
public ActionResult<IEnumerable<Books>> Get()
    {
        //returns all records from Books table
        return _bookDbContext.Books;
    }

    //get a record based on ID passed
    [HttpGet("{id}")]
    public async Task<ActionResult<Books?>> GetById(int id)
    {
        return await _bookDbContext.Books.Where(x => x.Id == id).SingleOrDefaultAsync(); 
    }

    //create a new record in table
    [HttpPost]
    public async Task<ActionResult> Create(Books book)
    {
        //add the received book 
        await _bookDbContext.Books.AddAsync(book);
        //save it to the table
        await _bookDbContext.SaveChangesAsync();

        //returns the new record created
        return CreatedAtAction(nameof(GetById), new { id = book.Id }, book);
    }

    //update an existing record
    [HttpPut]
    public async Task<ActionResult> Update(Books book)
    {
        //update existing record and save it
        _bookDbContext.Books.Update(book);
        await _bookDbContext.SaveChangesAsync();

        //return status code after update
        return Ok();
    }

    //delete a record by id
    [HttpDelete]
    public async Task<ActionResult> Delete(int id)
    {
        //get the product by id
        var targetItem = await GetById(id);

        //check if the item exists in table
        if (targetItem.Value is null) return NotFound();

        //if the item exists delete it and save changes
        _bookDbContext.Remove(targetItem.Value);
        await _bookDbContext.SaveChangesAsync();

        //return the status
        return Ok();
    }

}