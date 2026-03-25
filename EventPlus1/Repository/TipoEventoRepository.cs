using EventPlus.WebAPI.Interface;
using EventPlus1.BdContextEvento;
using EventPlus1.Models;

namespace EventPlus.WebAPI.Repository;

public class TipoEventoRepository : ITipoEventoRepository
{
    private readonly EventosContext _context;
    

    public TipoEventoRepository(EventosContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza um tipo de evento usando o rastreamento autmomático
    /// </summary>
    /// <param name="id">id do tipo evento a ser atualizado</param>
    /// <param name="tipoEvento">Novos dados do tipo evento</param>
    public void Atualizar(Guid id, TipoEvento tipoEvento)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);

        if(tipoEventoBuscado != null)
        {
            tipoEventoBuscado.Titulo = tipoEvento.Titulo;

            //Save Changes detecta as alterações e salva no banco de dados
            _context.SaveChanges();
        }
        
    }

    /// <summary>
    /// Busca um tipo de evento por id
    /// </summary>
    /// <param name="id">id do tipo evento a ser buscado</param>
    /// <returns>objeto do tipoevento com as informações do tipo de evento busacdo</returns>
    public TipoEvento BuscarPorId(Guid id)
    {
        return _context.TipoEventos.Find(id)!;
    }

    /// <summary>
    /// Cadastra um novo tipo de evento
    /// </summary>
    /// <param name="tipoEvento">Tipo de evento a ser cadastrado</param>
    public void Cadastrar(TipoEvento tipoEvento)
    {
        _context.TipoEventos.Add(tipoEvento);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta um tipo de evento
    /// </summary>
    /// <param name="id">id do tipo evento a ser deletado</param>
    public void Deletar(Guid id)
    {
        var tipoEventoBuscado = _context.TipoEventos.Find(id);

        if(tipoEventoBuscado != null)
        {
            _context.TipoEventos.Remove(tipoEventoBuscado);
            _context.SaveChanges();
        }
    }
    /// <summary>
    /// Busca a lista de tipo de eventos cadastrados
    /// </summary>
    /// <returns>Uma lista de tipo eventos</returns>
    public List<TipoEvento> Listar()
    {
        return _context.TipoEventos
            .OrderBy(TipoEvento => TipoEvento.Titulo)
            .ToList();
    }
}