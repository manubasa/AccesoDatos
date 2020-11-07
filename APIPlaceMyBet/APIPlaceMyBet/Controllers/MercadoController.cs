using APIPlaceMyBet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace APIPlaceMyBet.Controllers
{
    public class MercadoController : ApiController
    {
        // GET: api/Mercado
        public IEnumerable<MercadoDTO> Get()
        {
            return new MercadosRepository().GetMercadosDTO();
        }
        // GET: api/Mercado?evento=1
        public IEnumerable<Mercado> GetNercadoEvento(int evento)
        {
            return new MercadosRepository().GetMercadosPorEvento(evento);
        }
        

        // POST: api/Mercado
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Mercado/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Mercado/5
        public void Delete(int id)
        {
        }
    }
}
