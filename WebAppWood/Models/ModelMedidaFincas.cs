using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppWood.Models
{
    public class ModelMedidaFincas
    {
        public int id { get; set; }
        public string Finca { get; set; }
        public string Ubicacion { get; set; }
        public string Responsable { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public int Talla1 { get; set; }
        public int Talla2 { get; set; }
        public int Talla3 { get; set; }
        public double TotalTalla1 { get; set; }
        public double TotalTalla2 { get; set; }
        public double TotalTalla3 { get; set; }
        public int TotalPalos { get; set; }
        public double TotalM3 { get; set; }
        public List<ModelPalos> Lista { set; get; }
        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public int CreateCompra(ModelMedidaFincas Compra)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "INSERT INTO dbo.Compras(Finca,Ubicacion,Responsable,Tipo,Fecha,Talla1,Talla2,Talla3,TotalTalla1,TotalTalla2,TotalTalla3,TotalPalos,TotalM3)" +
            "VALUES(@Finca, @Ubicacion, @Responsable, @Tipo, @Fecha, @Talla1, @Talla2, @Talla3, @TotalTalla1, @TotalTalla2, @TotalTalla3, @TotalPalos, @TotalM3)"
            + "SELECT @@idENTITY AS[@@idENTITY]";
            ins.Parameters.AddWithValue("@Finca", Compra.Finca);
            ins.Parameters.AddWithValue("@Ubicacion", Compra.Ubicacion);
            ins.Parameters.AddWithValue("@Responsable", Compra.Responsable);
            ins.Parameters.AddWithValue("@Fecha", Compra.Fecha);
            ins.Parameters.AddWithValue("@Tipo", Compra.Tipo);
            ins.Parameters.AddWithValue("@Talla1", 0);
            ins.Parameters.AddWithValue("@Talla2", 0);
            ins.Parameters.AddWithValue("@Talla3", 0);
            ins.Parameters.AddWithValue("@TotalTalla1", 0);
            ins.Parameters.AddWithValue("@TotalTalla2", 0);
            ins.Parameters.AddWithValue("@TotalTalla3", 0);
            ins.Parameters.AddWithValue("@TotalPalos", 0);
            ins.Parameters.AddWithValue("@TotalM3", 0);
            ins.Connection = connection;
            connection.Open();
            int id = 0;
            SqlDataReader read = ins.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    id = Convert.ToInt32(read["@@IDENTITY"]);

                }
            }
            //ins.ExecuteNonQuery();
            connection.Close();
            return id;
        }
        public void EditCompra(ModelMedidaFincas Compra)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "UPDATE dbo.Compras SET Finca = @Finca,Ubicacion = @Ubicacion,Responsable = @Responsable,Tipo = @Tipo,Fecha = @Fecha,Talla1 = @Talla1,Talla2 = @Talla2,Talla3 = @Talla3,TotalTalla1 = @TotalTalla1," +
            " TotalTalla2 = @TotalTalla2,TotalTalla3 = @TotalTalla3,TotalPalos = @TotalPalos,TotalM3 = @TotalM3  WHERE id =@id";
            ins.Parameters.AddWithValue("@Finca", Compra.Finca);
            ins.Parameters.AddWithValue("@Ubicacion", Compra.Ubicacion);
            ins.Parameters.AddWithValue("@Responsable", Compra.Responsable);
            ins.Parameters.AddWithValue("@Fecha", Compra.Fecha);
            ins.Parameters.AddWithValue("@Tipo", Compra.Tipo);
            ins.Parameters.AddWithValue("@Talla1", Compra.Talla1);
            ins.Parameters.AddWithValue("@Talla2", Compra.Talla2);
            ins.Parameters.AddWithValue("@Talla3", Compra.Talla3);
            ins.Parameters.AddWithValue("@TotalTalla1", Compra.TotalTalla1);
            ins.Parameters.AddWithValue("@TotalTalla2", Compra.TotalTalla2);
            ins.Parameters.AddWithValue("@TotalTalla3", Compra.TotalTalla3);
            ins.Parameters.AddWithValue("@TotalPalos", Compra.TotalPalos);
            ins.Parameters.AddWithValue("@TotalM3", Compra.TotalM3);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public void UpdateValores(ModelMedidaFincas Compra)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "UPDATE dbo.Compras SETTalla1 = @Talla1,Talla2 = @Talla2,Talla3 = @Talla3,TotalTalla1 = @TotalTalla1,TotalTalla2 = @TotalTalla2,TotalTalla3 = @TotalTalla3,TotalPalos = @TotalPalos,TotalM3 = @TotalM3"+
                "  WHERE id =@id";
            ins.Parameters.AddWithValue("@Talla1", Compra.Talla1);
            ins.Parameters.AddWithValue("@Talla2", Compra.Talla2);
            ins.Parameters.AddWithValue("@Talla3", Compra.Talla3);
            ins.Parameters.AddWithValue("@TotalTalla1", Compra.TotalTalla1);
            ins.Parameters.AddWithValue("@TotalTalla2", Compra.TotalTalla2);
            ins.Parameters.AddWithValue("@TotalTalla3", Compra.TotalTalla3);
            ins.Parameters.AddWithValue("@TotalPalos", Compra.TotalPalos);
            ins.Parameters.AddWithValue("@TotalM3", Compra.TotalM3);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public ModelMedidaFincas ComprasDetails(int id)
        {
            ModelMedidaFincas Compra = new ModelMedidaFincas();
            SqlCommand sel = new SqlCommand("Select * from dbo.Compras where Id=@Id");
            sel.Parameters.AddWithValue("@Id", id);
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    Compra.id = Convert.ToInt32(read["id"]);
                    Compra.Finca = read["Finca"].ToString();
                    Compra.Ubicacion = read["Ubicacion"].ToString();
                    Compra.Responsable = read["Responsable"].ToString();
                    Compra.Fecha = Convert.ToDateTime(read["Fecha"]);
                    Compra.Tipo = read["Tipo"].ToString();
                }
            }
            connection.Close();
            return Compra;
        }
        public List<ModelPalos> UltimaMedida()
        {
            List<ModelPalos> List = new List<ModelPalos>();
            //SqlCommand sel = new SqlCommand("Select * from dbo.CompraDetalle");
            //sel.Connection = connection;
            //connection.Open();
            //SqlDataReader read = sel.ExecuteReader();
            //if (read.HasRows)
            //{
            //    while (read.Read())
            //    {
            //        List.Add(new ModelPalos
            //        {
            //            Numero = Convert.ToInt32(read["Compra"]),
            //            AltoMetros = Convert.ToDouble(read["AltoMetros"]),
            //            CircunferenciaCM = Convert.ToDouble("CircunferenciaCM"),
            //            Talla = (read["Talla"]).ToString(),
            //            Tipo = (read["Tipo"]).ToString(),
            //        });
            //    }
            //}
            //connection.Close();
            return List;
        }
    }

}