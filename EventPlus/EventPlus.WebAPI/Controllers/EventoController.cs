using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private IEventoRepository _eventoRepository;


    public EventoController(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de listar eventos filtrado por usuário
    /// </summary>
    /// <param name="idUsuario">Id do usuário para filtragem</param>
    /// <returns>Lista de eventos filtrados por usuário</returns>
     [HttpGet("Usuario/{idUsuario}")]
     public IActionResult ListarPorId(Guid idUsuario)
     {
         try
         {
             return Ok(_eventoRepository.ListarPorId(idUsuario));
         }
         catch (Exception e)
         {
             return BadRequest(e.Message);
         }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de listar os próximos eventos
    /// </summary>
    /// <returns>Status code 200 e uma lista de próximos eventos</returns>
    [HttpGet("ProximosEventos")]
    public IActionResult ListarProximosEventos()
    {
        try
        {
            return Ok(_eventoRepository.ListarProximos());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de lista os eventos
    /// </summary>
    /// <returns>Status code 200 e a lista de eventos</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_eventoRepository.Listar());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de buscar um evento
    /// </summary>
    /// <param name="id">Id do evento buscado</param>
    /// <returns>Status code 200 e o evento buscado</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_eventoRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para o método de cadastro um evento
    /// </summary>
    /// <param name="evento">Evento a ser cadastrado</param>
    /// <returns>Status code 201 e o evento cadastrado</returns>
    [HttpPost]
    public IActionResult Cadastrar(EventoDTO evento)
    {
        try
        {
            var novoEvento = new Evento
            {
                Nome = evento.Nome!,
                DataEvento = DateTime.Parse(evento.DataEvento!),
                Descricao = evento.Descricao!,
                IdTipoEvento = Guid.Parse(evento.IdTipoEvento!),
                IdInstituicao = Guid.Parse(evento.IdInstituicao!)
            };

            _eventoRepository.Cadastrar(novoEvento);
            return StatusCode(201, novoEvento);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de atualizar um evento
    /// </summary>
    /// <param name="id">Id do evento a ser atualizado</param>
    /// <param name="evento">evento com os dados atualizados</param>
    /// <returns>Status code 204 e o evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, EventoDTO evento)
    {
        try
        {
            var eventoAtualizado = new Evento
            {
                IdEvento = id,
                Nome = evento.Nome!,
                DataEvento = DateTime.Parse(evento.DataEvento!),
                Descricao = evento.Descricao!,
                IdTipoEvento = Guid.Parse(evento.IdTipoEvento!),
                IdInstituicao = Guid.Parse(evento.IdInstituicao!)
            };
            _eventoRepository.Atualizar(id, eventoAtualizado);
            return StatusCode(204, eventoAtualizado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    /// <summary>
    /// Endpoint da API que faz a chamada para o método de deletar um evento
    /// </summary>
    /// <param name="id">Id do evento a ser deletado</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
    }
}
