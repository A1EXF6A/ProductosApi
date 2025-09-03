using Microsoft.AspNetCore.Mvc;
using ProductosApi.Models;
using ProductosApi.Services;

namespace ProductosApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly ProductoService _service;

        public ProductosController(ProductoService service)
        {
            _service = service;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Producto>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        
        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = _service.GetById(id);
            if (producto is null)
                return NotFound();
            return Ok(producto);
        }

    
        [HttpPost]
        public ActionResult<Producto> Create(Producto producto)
        {
            var created = _service.Add(producto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Producto producto)
        {
            var updated = _service.Update(id, producto);
            if (!updated)
                return NotFound();
            return NoContent();
        }

        
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deleted = _service.Delete(id);
            if (!deleted)
                return NotFound();
            return NoContent();
        }
    }
}
