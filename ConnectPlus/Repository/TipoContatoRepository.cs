using ConnectPlus.Models;
using ConnectPlus.WebAPI.Interface;
using ConnectPlus.BdContextConnect;

namespace ConnectPlus.WebAPI.Repository
{
    public class TipoContatoRepository : ITipoContatoRepository
    {
        private readonly ConnectContext _context;

        public TipoContatoRepository(ConnectContext context)
        {
            _context = context;
        }

        public void Atualizar(TiposContato tipo)
        {
            var tipoBuscado = _context.TiposContatos.Find(tipo.Id);

            if (tipoBuscado != null)
            {
                tipoBuscado.Titulo = tipo.Titulo;
                _context.SaveChanges();
            }
        }

        public TiposContato BuscarPorId(Guid id)
        {
            return _context.TiposContatos.FirstOrDefault(t => t.Id == id);
        }

        public void Cadastrar(TiposContato tipo)
        {
            _context.TiposContatos.Add(tipo);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var tipo = _context.TiposContatos.Find(id);

            if (tipo != null)
            {
                _context.TiposContatos.Remove(tipo);
                _context.SaveChanges();
            }
        }

        public List<TiposContato> Listar()
        {
            return _context.TiposContatos.ToList();
        }
    }
}