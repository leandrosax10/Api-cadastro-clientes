using CadastroClientesAPI.Entities;
using CadastroClientesAPI.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroClientesAPI.Controllers
{
    [Route("api/cadastro-clientes")]
    public class CadastroClientesController : ControllerBase
    {
        private readonly ClienteDbContext _context;

        public CadastroClientesController(ClienteDbContext context)
        {
            _context = context;
        }

        //GET
        [HttpGet]
        public IActionResult GetAll()
        { 
            var clientes = _context.Clientes.Where(d => !d.IsDeletado).ToList();

            return Ok(clientes);

        }

        //GET By ID
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id) 
        {
            var clientes = _context.Clientes.SingleOrDefault(d => d.Id == id);

            if (clientes == null)
            {
                return NotFound();
            }
            return Ok(clientes);
        }

        //POST
        [HttpPost]
        public IActionResult Post(Clientes clientes) 
        {
            _context.Clientes.Add(clientes);

            return CreatedAtAction(nameof(GetById), new { id = clientes.Id}, clientes);
        }


        //UPDATE
        [HttpPut("{id}")]
        public IActionResult Update(Guid id,Clientes cliente)
        {
            var clientes = _context.Clientes.SingleOrDefault(d => d.Id == id);

            if (clientes == null)
            {
                return NotFound();
            }

            clientes.Update(cliente.Nome, cliente.Endereco, cliente.Email,
                cliente.Telefone, cliente.Cpf, cliente.DataNascimento); 
            
            return NoContent();
        }

        //DELETE
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var clientes = _context.Clientes.SingleOrDefault(d => d.Id == id);

            if (clientes == null)
            {
                return NotFound();
            }
            clientes.Delete();

            return NoContent();
        }

    }
}
