using ConnectPlus.Models;
using ConnectPlus.Repository;
using ConnectPlus.WebAPI.DTOs;
using ConnectPlus.WebAPI.Interface;
using ConnectPlus.WebAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContatoController : ControllerBase
    {
        private readonly IContatoRepository _repository;

        public ContatoController(IContatoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_repository.listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(Guid id)
        {
            var contato = _repository.BuscarPorId(id);

            if (contato == null)
                return NotFound();

            return Ok(contato);
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar([FromForm] ContatoResponseDTO dto)
        {
            try
            {
                Contato contato = new Contato();

                contato.Nome = dto.Nome!;
                contato.TipoContatoId = dto.TipoContatoId;
                contato.FormaContato = dto.FormaContato;

                if (dto.ImagemPath != null && dto.ImagemPath.Length > 0)
                {
                    var extensao = Path.GetExtension(dto.ImagemPath.FileName);
                    var nomeArquivo = $"{Guid.NewGuid()}{extensao}";

                    var pastaRelativa = "wwwroot/imagens";
                    var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                    if (!Directory.Exists(caminhoPasta))
                        Directory.CreateDirectory(caminhoPasta);

                    var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                    using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                    {
                        await dto.ImagemPath.CopyToAsync(stream);
                    }

                    contato.ImagemPath = nomeArquivo;
                }

                _repository.Cadastrar(contato);

                return StatusCode(201, contato);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
            [HttpDelete("{id}")]
            public async Task<IActionResult> Deletar(Guid id)
            {
                try
                {
                  var contato = _repository.BuscarPorId(id);

                    if (contato is null)
                        return NotFound("Contato não encontrado.");

                    _repository.Deletar(contato.Id);
                    return StatusCode(204);
                }
                catch (Exception error)
                {
                    return BadRequest(error.Message);
                }
            }
        
    }
}