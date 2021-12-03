using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi_dotnet_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private static List<Item> items = new List<Item>
            {
                new Item { Id = 1,
                    Name ="Item1",
                    Description="lorem",
                    Title="Doe",
                    Url="asdasdas"
                },
                new Item { Id = 2,
                    Name ="Item2",
                    Description="333333333333333",
                    Title="44444444444444444",
                    Url="55555555555555"
                }
            };

        [HttpGet]
        public async Task<ActionResult<List<Item>>> Get()
        {

            return Ok(items);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            var item = items.Find(i => i.Id == id);
            if (item == null)
                return BadRequest("Not Found!!!");
            return Ok(item);
        }
        [HttpPost]
        public async Task<ActionResult<List<Item>>> Add(Item item)
        {
            items.Add(item);

            return Ok(items);
        }
        [HttpPut]
        public async Task<ActionResult<List<Item>>> Update(Item request)
        {
            var item = items.Find(i => i.Id == request.Id);
            if (item == null)
                return BadRequest("Not Found!!!");
            item.Name = request.Name;
            item.Description = request.Description;
            item.Title = request.Title;
            item.Url = request.Url;
            return Ok(items);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Item>>> Delete(int id)
        {
            var item = items.Find(i => i.Id == id);
            if (item == null)
                return BadRequest("Not Found!!!");
            items.Remove(item);
            return Ok(item);
        }
    }
}
