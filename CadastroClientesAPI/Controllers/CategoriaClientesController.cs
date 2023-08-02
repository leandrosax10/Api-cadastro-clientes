using CadastroClientesAPI.Entities;
using CadastroClientesAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientesAPI.Controllers
{
        //[Route("api/categoria")]
        public class CategoriaController : ControllerBase
        {
            private readonly ClienteDbContext _context;
            public CategoriaController(ClienteDbContext context) 
            {
                _context = context; 
            }

            //GETT ALL
            [HttpGet]
            [Route("api/categoria")]
            public IActionResult GetAll()
            {
                var categoria = _context.Categoria.Where(d => !d.IsDeletado).ToList();

                return Ok(categoria);
            }

            //GET BY ID
            [HttpGet]
            [Route("api/categoria/{id}")]
            public IActionResult GetById(Guid id)
            {
                var categoria = _context.Categoria.SingleOrDefault(d => d.Id == id);

                if (categoria == null)
                {
                    return NotFound();
                }
                return Ok(categoria);
            }

             //POST
            [HttpPost]
            [Route("api/categoria")]
            public IActionResult Post(Categoria categoria)
            {
                _context.Categoria.Add(categoria);

                return CreatedAtAction(nameof(GetById), new { id = categoria.Id }, categoria);
            }

            //UPDATE
            [HttpPut("api/categoria/{id}")]
            public IActionResult Update(Guid id, Categoria categoria)
            {
                var categorias = _context.Categoria.SingleOrDefault(d => d.Id == id);

                if (categorias == null)
                {
                    return NotFound();
                }

                categorias.Update(categoria.Nome);

                return NoContent();
            }

            //DELETE
            [HttpDelete("api/categoria/{id}")]
            public IActionResult Delete(Guid id)
            {
                var categorias = _context.Categoria.SingleOrDefault(d => d.Id == id);

                if (categorias == null)
                {
                    return NotFound();
                }
                categorias.Delete();

                return NoContent();

            }

        }

    
}
