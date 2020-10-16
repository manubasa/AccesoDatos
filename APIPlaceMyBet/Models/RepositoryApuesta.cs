using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace APIPlaceMyBet.Models
{
    public class RepositoryApuesta
    {

        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Database=db_placemybet;uid=root;pwd=;";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Apuesta> GetApuestas()
        {
            List<Apuesta> apuestas = new List<Apuesta>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from apuestas";
            try { 
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {

                int id = reader.GetInt32(0);
                string user = reader.GetString(1);
                int id_mercado = reader.GetInt32(2);
                string tipo_apuesta = reader.GetString(3); 
                float cuota = reader.GetFloat(4); 
                float apuesta = reader.GetFloat(5); 
                string fecha = reader.GetString(6); 
                apuestas.Add(new Apuesta(id, user,id_mercado,tipo_apuesta,cuota,apuesta,fecha));
            }
            con.Close();
        } catch(Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return apuestas;
        }
        internal List<ApuestaDTO> GetApuestasDTO()
        {
            List<ApuestaDTO> apuestas = new List<ApuestaDTO>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from apuestas";
            try { 
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 
                string user = reader.GetString(1); 
                string tipo_apuesta = reader.GetString(3);
                float cuota = reader.GetFloat(4);
                float apuesta = reader.GetFloat(5);
                string fecha = reader.GetString(6);
                apuestas.Add(new ApuestaDTO(user,tipo_apuesta, cuota, apuesta, fecha));
            }
            con.Close();
        } catch(Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return apuestas;
        }

        internal void CreateApuesta(Apuesta apuesta)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            string sql= "INSERT INTO apuestas (email_user,id_mercado,tipo_apuesta,cuota,apuesta,fecha) VALUES" +
                "('" + apuesta.email_user + "','" + apuesta.Id_mercado + "','" + apuesta.tipo_apuesta + "'," + apuesta.cuota.ToString().Replace(',','.') + "," + apuesta.apuesta.ToString().Replace(',', '.') + ",NOW())";
            command.CommandText = sql;
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }catch(Exception e)
            {
                Debug.WriteLine("Error Insert Apuesta");
            }
        }
    }

   
}