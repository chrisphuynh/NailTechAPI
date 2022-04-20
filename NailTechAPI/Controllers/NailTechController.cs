using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NailTechAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NailTechController : ControllerBase
    {
        private readonly DataContext context;
        public NailTechController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<NailTech>>> Get()
        {
            return Ok(await context.NailTechs.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NailTech>> Get(int id)
        {
            var tech = await context.NailTechs.FindAsync(id);
            if (tech == null)
                return BadRequest("Nail Technician was not found.");
            return Ok(tech);
        }

        [HttpPost]
        public async Task<ActionResult<List<NailTech>>> AddTech(NailTech tech)
        {
            context.NailTechs.Add(tech);
            await context.SaveChangesAsync();
            return Ok(await context.NailTechs.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<NailTech>>> UpdateTech(NailTech request)
        {
            var dbTech = await context.NailTechs.FindAsync(request.Id);
            if (dbTech == null)
                return BadRequest("Nail Technician was not found.");

            dbTech.Nickname = request.Nickname;
            dbTech.FirstName = request.FirstName;
            dbTech.LastName = request.LastName;

            await context.SaveChangesAsync();
            return Ok(await context.NailTechs.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<NailTech>>> Delete(int id)
        {
            var dbTech = await context.NailTechs.FindAsync(id);
            if (dbTech == null)
                return BadRequest("Nail Technician was not found.");

            context.NailTechs.Remove(dbTech);
            await context.SaveChangesAsync();

            return Ok(await context.NailTechs.ToListAsync());
        }   
    }
}
