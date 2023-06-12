using Microsoft.AspNetCore.Mvc;
using TestApi.Models;
using Microsoft.EntityFrameworkCore;

namespace TestApi.Controllers;

[Route("api/[Controller]")]
[ApiController]
public class TodoItemsController : ControllerBase
{
    private static readonly string[] Item = new[]
    {
        "LayStack", "Pocky", "Collon", "Testo"
    };

    [HttpGet]
    public IEnumerable<TodoItems> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new TodoItems
        {
            Id = index,
            Items = Item[Random.Shared.Next(Item.Length)],
            Amount = Random.Shared.Next(20, 100)

        })
        .ToArray();
    }

    [HttpGet("GetbyID/{id}")]
    public TodoItems GetbyID(int id)
    {
        return new TodoItems
        {
            Id = id,
            Items = Item[id],
            Amount = Random.Shared.Next(20, 100)
        };
    }

    [HttpGet("GetbyName/{name}")]
    public TodoItems GetbyName(string name)
    {
        return new TodoItems
        {
            Id = Array.IndexOf(Item, name),
            Items = Item[Array.IndexOf(Item, name)],
            Amount = Random.Shared.Next(20, 100)
        };
    }
}

