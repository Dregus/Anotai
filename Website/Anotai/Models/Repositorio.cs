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

        public void ExcluirNoticia(int codigo)
        {
            _context.Noticias.Remove(ListarNoticia(codigo));
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
    }
}