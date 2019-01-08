using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppWood.Models
{
    public class ModelPersona
    {
        public int id { get; set; }
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Correo { get; set; }
        public string Codigo { get; set; }
        public int Consecutivo { get; set; }
        public string Telefono { get; set; }
        public string Celular { get; set; }
        public int Vendedor { get; set; }
        public int Comprador { get; set; }
        public string Pais { get; set; }
        public int Status { get; set; }

        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public void CreateVendedor(ModelPersona Persona)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "INSERT INTO dbo.Persona(Cedula,Nombre,Apellido1,Apellido2,Correo,Codigo,Consecutivo,Telefono,Celular,Vendedor,Comprador,Pais,Status)" +
                "VALUES(@Cedula,@Nombre,@Apellido1,@Apellido2,@Correo,@Codigo,@Consecutivo,@Telefono,@Celular,@Vendedor,@Comprador,@Pais,@Status)";
            ins.Parameters.AddWithValue("@Cedula", Persona.Cedula);
            ins.Parameters.AddWithValue("@Nombre", Persona.Nombre);
            ins.Parameters.AddWithValue("@Apellido1", Persona.Apellido1);
            ins.Parameters.AddWithValue("@Apellido2", Persona.Apellido2);
            ins.Parameters.AddWithValue("@Correo", Persona.Correo);
            ins.Parameters.AddWithValue("@Codigo", Persona.Codigo);
            ins.Parameters.AddWithValue("@Consecutivo", Persona.Consecutivo);
            ins.Parameters.AddWithValue("@Telefono", Persona.Telefono);
            ins.Parameters.AddWithValue("@Celular", Persona.Celular);
            ins.Parameters.AddWithValue("@Vendedor", 1);
            ins.Parameters.AddWithValue("@Comprador", 0);
            ins.Parameters.AddWithValue("@Pais", Persona.Pais);
            ins.Parameters.AddWithValue("@Status", 1);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public void CreateComprador(ModelPersona Persona)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "INSERT INTO dbo.Persona(Cedula,Nombre,Correo,Codigo,Consecutivo,Telefono,Celular,Vendedor,Comprador,Pais,Status)VALUES(@Cedula,@Nombre,@Correo,@Codigo,@Consecutivo,@Telefono,@Celular,@Vendedor,@Comprador,@Pais,@Status";
            ins.Parameters.AddWithValue("@Cedula", Persona.Cedula);
            ins.Parameters.AddWithValue("@Nombre", Persona.Nombre);
            ins.Parameters.AddWithValue("@Correo", Persona.Correo);
            ins.Parameters.AddWithValue("@Codigo", Persona.Codigo);
            ins.Parameters.AddWithValue("@Consecutivo", Persona.Consecutivo);
            ins.Parameters.AddWithValue("@Telefono", Persona.Telefono);
            ins.Parameters.AddWithValue("@Celular", Persona.Celular);
            ins.Parameters.AddWithValue("@Vendedor", 0);
            ins.Parameters.AddWithValue("@Comprador", 1);
            ins.Parameters.AddWithValue("@Pais", Persona.Pais);
            ins.Parameters.AddWithValue("@Status", Persona.Status);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public void EditCompradorVendedor(ModelPersona Persona)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "UPDATE Vendedor=@Vendedor WHERE id =@id";
            ins.Parameters.AddWithValue("@id", Persona.id);
            ins.Parameters.AddWithValue("@Vendedor", Persona.Vendedor);
            ins.Parameters.AddWithValue("@Comprador", Persona.Comprador);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public ModelPersona VendedorDetails(int id)
        {
            ModelPersona Persona = new ModelPersona();
            SqlCommand sel = new SqlCommand("Select * from dbo.Persona where Id=@Id and Vendedor=1");
            sel.Parameters.AddWithValue("@Id", id);
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    Persona.id = Convert.ToInt32(read["id"]);
                    Persona.Cedula = (read["Cedula"]).ToString();
                    Persona.Nombre = (read["Nombre"]).ToString();
                    Persona.Apellido1 = (read["Apellido1"]).ToString();
                    Persona.Apellido2 = (read["Apellido2"]).ToString();
                    Persona.Codigo = (read["Codigo"]).ToString();
                    Persona.Consecutivo = Convert.ToInt32(read["Consecutivo"]);
                    Persona.Correo = (read["Correo"]).ToString();
                    Persona.Telefono = (read["Telefono"]).ToString();
                    Persona.Celular = (read["Celular"]).ToString();
                    Persona.Vendedor = Convert.ToInt32(read["Vendedor"]);
                    Persona.Comprador = Convert.ToInt32(read["Comprador"]);
                    Persona.Pais = (read["Pais"]).ToString();
                    Persona.Status = Convert.ToInt32(read["Status"]);
                }
            }
            connection.Close();
            return Persona;
        }
        public ModelPersona CompradorDetails(int id)
        {
            ModelPersona Persona = new ModelPersona();
            SqlCommand sel = new SqlCommand("Select * from dbo.Persona where Id=@Id and Comprador=1");
            sel.Parameters.AddWithValue("@Id", id);
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    Persona.id = Convert.ToInt32(read["id"]);
                    Persona.Cedula = (read["Cedula"]).ToString();
                    Persona.Nombre = (read["Nombre"]).ToString();
                    Persona.Apellido1 = (read["Apellido1"]).ToString();
                    Persona.Apellido2 = (read["Apellido2"]).ToString();
                    Persona.Codigo = (read["Codigo"]).ToString();
                    Persona.Consecutivo = Convert.ToInt32(read["Consecutivo"]);
                    Persona.Correo = (read["Correo"]).ToString();
                    Persona.Telefono = (read["Telefono"]).ToString();
                    Persona.Celular = (read["Celular"]).ToString();
                    Persona.Vendedor = Convert.ToInt32(read["Vendedor"]);
                    Persona.Comprador = Convert.ToInt32(read["Comprador"]);
                    Persona.Pais = (read["Pais"]).ToString();
                    Persona.Status = Convert.ToInt32(read["Status"]);
                }
            }
            connection.Close();
            return Persona;
        }
        public int VendedorConsecutivo(int id)
        {
            SqlCommand sel = new SqlCommand("Select * from dbo.Persona where Id=@Id");
            sel.Parameters.AddWithValue("@Id", id);
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                Consecutivo = Convert.ToInt32(read["Consecutivo"]);
            }
            connection.Close();
            return Consecutivo;
        }
        public void EditPersona(ModelPersona Persona)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "UPDATE dbo.Persona SET Cedula=@Cedula,Nombre=@Nombre,Correo=@Correo,Telefono=@Telefono,Celular=@Celular,Vendedor=@Vendedor,Comprador=@Comprador,Pais=@Pais,Status=@Status" +
            "WHERE id =@id";
            ins.Parameters.AddWithValue("@id", Persona.id);
            ins.Parameters.AddWithValue("@Cedula", Persona.Cedula);
            ins.Parameters.AddWithValue("@Nombre", Persona.Nombre);
            ins.Parameters.AddWithValue("@Correo", Persona.Correo);
            ins.Parameters.AddWithValue("@Telefono", Persona.Telefono);
            ins.Parameters.AddWithValue("@Celular", Persona.Celular);
            ins.Parameters.AddWithValue("@Vendedor", Persona.Vendedor);
            ins.Parameters.AddWithValue("@Comprador", Persona.Comprador);
            ins.Parameters.AddWithValue("@Pais", Persona.Pais);
            ins.Parameters.AddWithValue("@Status", Persona.Status);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public List<ModelPersona> ListPersonasVendedores()
        {
            List<ModelPersona> List = new List<ModelPersona>();
            SqlCommand sel = new SqlCommand("Select * from dbo.Persona where Vendedor=1");
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelPersona
                    {
                        id = Convert.ToInt32(read["id"]),
                        Cedula = (read["Cedula"]).ToString(),
                        Nombre = (read["Nombre"]).ToString(),
                        Apellido1 = (read["Apellido1"]).ToString(),
                        Apellido2 = (read["Apellido2"]).ToString(),
                        Codigo = (read["Codigo"]).ToString(),
                        Consecutivo = Convert.ToInt32(read["Consecutivo"]),
                        Correo = (read["Correo"]).ToString(),
                        Telefono = (read["Telefono"]).ToString(),
                        Celular = (read["Celular"]).ToString(),
                        Vendedor = Convert.ToInt32(read["Vendedor"]),
                        Comprador = Convert.ToInt32(read["Comprador"]),
                        Pais = (read["Pais"]).ToString(),
                        Status = Convert.ToInt32(read["Status"]),
                    });
                }
            }
            connection.Close();
            return List;
        }
        public List<ModelPersona> ListPersonasComprador()
        {
            List<ModelPersona> List = new List<ModelPersona>();
            SqlCommand sel = new SqlCommand("Select * from dbo.Persona where Comprador=1");
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelPersona
                    {
                        Cedula = (read["Cedula"]).ToString(),
                        Nombre = (read["Nombre"]).ToString(),
                        Correo = (read["Correo"]).ToString(),
                        Telefono = (read["Telefono"]).ToString(),
                        Celular = (read["Celular"]).ToString(),
                        Vendedor = Convert.ToInt32(read["Vendedor"]),
                        Comprador = Convert.ToInt32(read["Comprador"]),
                        Pais = (read["Pais"]).ToString(),
                        Status = Convert.ToInt32(read["Status"]),
                    });
                }
            }
            connection.Close();
            return List;
        }
        public void UpdateConsecutivo(int consecutivo, int id)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "UPDATE dbo.Persona SET Consecutivo=@Consecutivo" +
            " WHERE id =@id";
            ins.Parameters.AddWithValue("@Consecutivo", consecutivo);
            ins.Parameters.AddWithValue("@id", id);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
    }
}