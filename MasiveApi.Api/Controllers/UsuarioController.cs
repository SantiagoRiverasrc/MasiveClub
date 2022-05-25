using MasiveApi.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasiveApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly MusicaContext _context;

        public UsuarioController(MusicaContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Usuario.ToList());
        }
        /*Ingresar datos desde el postman metodo post
         * Ejemplo:
         {
        "idUsuario": 1,
        "nombre": "Santino",
        "apellidos": "riveria",
        "email": "rivera02@hotmail.com",
        "contraseña": "432142",
        "cliente": []
        }   
        Nota: El IdUsuario tiene que ser único o sino no guarda(Esto porque es la llave primaria)
         */
        [HttpPost]
        public ActionResult Post(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public ActionResult Put(Usuario usuario)
        {
            var realUsuario = _context.Usuario.FirstOrDefault(x => x.IdUsuario == usuario.IdUsuario);
            if (realUsuario is null) return NotFound();
            realUsuario.Nombre = usuario.Nombre;
            realUsuario.Apellidos = usuario.Apellidos;
            realUsuario.Email = usuario.Email;
            realUsuario.Contraseña = usuario.Contraseña;
            _context.SaveChanges();
            return Ok(realUsuario);
        }

    }
}
