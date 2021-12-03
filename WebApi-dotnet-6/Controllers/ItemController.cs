using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_dotnet_6.Data;

namespace WebApi_dotnet_6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private static List<Item> items = new List<Item>
            {
                //new Item { Id = 1,
                //    Name ="Item1",
                //    Description="lorem",
                //    Title="Doe",
                //    Url="asdasdas"
                //},
                //new Item { Id = 2,
                //    Name ="Item2",
                //    Description="333333333333333",
                //    Title="44444444444444444",
                //    Url="55555555555555"
                //}
            };
        private readonly DataContext context;

        public ItemController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Item>>> Get()
        {

            return Ok(await this.context.items.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> Get(int id)
        {
            var item = await this.context.items.FindAsync(id);
            if (item == null)

                return BadRequest("Not Found!!!");

            return Ok(item);
        }
        [HttpPost]
        public async Task<ActionResult<List<Item>>> Add(Item item)
        {
             this.context.items.Add(item);
            await this.context.SaveChangesAsync();

            return Ok(await this.context.items.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Item>>> Update(Item request)
        {
            var item = await this.context.items.FindAsync(request.Id);
            if (item == null)

                return BadRequest("Not Found!!!");
            item.Name = request.Name;
            item.Description = request.Description;
            item.Title = request.Title;
            item.Url = request.Url;

            await this.context.SaveChangesAsync();

            return Ok(await this.context.items.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Item>>> Delete(int id)
        {
            var item = await this.context.items.FindAsync(id);
            if (item == null)

                return BadRequest("Not Found!!!");
            this.context.items.Remove(item);

            await this.context.SaveChangesAsync();

            return Ok(item);
        }
    }
}
