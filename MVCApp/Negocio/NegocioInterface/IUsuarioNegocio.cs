using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NegocioInterface
{
    public interface IUsuarioNegocio : INegocioGenerico<Usuario>
    {
        Task<List<Usuario>> Listar();
        Task<Usuario> BuscaPorId(int? id);
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Editar(Usuario usuario);
        Task<Usuario> Remover(Usuario usuario);
        bool UsuarioExists(int id);
    }
}
