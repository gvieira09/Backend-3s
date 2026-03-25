using EventPlus.WebAPI.Interface;
using EventPlus1.BdContextEvento;
using EventPlus1.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repository;

public class EventoRepository : IEventoRepository
{
    private readonly EventosContext _context;

    public EventoRepository(EventosContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um evento usando o rastreamento automático
    /// </summary>
    /// <param name="id">id do evento a ser atualizado</param>
    /// <param name="instituicao">Novos dados do evento</param>
    public void Atualizar(Guid id, Evento evento)
    {
        var eventoBuscado = _context.Eventos.Find(id);

        if(eventoBuscado != null)
        {
            eventoBuscado.Nome = evento.Nome;
            eventoBuscado.DataEvento = evento.DataEvento;
            eventoBuscado.Descricao = evento.Descricao;
            eventoBuscado.IdTipoEvento = evento.IdTipoEvento;
            eventoBuscado.IdInstituicao = evento.IdInstituicao;
        }
        _context.SaveChanges();
    }

    /// <summary>
    /// Busca um evento por id
    /// </summary>
    /// <param name="id">id do evento a ser buscado</param>
    /// <returns>objeto do evento com as informações do evento</returns>
    public Evento BuscarPorId(Guid id)
    {
        return _context.Eventos.Find(id)!;
    }

    /// <summary>
    /// Cadastra um novo evento
    /// </summary>
    /// <param name="instituicao">Evento a ser cadastradp</param>
    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um evento
    /// </summary>
    /// <param name="id">id do evento a ser deletado</param>
    public void Deletar(Guid id)
    {
        var eventoBuscado = _context.Eventos.Find(id);

        if(eventoBuscado != null)
        {
            _context.Eventos.Remove(eventoBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de eventos cadastradas
    /// </summary>
    /// <returns>Uma lista de eventos</returns>
    public List<Evento> Listar()
    {
        return _context.Eventos.ToList();
    }

    /// <summary>
    /// Método que lista eventos filtrando pelas presenças de um usuário
    /// </summary>
    /// <param name="IdUsuario">Id do usuário para filtragem</param>
    /// <returns>Lista os eventos filtrados por usuário</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.Presencas.Any(p => p.IdUsuario == IdUsuario && p.Situacao == true))
            .ToList();
    }

    /// <summary>
    /// Método que busca os próximos eventos que irão acontecer
    /// </summary>
    /// <returns>Lista de próximos eventos</returns>
    public List<Evento> ListarProximos()
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.DataEvento >= DateTime.Now)
            .OrderBy(e => e.DataEvento)
            .ToList();
    }
}
