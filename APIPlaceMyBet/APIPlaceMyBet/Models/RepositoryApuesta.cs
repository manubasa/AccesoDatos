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

        internal List<ApuestaUserDTO> GetApuestasUser(String email, String type)
        {
            List<ApuestaUserDTO> apuestas = new List<ApuestaUserDTO>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT CONCAT(E.equipo_local, '-', E.equipo_visitante) AS evt ,A.tipo_apuesta,A.cuota, A.apuesta from apuestas A INNER JOIN mercados M ON M.id = A.id_mercado INNER JOIN eventos E ON M.id_evento = E.id WHERE email_user = @EmailUser AND tipo_apuesta = @TipoApuesta";

 
            command.Parameters.AddWithValue("@EmailUser", email);
            command.Parameters.AddWithValue("@TipoApuesta", type);
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    string evento = reader.GetString(0);
                    string tipo_apuesta = reader.GetString(1);
                    float cuota = reader.GetFloat(2);
                    float apuesta = reader.GetFloat(3); 
                    apuestas.Add(new ApuestaUserDTO(evento, tipo_apuesta, cuota, apuesta));
                }
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return apuestas;
        }


        internal List<ApuestaUserMercadoDTO> GetApuestasUserMercado(String email, int mercado)
        {
            List<ApuestaUserMercadoDTO> apuestas = new List<ApuestaUserMercadoDTO>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT M.over_under, A.tipo_apuesta, A.cuota, A.apuesta FROM apuestas A INNER JOIN mercados M ON M.id = A.id_mercado WHERE A.email_user = @EmailUser AND M.id = @IdMercado";


            command.Parameters.AddWithValue("@EmailUser", email);
            command.Parameters.AddWithValue("@IdMercado", mercado);
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    float tipo_mercado = reader.GetFloat(0);
                    string tipo_apuesta = reader.GetString(1);
                    float cuota = reader.GetFloat(2);
                    float apuesta = reader.GetFloat(3);
                    apuestas.Add(new ApuestaUserMercadoDTO(tipo_mercado, tipo_apuesta, cuota, apuesta));
                }
                con.Close();
            }
            catch (Exception e)
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