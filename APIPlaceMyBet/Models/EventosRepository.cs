using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace APIPlaceMyBet.Models
{
    public class EventosRepository
    {
        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Database=db_placemybet;uid=root;pwd=;";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Eventos> GetEventos()
        {
            List<Eventos> eventos = new List<Eventos>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM eventos";
            try
            {

      
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                int id = reader.GetInt32(0);
                string equipo_local = reader.GetString(1);
                string equipo_visitante = reader.GetString(2);
                string fecha = reader.GetString(3);
                eventos.Add(new Eventos(id, equipo_local, equipo_visitante, fecha));
            }
            con.Close();
            } catch(Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return eventos;
        }
        internal List<EventoDTO> GetEventosDTO()
        {
            List<EventoDTO> eventos = new List<EventoDTO>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * FROM eventos";
            try { 
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 
                string equipo_local = reader.GetString(1);
                string equipo_visitante = reader.GetString(2);
                string fecha = reader.GetString(3);
                eventos.Add(new EventoDTO(equipo_local, equipo_visitante, fecha));
            }
            con.Close();
         } catch(Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return eventos;
        }
    }
}
 