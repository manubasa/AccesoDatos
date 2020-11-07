using APIPlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIPlaceMyBet.Controllers
{
    public class ApuestaController : ApiController
    {
        // GET: api/apuestas
        public IEnumerable<ApuestaDTO> Get()
        {
            return new RepositoryApuesta().GetApuestasDTO();
        }
        // GET: api/apuestas
        public IEnumerable<ApuestaUserDTO> GetApuestaUser(string email, string type)
        {
            return new RepositoryApuesta().GetApuestasUser(email,type);
        }

        // GET: api/apuestas
        public IEnumerable<ApuestaUserMercadoDTO> GetApuestaUser(string email, int mercado)
        {
            return new RepositoryApuesta().GetApuestasUserMercado(email, mercado);
        }

        // GET: api/Apuesta/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Apuesta
        [Authorize]
        public void Post([FromBody]Apuesta apuesta)
        {
            var repo =new RepositoryApuesta();
            repo.CreateApuesta(apuesta);
        }

        // PUT: api/Apuesta/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Apuesta/5
        public void Delete(int id)
        {
        }
    }
}
