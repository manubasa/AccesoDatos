using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIPlaceMyBet.Models
{
    public class Apuesta
    {
        public Apuesta(int id, string email_user, int id_mercado, string tipo_apuesta, float cuota, float apuesta, string fecha)
        {
            Id = id;
            this.email_user = email_user;
            Id_mercado = id_mercado;
            this.tipo_apuesta = tipo_apuesta;
            this.cuota = cuota;
            this.apuesta = apuesta;
            this.fecha = fecha;
        }

        public int Id { get; set; }
        public string email_user { get; set; }
        public int Id_mercado { get; set; }
        public string tipo_apuesta { get; set; }
        public float cuota { get; set; }
        public float apuesta { get; set; }
        public string fecha { get; set; }
    }

    public class ApuestaDTO
    {
        public ApuestaDTO(string email_user, string tipo_apuesta, float cuota, float apuesta, string fecha)
        {
         
            this.email_user = email_user; 
            this.tipo_apuesta = tipo_apuesta;
            this.cuota = cuota;
            this.apuesta = apuesta;
            this.fecha = fecha;
        }

         
        public string email_user { get; set; } 
        public string tipo_apuesta { get; set; }
        public float cuota { get; set; }
        public float apuesta { get; set; }
        public string fecha { get; set; }
    }
}