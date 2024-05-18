using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQLiteSample.Data;
using SQLiteSample.Entities;

namespace SQLiteSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RpgCharacterController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public RpgCharacterController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<ActionResult<List<RpgCharacter>>> CreateCharacter(RpgCharacter character)
        {
            await _dataContext.AddAsync(character);

            await _dataContext.SaveChangesAsync();

            return Ok(await _dataContext.RpgCharacters.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<RpgCharacter>> GetAllCharacter()
        {
            return Ok(await _dataContext.RpgCharacters.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RpgCharacter>> GetCharacter(int id)
        {
            var character = await _dataContext.RpgCharacters.FindAsync(id);
            if (character == null)
            {
                return BadRequest("Character Not Found");
            }
            return Ok(character);
        }
    }
}
