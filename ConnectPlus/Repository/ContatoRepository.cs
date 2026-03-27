using ConnectPlus.BdContextConnect;
using ConnectPlus.Models;
using ConnectPlus.WebAPI.Interfaces; 

public class ContatoRepository : IContatoRepository 
{
    private readonly ConnectContext _context;

    public ContatoRepository(ConnectContext context)
    {
        _context = context;
    }

    public Contato BuscarPorId(Guid id)
    {
        return _context.Contatos.FirstOrDefault(c => c.Id == id);
    }

    public void Cadastrar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }

    public void Atualizar(Contato contato)
    {
        var contatoBuscado = _context.Contatos.Find(contato.Id);

        if (contatoBuscado != null)
        {
            contatoBuscado.Nome = contato.Nome;
            contatoBuscado.FormaContato = contato.FormaContato;

            _context.SaveChanges();
        }
    }

    public void Deletar(Guid id)
    {
        var contato = _context.Contatos.Find(id);

        if (contato != null)
        {
            _context.Contatos.Remove(contato);
            _context.SaveChanges();
        }
    }

    public List<Contato> listar()
    {
        return _context.Contatos.ToList();
    }
}﻿
