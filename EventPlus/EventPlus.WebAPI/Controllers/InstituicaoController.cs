using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class InstituicaoController : ControllerBase
{
    private readonly IInstituicaoRepository _instituicaoRepository;

    public InstituicaoController(IInstituicaoRepository instituicaoRepository)
    {
        _instituicaoRepository = instituicaoRepository;
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de lista as instituições
    /// </summary>
    /// <returns>Status code 200 e a lista de tipos de eventos</returns>
     [HttpGet]
     public IActionResult Listar()
     { 
        try
        {
             return Ok(_instituicaoRepository.Listar());
         }
         catch (Exception e)
         {
             return BadRequest(e.Message);
         }
      }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de buscar uma instituição
    /// </summary>
    /// <param name="id">id da instituição buscada</param>
    /// <returns>status code 200 e a instituição buscada</returns>
     [HttpGet("{id}")]
      public IActionResult BuscarPorId(Guid id)
      {
          try
          {
              return Ok(_instituicaoRepository.BuscarPorId(id));
          }
          catch (Exception e)
          {
              return BadRequest(e.Message);
          }
      }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de cadastro uma instituição
    /// </summary>
    /// <param name="instituicao">Instituição a ser cadastrada</param>
    /// <returns>Status code 201 e a instituição a ser cadastrada</returns>
     [HttpPost]
      public IActionResult Cadastrar(InstituicaoDTO instituicao)
      {
          try
          {
            var novaInstituicao = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia!,
                Cnpj = instituicao.CNPJ!,
                Endereco = instituicao.Endereco!
            };
              _instituicaoRepository.Cadastrar(novaInstituicao);
              return StatusCode(201, novaInstituicao);
          }
          catch (Exception e)
          {
              return BadRequest(e.Message);
          }
    }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de atualizar uma instituição
    /// </summary>
    /// <param name="id">Id da instituição a ser atualizada</param>
    /// <param name="instituicao">Instituição com os dados atualizados</param>
    /// <returns>Status code 204 e a instituição atualizada</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, InstituicaoDTO instituicao)
    {
        try
        {
            var instituicaoAtualizada = new Instituicao
            {
                NomeFantasia = instituicao.NomeFantasia!,
                Cnpj = instituicao.CNPJ!,
                Endereco = instituicao.Endereco!
            };
            _instituicaoRepository.Atualizar(id, instituicaoAtualizada);
            return StatusCode(204, instituicaoAtualizada);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
     }

    /// <summary>
    /// Endpoint da API que faz a chamada para o método de deletar uma instituição
    /// </summary>
    /// <param name="id">Id da instituição</param>
    /// <returns>Status code 204</returns>
     [HttpDelete("{id}")]
     public IActionResult Deletar(Guid id)
     {
         try
         {
             _instituicaoRepository.Deletar(id);
             return NoContent();
         }
         catch (Exception e)
         {
             return BadRequest(e.Message);
         }
      }
}
