using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCApp.Data;
using MVCApp.Models;
using NegocioInterface;

namespace MVCApp.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly IUsuarioNegocio usuarioNegocio;

        public UsuariosController(IUsuarioNegocio _usuarioNegocio)
        {
            usuarioNegocio = _usuarioNegocio;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await usuarioNegocio.Listar();
              return usuarios != null ? 
                          View(usuarios) :
                          Problem("Entity set 'MVCAppContext.Usuario'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            var usuario = await usuarioNegocio.BuscaPorId(id);

            if (id == null || usuario == null)
            {
                return NotFound();
            }

            
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UsuarioId,Nome,Cpf,Rg,DataNascimento")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                await usuarioNegocio.Adicionar(usuario);
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var usuario = await usuarioNegocio.BuscaPorId(id);
            if (id == null || usuario == null)
            {
                return NotFound();
            }
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UsuarioId,Nome,Cpf,Rg,DataNascimento")] Usuario usuario)
        {
            if (id != usuario.UsuarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await usuarioNegocio.Editar(usuario);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.UsuarioId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var usuario = await usuarioNegocio.BuscaPorId(id);
            if (id == null || usuario == null)
            {
                return NotFound();
            }

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var usuario = await usuarioNegocio.BuscaPorId(id);    
            if (usuario == null)
            {
                return Problem("Entity set 'MVCAppContext.Usuario'  is null.");
            }

            if (usuario != null)
            {
                await usuarioNegocio.Remover(usuario);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return usuarioNegocio.UsuarioExists(id);
        }
    }
}
