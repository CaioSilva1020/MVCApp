
using Microsoft.EntityFrameworkCore;
using MVCApp.Data;
using MVCApp.Models;
using NegocioInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio : NegocioGenerico<Usuario>, IUsuarioNegocio
    {
        public async Task<List<Usuario>> Listar()
        {
            try
            {
                using (var context = new MVCAppContext())
                {
                    var usuarios = await context.Usuario.ToListAsync();
                    return usuarios;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> BuscaPorId(int? id)
        {
            try
            {
                using (var context = new MVCAppContext())
                {
                    var usuario = context.Usuario.FirstOrDefault(x => x.UsuarioId == id);
                    return usuario;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> Adicionar(Usuario usuario)
        {
            try
            {
                using (var context = new MVCAppContext())
                {
                    context.Usuario.Add(usuario);
                    context.SaveChanges();
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> Editar(Usuario usuario)
        {
            try
            {
                using (var context = new MVCAppContext())
                {
                    context.Entry(usuario).State = EntityState.Modified;
                    context.SaveChanges();
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Usuario> Remover(Usuario usuario)
        {
            try
            {
                using (var context = new MVCAppContext())
                {
                    context.Usuario.Remove(usuario);
                    context.SaveChanges();
                }
                return usuario;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool UsuarioExists(int id)
        {
            using (var context = new MVCAppContext())
            {
                return (context.Usuario?.Any(e => e.UsuarioId == id)).GetValueOrDefault();
            }
        }
    }
}
