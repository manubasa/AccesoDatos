using APIPlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIPlaceMyBet.Controllers
{
    public class UsuariosController : ApiController
    {
        // GET: api/usuarios
        public IEnumerable<Usuario> Get()
        {
            return new UsuarioRepository().GetUsuario();
        }

        // GET: api/usuarios/5
        public Usuario Get(int id)
        {
            var repo = new UsuarioRepository();

            return new Usuario("asd@asda","asdas",",adas",33) ;
        }

        // POST: api/usuarios
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/usuarios/5
        public void Delete(int id)
        {
        }
    }
}
