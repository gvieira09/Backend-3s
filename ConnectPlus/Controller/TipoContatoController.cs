using Microsoft.AspNetCore.Mvc;
using ConnectPlus.Models;
using ConnectPlus.WebAPI.Interface;

namespace ConnectPlus.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoContatoController : ControllerBase
    {
        private readonly ITipoContatoRepository _repository;

        public TipoContatoController(ITipoContatoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_repository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            var tipo = _repository.BuscarPorId(id);

            if (tipo == null)
                return NotFound();

            return Ok(tipo);
        }

        [HttpPost]
        public IActionResult Cadastrar(TiposContato tipo)
        {
            _repository.Cadastrar(tipo);
            return CreatedAtAction(nameof(BuscarPorId), new { id = tipo.Id }, tipo);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, TiposContato tipo)
        {
            tipo.Id = id;
            _repository.Atualizar(tipo);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            _repository.Deletar(id);
            return NoContent();
        }
    }
}
