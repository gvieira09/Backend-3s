using Azure;
using Azure.AI.ContentSafety;
using EventPlus.WebAPI.Interface;
using EventPlus1.DTO;
using EventPlus1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComentarioEventoController : ControllerBase
    {
        private readonly ContentSafetyClient _contentSafetyClient;
        private readonly IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController(ContentSafetyClient
            contentSafetyClient, IComentarioEventoRepository comentarioEventoRepository)
        {
            _contentSafetyClient = contentSafetyClient;
            _comentarioEventoRepository = comentarioEventoRepository;
        }

        [HttpPost]

        public async Task<IActionResult> Post(ComentarioEventoDTO comentarioEvento)
        {
            try
            {
                if (string.IsNullOrEmpty(comentarioEvento.Descricao))
                {
                    return BadRequest("O texto a ser comentado, não pode estar vazio");

                }
                var request = new AnalyzeTextOptions(comentarioEvento.Descricao);

                Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);

                bool temConteudoImproprio = response.Value.CategoriesAnalysis.Any(comentarioEvento => comentarioEvento.Severity > 0);

                var novoComentario = new ComentarioEvento
                {
                    IdEvento = comentarioEvento.IdEvento,
                    IdUsuario = comentarioEvento.IdUsuario,
                    Descricao = comentarioEvento.Descricao,
                    Exibe = !temConteudoImproprio,
                    DataComentarioEvento = DateTime.Now
                };

                _comentarioEventoRepository.CadastrarComentarioEvento(novoComentario);
                return StatusCode(201, novoComentario);

            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

    } 
}

