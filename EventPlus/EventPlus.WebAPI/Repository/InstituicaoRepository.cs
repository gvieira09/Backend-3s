using EventPlus.WebAPI.BdContextEvento;
using EventPlus.WebAPI.Interface;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repository;

public class InstituicaoRepository : IInstituicaoRepository
{

    private readonly EventosContext _context;

    public InstituicaoRepository(EventosContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Atualiza uma instituição usando o rastreamento automático
    /// </summary>
    /// <param name="id">id da instituição a ser atualizada</param>
    /// <param name="instituicao">Novos dados da instituição</param>
    public void Atualizar(Guid id, Instituicao instituicao)
    {
        var instituicaoBuscada = _context.Instituicaos.Find(id);

        if(instituicaoBuscada != null)
        {
            instituicaoBuscada.NomeFantasia = instituicao.NomeFantasia;
            instituicaoBuscada.Cnpj = instituicao.Cnpj;
            instituicaoBuscada.Endereco = instituicao.Endereco;

            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca uma instituição por id
    /// </summary>
    /// <param name="id">id da instituição a ser buscada</param>
    /// <returns>objeto da instituição com as informações da instituição</returns>
    public Instituicao BuscarPorId(Guid id)
    {
        return _context.Instituicaos.Find(id)!;
    }

    /// <summary>
    /// Cadastra uma nova instituição
    /// </summary>
    /// <param name="instituicao">Instituição a ser cadastrada</param>
    public void Cadastrar(Instituicao instituicao)
    {
        _context.Instituicaos.Add(instituicao);
        _context.SaveChanges();
    }

    /// <summary>
    /// Deleta uma instituição
    /// </summary>
    /// <param name="id">id da instituição a ser deletada</param>
    public void Deletar(Guid id)
    {
        var instituicaoBuscada = _context.Instituicaos.Find(id);

        if(instituicaoBuscada != null)
        {
            _context.Instituicaos.Remove(instituicaoBuscada);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Busca a lista de instituições cadastradas
    /// </summary>
    /// <returns>Uma lista de instituições</returns>
    public List<Instituicao> Listar()
    {
        return _context.Instituicaos.ToList();
    }
}
