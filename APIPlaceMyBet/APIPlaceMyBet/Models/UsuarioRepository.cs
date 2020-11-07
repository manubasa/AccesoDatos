using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace APIPlaceMyBet.Models
{
    public class UsuarioRepository
    {

        private MySqlConnection Connect()
        {
            string connString = "Server=localhost;Database=db_placemybet;uid=root;pwd=;";
            MySqlConnection con = new MySqlConnection(connString);
            return con;
        }
        internal List<Usuario> GetUsuario()
        {
            List<Usuario> usuarios = new List<Usuario>();
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            command.CommandText = "SELECT * from usuarios";
            try { 
            con.Open();
            MySqlDataReader reader =  command.ExecuteReader();
            while (reader.Read())
            {
               string email = reader.GetString(0);
                string nombre = reader.GetString(1);
                string apellidos= reader.GetString(2);
                int edad = reader.GetInt32(3);
                usuarios.Add(new Usuario(email, nombre, apellidos, edad));
            }
            con.Close();
        } catch(Exception e)
            {
                Debug.WriteLine("Error Conn");
            }
            return usuarios;
        }



        internal void RegisterUser(Usuario usuario)
        {
            MySqlConnection con = Connect();
            MySqlCommand command = con.CreateCommand();
            string sql = "INSERT INTO usuarios (email,nombre, apellidos,edad)  VALUES" +
                "('" + usuario.Email + "','" + usuario.Nombre + "','" + usuario.Apellidos + "'," + usuario.Edad+ ")";
            command.CommandText = sql;
            try
            {
                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Insert User");
            }
        }
    }
}