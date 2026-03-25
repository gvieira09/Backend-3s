using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus1.DTO;
using EventPlus1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoUsuarioController : ControllerBase
{
    private readonly ITipoUsuarioRepository _tipoUsuarioRepository;

    public TipoUsuarioController(ITipoUsuarioRepository tipoUsuarioRepository)
    {
        _tipoUsuarioRepository = tipoUsuarioRepository;
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de lista os tipos de usuário
    /// </summary>
    /// <returns>Status code 200 e a lista de tipos de usuário</returns>
    [HttpGet]
     public IActionResult Listar()
     { try{
             return Ok(_tipoUsuarioRepository.Listar());
         }
         catch (Exception e)
         {
             return BadRequest(e.Message);
         }
      }

    /// <summary>
    /// EndPoint da API que faz a chamada para o método de buscar um tipo de usuário específico
    /// </summary>
    /// <param name="id">id do tipo de ususario buscado</param>
    /// <returns>Status code 200 e o tipo de usuário</returns>
    [HttpGet("{id}")]
     public IActionResult BuscarPorId(Guid id)
     {
         try
         {
             return Ok(_tipoUsuarioRepository.BuscarPorId(id));
         }
         catch (Exception e)
         {
             return BadRequest(e.Message);
         }
     }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de cadastrar um novo tipo de usuário
    /// </summary>
    /// <param name="tipoUsuario">Tipo de usuario a ser cadastrado</param>
    /// <returns>Status code 201 e o tipo de usuario cadastrado</returns>
    [HttpPost]
     public IActionResult Cadastrar(TipoUsuarioDTO tipoUsuario)
     {
         try
         {
            var novoTipoUsuario = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

             _tipoUsuarioRepository.Cadastrar(novoTipoUsuario);
             return StatusCode(201, novoTipoUsuario);
         }
         catch (Exception e)
         {
             return BadRequest(e.Message);
         }
     }
    /// <summary>
    /// Endpoint da API que faz a chamada para o método de atualizar um tipo de usuário
    /// </summary>
    /// <param name="id">Id do tipo usuario a ser atualizado</param>
    /// <param name="tipoUsuario">Tipo usuario com os dados atualizados</param>
    /// <returns>Status code 204 e o tipo de evento atualizado</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoUsuarioDTO tipoUsuario)
    {
        try
        {
            var tipoUsuarioAtualizado = new TipoUsuario
            {
                Titulo = tipoUsuario.Titulo!
            };

            _tipoUsuarioRepository.Atualizar(id, tipoUsuarioAtualizado);
            return StatusCode(204, tipoUsuarioAtualizado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de deletar um tipo de usuário
    /// </summary>
    /// <param name="id">Id do tipo usuário a ser deletado</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _tipoUsuarioRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


}
