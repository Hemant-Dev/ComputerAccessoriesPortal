using ComputerAccessories.IServices;
using ComputerAccessories.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ComputerAccssories.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MouseController : ControllerBase
    {
        private readonly IMouseService _mouseService;
        public MouseController(IMouseService mouseService)
        {
            this._mouseService = mouseService;
        }
        // GET: api/<MouseController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mouse>>> GetAllMouseAsync()
        {
            var mouseList = await _mouseService.GetAllMouseAsync();
            if(mouseList == null)
            {
                return NoContent();
            }
            return Ok(mouseList);
        }

        // GET api/<MouseController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Mouse>> GetMouseAsync(int id)
        {
            var mouse = await _mouseService.GetMouseByIdAsync(id);
            if(mouse == null)
            {
                return NotFound();
            }
            return Ok(mouse);
        }

        // POST api/<MouseController>
        [HttpPost]
        public async Task<ActionResult<Mouse>> PostMouseAsync([FromBody] Mouse mouse)
        {
            if(mouse == null)
            {
                return BadRequest();
            }
            await _mouseService.CreateMouseAsync(mouse);
            return Ok(mouse);
        }

        // PUT api/<MouseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Mouse>> PutMouseAsync(int id, [FromBody] Mouse mouse)
        {
            var oldMouse = await _mouseService.GetMouseByIdAsync(id);
            if(oldMouse == null)
            {
                return NotFound();
            }
            oldMouse.Name = mouse.Name;
            oldMouse.BrandId = mouse.BrandId;
            oldMouse.Price = mouse.Price;
            await _mouseService.UpdateMouseAsync(id, oldMouse);
            return Ok(oldMouse);
        }

        // DELETE api/<MouseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var mouse = await _mouseService.GetMouseByIdAsync(id);
            if(mouse == null)
            {
                return Ok(false);  

            }
            await _mouseService.DeleteMouseAsync(id);
            return Ok(true);
        }
    }
}
