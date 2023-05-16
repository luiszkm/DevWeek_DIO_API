using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using src.Models;
using src.Persistence;
using System.Net;

namespace src.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{

  private DatabaseContext _repository { get; set; }

  public PersonController(DatabaseContext repository)
  {
    this._repository = repository;
  }

  [HttpGet]
  public ActionResult<List<Person>> get()
  {
    var response = _repository.Persons.Include(person => person.Contracts).ToList();
    if (response.Count == 0) return NoContent();
    return Ok();
  }
  [HttpPost]
  public Person Post(Person person)
  {
    _repository.Persons.Add(person);
    _repository.SaveChanges();
    return person;
  }
  [HttpPut("{id}")]
  public String Update([FromRoute] int id, [FromBody] Person person)
  {
    _repository.Persons.Update(person);
    _repository.SaveChanges();
    return $"dados do id:{id} atualizado";
  }
  [HttpDelete("{id}")]
  public ActionResult<Object> Delete([FromRoute] int id)
  {
     var response = _repository.Persons.SingleOrDefault(person => person.Id == id);
     if(response is null) return BadRequest(new {msg = "pessoa não encontrada", status = HttpStatusCode.BadRequest});
    _repository.Persons.Remove(response);
    _repository.SaveChanges();
    return Ok();
  }
}