using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppWood.Models
{
    public class ModelBuy
    {
        public int id { get; set; }
        public string Vendedor { get; set; }
        public double TallaPMT { get; set; }
        public double Cantidad { get; set; }
        public double MontoTalla { get; set; }
        public string Categorias { get; set; }
        public DateTime FechaCreacion { get; set; }
        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);

        public void CreateCompra(ModelBuy Compra)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "INSERT INTO dbo.CompraDetalle(Vendedor,FechaCreacion,TallaPMT,CantidadTrozas,Categorias,MontoTalla)" +
            "VALUES(@Vendedor,@FechaCreacion,@TallaPMT,@CantidadTrozas,@Categorias,@MontoTalla)";
            ins.Parameters.AddWithValue("@Vendedor", Compra.Vendedor);
            ins.Parameters.AddWithValue("@FechaCreacion", Compra.FechaCreacion);
            ins.Parameters.AddWithValue("@TallaPMT", Compra.TallaPMT);
            ins.Parameters.AddWithValue("@CantidadTrozas", Compra.Cantidad);
            ins.Parameters.AddWithValue("@MontoTalla", Compra.MontoTalla);
            ins.Parameters.AddWithValue("@Categorias", Compra.Categorias);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public ModelBuy CompraDetails(int id)
        {
            ModelBuy Compra = new ModelBuy();
            SqlCommand sel = new SqlCommand("Select * from dbo.CompraDetalle where Id=@Id");
            sel.Parameters.AddWithValue("@Id", id);
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    Compra.id = Convert.ToInt32(read["Id"]);
                    Compra.Vendedor = (read["Vendedor"]).ToString();
                    Compra.FechaCreacion = DateTime.Now;
                    Compra.TallaPMT = Convert.ToDouble(read["TallaPMT"]);
                    Compra.Cantidad = Convert.ToInt32(read["CantidadTrozas"]);
                    Compra.MontoTalla = Convert.ToDouble(read["MontoTalla"]);
                    Compra.Categorias = (read["Categorias"]).ToString();
                }
            }
            connection.Close();
            return Compra;
        }
        public void EditCompra(ModelBuy Compra)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "UPDATE dbo.CompraDetalle SET Vendedor = @Vendedor,FechaCreacion = @FechaCreacion,TallaPMT = @TallaPMT,CantidadTrozas = @CantidadTrozas,MontoTalla = @MontoTalla ,Categorias = @Categorias WHERE id = @id)";
            ins.Parameters.AddWithValue("@Vendedor", Compra.Vendedor);
            ins.Parameters.AddWithValue("@FechaCreacion", Compra.FechaCreacion);
            ins.Parameters.AddWithValue("@TallaPMT", Compra.TallaPMT);
            ins.Parameters.AddWithValue("@CantidadCompra", Compra.Cantidad);
            ins.Parameters.AddWithValue("@MontoTalla", Compra.MontoTalla);
            ins.Parameters.AddWithValue("@Categorias", Compra.Categorias);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public List<ModelBuy> ListCompra()
        {
            List<ModelBuy> List = new List<ModelBuy>();
            SqlCommand sel = new SqlCommand("Select * from dbo.CompraDetalle");
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelBuy
                    {
                        id = Convert.ToInt32(read["Id"]),
                        Vendedor = (read["Vendedor"]).ToString(),
                        FechaCreacion = DateTime.Now,
                        TallaPMT = Convert.ToDouble(read["TallaPMT"]),
                        Cantidad = Convert.ToInt32(read["CantidadTrozas"]),
                        MontoTalla = Convert.ToDouble(read["MontoTalla"]),
                        Categorias = (read["Categorias"]).ToString(),
                    });
                }
            }
            connection.Close();
            return List;
        }
    }
}