using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppWood.Models
{
    public class ModelOtherWood
    {
        public int id { get; set; }
        public int Vendedor { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public string Codigo { get; set; }
        public int Consecutivo { get; set; }
        public double LargosMetros { get; set; }
        public string Talla { get; set; }
        public double Hoppus { get; set; }
        public double Girth { get; set; }
        public int Tipo { get; set; }
        public List<ModelOtherWood> ListaOtros { get; set; }

        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        public void CreateTroza(ModelOtherWood troza)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "INSERT INTO dbo.TrozaOtros(Vendedor,Consecutivo,Codigo,FechaIngreso,LargosMetros,Talla,Hoppus,Girth,Tipo)" +
                "VALUES(@Vendedor,@Consecutivo,@Codigo,@FechaIngreso,@LargosMetros,@Talla,@Hoppus,@Girth,@Tipo)";
            ins.Parameters.AddWithValue("@Vendedor", troza.Vendedor);
            ins.Parameters.AddWithValue("@Consecutivo", troza.Consecutivo);
            ins.Parameters.AddWithValue("@Codigo", troza.Codigo);
            ins.Parameters.AddWithValue("@FechaIngreso", troza.FechaIngreso);
            ins.Parameters.AddWithValue("@LargosMetros", troza.LargosMetros);
            ins.Parameters.AddWithValue("@Talla", troza.Talla);
            ins.Parameters.AddWithValue("@Hoppus", troza.Hoppus);
            ins.Parameters.AddWithValue("@Girth", troza.Girth);
            ins.Parameters.AddWithValue("@Tipo", troza.Tipo);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public ModelOtherWood TrozasDetails(int id)
        {
            ModelOtherWood troza = new ModelOtherWood();
            SqlCommand sel = new SqlCommand("Select * from dbo.TrozaOtros where Id=@Id");
            sel.Parameters.AddWithValue("@Id", id);
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    troza.id = Convert.ToInt32(read["id"]);
                    troza.Vendedor = Convert.ToInt32(read["Vendedor"]);
                    troza.Consecutivo = Convert.ToInt32(read["Consecutivo"]);
                    troza.Codigo = (read["Codigo"]).ToString();
                    troza.FechaIngreso = Convert.ToDateTime(read["FechaIngreso"]);
                    troza.LargosMetros = Convert.ToDouble(read["LargosMetros"]);
                    troza.Talla = Convert.ToDouble(read["Talla"]).ToString() ;
                    troza.Hoppus = Convert.ToDouble(read["Hoppus"]);
                    troza.Girth = Convert.ToDouble(read["Girth"]);
                }
            }
            connection.Close();
            return troza;
        }
        public void EditTroza(ModelOtherWood troza)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "UPDATE dbo.TrozaOtros SET id = @id ,Vendedor = @Vendedor ,Consecutivo = @Consecutivo ,Codigo = @Codigo ,FechaIngreso = @FechaIngreso ,"+
                "LargosMetros = @LargosMetros ,Talla = @Talla ,Hoppus = @Hoppus ,Girth = @Girth WHERE id = @id";
            ins.Parameters.AddWithValue("@id", troza.id);
            ins.Parameters.AddWithValue("@Vendedor", troza.Vendedor);
            ins.Parameters.AddWithValue("@Consecutivo", troza.Consecutivo);
            ins.Parameters.AddWithValue("@Codigo", troza.Codigo);
            ins.Parameters.AddWithValue("@FechaIngreso", troza.FechaIngreso);
            ins.Parameters.AddWithValue("@LargosMetros", troza.LargosMetros);
            ins.Parameters.AddWithValue("@Talla", troza.Talla);
            ins.Parameters.AddWithValue("@Hoppus", troza.Hoppus);
            ins.Parameters.AddWithValue("@Girth", troza.Girth);
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public List<ModelOtherWood> ListTrozasGMelina()
        {
            List<ModelOtherWood> List = new List<ModelOtherWood>();
            SqlCommand sel = new SqlCommand("Select * from dbo.TrozaOtros where Tipo=2");
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelOtherWood
                    {
                        id = Convert.ToInt32(read["id"]),
                        Codigo = (read["Codigo"]).ToString(),
                        Consecutivo = Convert.ToInt32(read["Consecutivo"]),
                        Tipo = Convert.ToInt32(read["Tipo"]),
                        LargosMetros = Convert.ToDouble(read["LargosMetros"]),
                        Hoppus = Convert.ToDouble(read["Hoppus"]),
                        Girth = Convert.ToDouble(read["Girth"]),
                        Talla = read["Talla"].ToString(),
                        FechaIngreso = Convert.ToDateTime(read["FechaIngreso"])
                    });
                }
            }
            connection.Close();
            return List;
        }
        public List<ModelOtherWood> ListTrozasPino()
        {
            List<ModelOtherWood> List = new List<ModelOtherWood>();
            SqlCommand sel = new SqlCommand("Select * from dbo.TrozaOtros where Tipo=3");
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelOtherWood
                    {
                        id = Convert.ToInt32(read["id"]),
                        Codigo = (read["Codigo"]).ToString(),
                        Consecutivo = Convert.ToInt32(read["Consecutivo"]),
                        Tipo = Convert.ToInt32(read["Tipo"]),
                        LargosMetros = Convert.ToDouble(read["LargosMetros"]),
                        Hoppus = Convert.ToDouble(read["Hoppus"]),
                        Girth = Convert.ToDouble(read["Girth"]),
                        Talla = read["Talla"].ToString(),
                        FechaIngreso = Convert.ToDateTime(read["FechaIngreso"])
                    });
                }
            }
            connection.Close();
            return List;
        }
        public List<ModelOtherWood> ListTrozasTeca()
        {
            List<ModelOtherWood> List = new List<ModelOtherWood>();
            SqlCommand sel = new SqlCommand("Select * from dbo.TrozaOtros where Tipo=4");
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelOtherWood
                    {
                        id = Convert.ToInt32(read["id"]),
                        Codigo = (read["Codigo"]).ToString(),
                        Consecutivo = Convert.ToInt32(read["Consecutivo"]),
                        Tipo = Convert.ToInt32(read["Tipo"]),
                        LargosMetros = Convert.ToDouble(read["LargosMetros"]),
                        Hoppus = Convert.ToDouble(read["Hoppus"]),
                        Girth = Convert.ToDouble(read["Girth"]),
                        Talla = read["Talla"].ToString(),
                        FechaIngreso = Convert.ToDateTime(read["FechaIngreso"])
                    });
                }
            }
            connection.Close();
            return List;
        }
        public List<ModelOtherWood> ListaTecaUltima()
        {
            List<ModelOtherWood> List = new List<ModelOtherWood>();
            SqlCommand sel = new SqlCommand("Select* from dbo.TrozaOtros tc " +
            "inner join(select max(FechaIngreso) as MaxDate from TrozaOtros t where t.Tipo=4) tm on  tc.FechaIngreso = tm.MaxDate where tc.Tipo=4");
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelOtherWood
                    {
                        id = Convert.ToInt32(read["id"]),
                        Codigo = (read["Codigo"]).ToString(),
                        Consecutivo = Convert.ToInt32(read["Consecutivo"]),
                        Tipo = Convert.ToInt32(read["Tipo"]),
                        LargosMetros = Convert.ToDouble(read["LargosMetros"]),
                        Hoppus = Convert.ToDouble(read["Hoppus"]),
                        Girth = Convert.ToDouble(read["Girth"]),
                        Talla = read["Talla"].ToString(),
                        FechaIngreso = Convert.ToDateTime(read["FechaIngreso"])
                    });
                }
            }
            connection.Close();
            return List;
        }
        public List<ModelOtherWood> ListaPinoUltima()
        {
            List<ModelOtherWood> List = new List<ModelOtherWood>();
            SqlCommand sel = new SqlCommand("Select* from dbo.TrozaOtros tc " +
            "inner join(select max(FechaIngreso) as MaxDate from TrozaOtros t where t.Tipo=3) tm on  tc.FechaIngreso = tm.MaxDate where tc.Tipo=3");
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelOtherWood
                    {
                        id = Convert.ToInt32(read["id"]),
                        Codigo = (read["Codigo"]).ToString(),
                        Consecutivo = Convert.ToInt32(read["Consecutivo"]),
                        Tipo = Convert.ToInt32(read["Tipo"]),
                        LargosMetros = Convert.ToDouble(read["LargosMetros"]),
                        Hoppus = Convert.ToDouble(read["Hoppus"]),
                        Girth = Convert.ToDouble(read["Girth"]),
                        Talla = read["Talla"].ToString(),
                        FechaIngreso = Convert.ToDateTime(read["FechaIngreso"])
                    });
                }
            }
            connection.Close();
            return List;
        }
        public List<ModelOtherWood> ListaGMelinaUltima()
        {
            List<ModelOtherWood> List = new List<ModelOtherWood>();
            SqlCommand sel = new SqlCommand("Select* from dbo.TrozaOtros tc " +
            "inner join(select max(FechaIngreso) as MaxDate from TrozaOtros t where t.Tipo=2) tm on  tc.FechaIngreso = tm.MaxDate where tc.Tipo=2");
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelOtherWood
                    {
                        id = Convert.ToInt32(read["id"]),
                        Codigo = (read["Codigo"]).ToString(),
                        Consecutivo = Convert.ToInt32(read["Consecutivo"]),
                        Tipo = Convert.ToInt32(read["Tipo"]),
                        LargosMetros=Convert.ToDouble(read["LargosMetros"]),
                        Hoppus=Convert.ToDouble(read["Hoppus"]),
                        Girth=Convert.ToDouble(read["Girth"]),
                        Talla = read["Talla"].ToString(),
                        FechaIngreso = Convert.ToDateTime(read["FechaIngreso"])
                    });
                }
            }
            connection.Close();
            return List;
        }
        public List<ModelOtherWood> ListaInsertadosHoy(DateTime fecha, string Codigo,int tipo)
        {
            List<ModelOtherWood> List = new List<ModelOtherWood>();
            SqlCommand sel = new SqlCommand("Select * from dbo.TrozaOtros where FechaIngreso=@FechaIngreso and Codigo=@Codigo and Tipo=@Tipo");
            sel.Parameters.AddWithValue("@FechaIngreso", fecha.ToShortDateString());
            sel.Parameters.AddWithValue("@Codigo", Codigo);
            sel.Parameters.AddWithValue("@Tipo", Tipo);
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelOtherWood
                    {
                        id = Convert.ToInt32(read["id"]),
                        Codigo = (read["Codigo"]).ToString(),
                        Consecutivo = Convert.ToInt32(read["Consecutivo"]),
                        Tipo = Convert.ToInt32(read["Tipo"]),
                        LargosMetros = Convert.ToDouble(read["LargosMetros"]),
                        Hoppus = Convert.ToDouble(read["Hoppus"]),
                        Girth = Convert.ToDouble(read["Girth"]),
                        Talla = read["Talla"].ToString(),
                        FechaIngreso = Convert.ToDateTime(read["FechaIngreso"])
                    });
                }
            }
            connection.Close();
            return List;
        }

    }
}