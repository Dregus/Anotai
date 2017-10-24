using Anotai.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Anotai.Models
{
    public class Repositorio
    {
        private AnotaiContext _context;

        public Repositorio()
        {
            _context = new AnotaiContext();
        }

        public void IncluirNoticia(Noticia n)
        {
            _context.Noticias.Add(n);
            _context.SaveChanges();
        }

        public Noticia ListarNoticia(int codigo)
        {
            return _context.Noticias.Where(n => n.NoticiaId == codigo).First();
        }

        public Pacote ListarPacote(int codigo)
        {
            return _context.Pacotes.Where(n => n.PacoteId == codigo).First();
        }

        public void ExcluirNoticia(int codigo)
        {
            _context.Noticias.Remove(ListarNoticia(codigo));
            _context.SaveChanges();
        }

        public void ExcluirPacote(int codigo)
        {
            _context.Pacotes.Remove(ListarPacote(codigo));
            _context.SaveChanges();
        }

        public IEnumerable<Noticia> ListarNoticias()
        {
            return _context.Noticias.ToList();
        }

        public IEnumerable<Contato> ListarContatos()
        {
            return _context.Contatos.ToList();
        }

        public IEnumerable<Usuario> ListarUsuarios()
        {
            return _context.Usuarios.ToList();
        }

        public IEnumerable<Usuario> PesquisarUsuario(HomeViewModel hvm)
        {
            return _context.Usuarios.Where(u =>
                u.Nome == hvm.Usuario.Nome ||
                u.Sobrenome == hvm.Usuario.Sobrenome ||
                u.Telefone == hvm.Usuario.Telefone ||
                u.Email == hvm.Usuario.Email ||
                u.Endereco == hvm.Usuario.Endereco)
                .ToList();
        }

        public IEnumerable<Contato> PesquisarContato(HomeViewModel hvm)
        {
            return _context.Contatos.Where(c =>
                c.Nome == hvm.Contato.Nome ||
                c.Sobrenome == hvm.Contato.Sobrenome ||
                c.Telefone == hvm.Contato.Telefone ||
                c.Email == hvm.Contato.Email ||
                c.Mensagem == hvm.Contato.Mensagem)
                .ToList();
        }

        public IEnumerable<Pacote> PesquisarPacote(HomeViewModel hvm)
        {
            return _context.Pacotes.Where(c =>
                c.Titulo == hvm.Pacote.Titulo ||
                c.Descricao == hvm.Pacote.Descricao ||
                c.Preco == hvm.Pacote.Preco ||
                c.QtdTotal == hvm.Pacote.QtdTotal ||
                c.QtdDisponivel == hvm.Pacote.QtdDisponivel)
                .ToList();
        }

        public Usuario GetNomeUsuario(int id)
        {
            return _context.Usuarios.Where(u => 
                u.UsuarioId == id)
                .First();
        }
    }
}