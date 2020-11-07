using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIPlaceMyBet.Models
{
    public class Mercado
    {
        public Mercado(int id, int id_Evento, float over_under, float cuota_over, float cuota_under, float dinero_over, float dinero_under)
        {
            Id = id;
            Id_Evento = id_Evento;
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under;
            Dinero_over = dinero_over;
            Dinero_under = dinero_under;
        }

        public int Id { get; set; }
        public int Id_Evento { get; set; }
        public float Over_under { get; set; }
        public float Cuota_over { get; set; }
        public float Cuota_under { get; set; }
        public float Dinero_over { get; set; }
        public float Dinero_under { get; set; }
    }


    public class MercadoDTO
    {
        public MercadoDTO(float over_under, float cuota_over, float cuota_under)
        { 
            Over_under = over_under;
            Cuota_over = cuota_over;
            Cuota_under = cuota_under; 
        }
         
        public float Over_under { get; set; }
        public float Cuota_over { get; set; }
        public float Cuota_under { get; set; } 
    }
}