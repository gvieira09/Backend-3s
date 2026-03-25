using EventPlus.WebAPI.BdContextEvento;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repository;

public class PresencaRepository : IPresencaRepository
{
    private readonly EventosContext _context;

    public PresencaRepository(EventosContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Método que alterna a situação da presença
    /// </summary>
    /// <param name="id">Id da presença a ser alterada</param>
    public void Atualizar(Guid id)
    {
        var presencaBuscada = _context.Presencas.Find(id);

        if(presencaBuscada != null)
        {
            presencaBuscada.Situacao = !presencaBuscada.Situacao;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Método que busca uma presença por Id
    /// </summary>
    /// <param name="id">Id da presença a ser buscada</param>
    /// <returns>Retorna a presença buscada</returns>
    public Presenca BuscarPorId(Guid id)
    {
        return _context.Presencas
            .Include(p => p.IdEventoNavigation)
            .ThenInclude(e => e!.IdInstituicaoNavigation)
            .FirstOrDefault(p => p.IdPresenca == id)!;
    }

    /// <summary>
    /// Deleta uma presença
    /// </summary>
    /// <param name="id">Id da presença a ser deletada</param>
    public void Deletar(Guid id)
    {
        var presencaBuscado = _context.Presencas.Find(id);

        if (presencaBuscado != null)
        {
            _context.Presencas.Remove(presencaBuscado);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Inscreve uma nova presença
    /// </summary>
    /// <param name="presenca">presença a ser cadastrada</param>
    public void Inscrever(Presenca presenca)
    {
        _context.Presencas.Add(presenca);
        _context.SaveChanges();
    }

    /// <summary>
    /// Busca a lista de presenças cadastradas
    /// </summary>
    /// <returns>Uma lista de presenças</returns>
    public List<Presenca> Listar()
    {
        return _context.Presencas.ToList();
    }

    /// <summary>
    /// Método que lista as presenças de um usuário específico
    /// </summary>
    /// <param name="IdUsuario">Id do usuário para filtragem</param>
    /// <returns>Lista de presenças de um usuário</returns>
    public List<Presenca> ListarMinhas(Guid IdUsuario)
    {
        return _context.Presencas
            .Include(p => p.IdEventoNavigation)
            .ThenInclude(e => e!.IdInstituicaoNavigation)
            .Where(p => p.IdUsuario == IdUsuario)
            .ToList();
    }
}
