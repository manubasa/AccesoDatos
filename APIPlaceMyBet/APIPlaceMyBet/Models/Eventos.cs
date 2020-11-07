using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIPlaceMyBet.Models
{
    public class Eventos
    {
        public Eventos(int id, string equipo_local, string equipo_visitante, string fecha)
        {
            Id = id;
            Equipo_local = equipo_local;
            Equipo_visitante = equipo_visitante;
            Fecha = fecha;
        }

        public int Id { get; set; }
        public string Equipo_local { get; set; }
        public string Equipo_visitante { get; set; }
        public string Fecha { get; set; }
    }

    public class EventoDTO
    {
        public EventoDTO(string equipo_local, string equipo_visitante, string fecha)
        {
            
            Equipo_local = equipo_local;
            Equipo_visitante = equipo_visitante;
            Fecha = fecha;
        }
         
        public string Equipo_local { get; set; }
        public string Equipo_visitante { get; set; }
        public string Fecha { get; set; }
    }
}