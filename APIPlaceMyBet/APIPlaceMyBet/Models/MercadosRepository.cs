using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace APIPlaceMyBet.Models
{
    public class MercadosRepository
    {


        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Database=db_placemybet;uid=root;pwd=;";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Mercado> GetMercados()
        {
            List<Mercado> mercados = new List<Mercado>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from mercados";
            try { 
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
            
                int id = reader.GetInt32(0);
                int id_evento = reader.GetInt32(1);
                float over_under = reader.GetFloat(2);
                float over_cuota = reader.GetFloat(3);
                float under_cuota = reader.GetFloat(4);
                float over_dinero = reader.GetFloat(5);
                float under_dinero = reader.GetFloat(6);
                mercados.Add(new Mercado(id,id_evento,over_under,over_cuota,under_cuota,over_dinero,under_dinero));
            }
            con.Close();
        } catch(Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return mercados;
        }
        internal List<Mercado> GetMercadosPorEvento(int evento)
        {
            List<Mercado> mercados = new List<Mercado>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from mercados where id_evento = @Evento";
            command.Parameters.AddWithValue("@Evento", evento);
            try
            {
                con.Open();
                MySqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {

                    int id = reader.GetInt32(0);
                    int id_evento = reader.GetInt32(1);
                    float over_under = reader.GetFloat(2);
                    float over_cuota = reader.GetFloat(3);
                    float under_cuota = reader.GetFloat(4);
                    float over_dinero = reader.GetFloat(5);
                    float under_dinero = reader.GetFloat(6);
                    mercados.Add(new Mercado(id, id_evento, over_under, over_cuota, under_cuota, over_dinero, under_dinero));
                }
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return mercados;
        }

        internal List<MercadoDTO> GetMercadosDTO()
        {
            List<MercadoDTO> mercados = new List<MercadoDTO>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from mercados";
            try { 
            con.Open();
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                 
                float over_under = reader.GetFloat(2);
                float over_cuota = reader.GetFloat(3);
                float under_cuota = reader.GetFloat(4); 
                mercados.Add(new MercadoDTO(over_under, over_cuota, under_cuota));
            }
            con.Close();
        } catch(Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return mercados;
        }
    }
}