using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppWood.Models
{
    public class ModelPalos
    {
        public string Ubicacion { get; set; }
        public string Finca { get; set; }
        public string Encargado { get; set; }
        public DateTime Fecha { get; set; }
        public int Compra { get; set; }
        public int Numero { get; set; }
        public string Tipo { get; set; }
        public double AltoMetros { get; set; }
        public double CircunferenciaCM { get; set; }
        public string Talla { get; set; }

        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public void CreateCompra(ModelPalos Arbol)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "INSERT INTO dbo.Compra_Troza(IdCompra,Numero,Tipo,AltoMetros,CircunferenciaCM,Talla) VALUES(@IdCompra,@Numero,@Tipo,@AltoMetros,@CircunferenciaCM,@Talla)";
            ins.Parameters.AddWithValue("@IdCompra", Arbol.Compra);
            ins.Parameters.AddWithValue("@Numero", Arbol.Numero);
            ins.Parameters.AddWithValue("@Tipo", Arbol.Tipo);
            ins.Parameters.AddWithValue("@AltoMetros", Arbol.AltoMetros);
            ins.Parameters.AddWithValue("@CircunferenciaCM", Arbol.CircunferenciaCM);
            ins.Parameters.AddWithValue("@Talla", Arbol.Talla);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public void EditCompra(ModelPalos Arbol)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "UPDATE dbo.Compras SET Finca = @Finca,Ubicacion = @Ubicacion,Responsable = @Responsable,Tipo = @Tipo,Fecha = @Fecha,Talla1 = @Talla1,Talla2 = @Talla2,Talla3 = @Talla3,TotalTalla1 = @TotalTalla1," +
            " TotalTalla2 = @TotalTalla2,TotalTalla3 = @TotalTalla3,TotalPalos = @TotalPalos,TotalM3 = @TotalM3  WHERE id =@id";
            ins.Parameters.AddWithValue("@IdCompra", Arbol.Compra);
            ins.Parameters.AddWithValue("@Numero", Arbol.Numero);
            ins.Parameters.AddWithValue("@Tipo", Arbol.Tipo);
            ins.Parameters.AddWithValue("@AltoMetros", Arbol.AltoMetros);
            ins.Parameters.AddWithValue("@CircunferenciaCM", Arbol.CircunferenciaCM);
            ins.Parameters.AddWithValue("@Talla", Arbol.Talla);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
       
    }
}