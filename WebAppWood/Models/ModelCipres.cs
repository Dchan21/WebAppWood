using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebAppWood.Models
{
    public class ModelCipres
    {
        public int id { get; set; }
        public int Vendedor { get; set; }
        public string Nombre { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string Codigo { get; set; }
        public int Consecutivo { get; set; }
        public double PMT1 { get; set; }
        public double PMT2 { get; set; }
        public double PMT3 { get; set; }
        public string Talla1 { get; set; }
        public string Talla2 { get; set; }
        public string Talla3 { get; set; }
        public string TallaD1 { get; set; }
        public string TallaD2 { get; set; }
        public string TallaD3 { get; set; }
        public double Cruz1 { get; set; }
        public double Cruz2 { get; set; }
        public double D1 { get; set; }
        public double D2 { get; set; }
        public double D3 { get; set; }
        public string Tipo { get; set; }
        public double LargoPulgadas1 { get; set; }
        public double LargoPulgadas2 { get; set; }
        public double LargoPulgadas3 { get; set; }
        public double TotalLargos { get; set; }
        public double LargoMetrosNetos1 { get; set; }
        public double LargoMetrosNetos2 { get; set; }
        public double LargoMetrosNetos3 { get; set; }
        public double LargoMetrosBruto1 { get; set; }
        public double LargoMetrosBruto2 { get; set; }
        public double LargoMetrosBruto3 { get; set; }
        public double SmalianNeto1 { get; set; }
        public double SmalianNeto2 { get; set; }
        public double SmalianNeto3 { get; set; }
        public double DiametroPromedio { get; set; }
        public List<ModelCipres> ListaCipres = new List<ModelCipres>();
        SqlConnection connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        public void CreateTroza(ModelCipres troza)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "INSERT INTO dbo.TrozaCipres(" +
            "FechaIngreso,Codigo,Consecutivo,PMT1,PMT2,PMT3,LargoPulgadas1,LargoPulgadas2,LargoPulgadas3,D1,D2,D3,LargoMetrosNetos1,LargoMetrosNetos2,LargoMetrosNetos3,LargoMetrosBruto1,LargoMetrosBruto2,LargoMetrosBruto3,SmalianNeto1," +
            "SmalianNeto2,SmalianNeto3,DiametroPromedio,Talla1,Talla2,Talla3,TallaD1,TallaD2,TallaD3,Cruz1,Cruz2,Tipo)" +
            "VALUES(@FechaIngreso,@Codigo, @Consecutivo, @PMT1, @PMT2, @PMT3, @LargoPulgadas1, @LargoPulgadas2, @LargoPulgadas3, @D1, @D2, @D3, @LargoMetrosNetos1, @LargoMetrosNetos2, @LargoMetrosNetos3, @LargoMetrosBruto1, @LargoMetrosBruto2," +
            "@LargoMetrosBruto3, @SmalianNeto1, @SmalianNeto2, @SmalianNeto3, @DiametroPromedio, @Talla1, @Talla2, @Talla3, @TallaD1, @TallaD2, @TallaD3, @Cruz1, @Cruz2, @Tipo)";
            ins.Parameters.AddWithValue("@Vendedor", troza.Vendedor);
            ins.Parameters.AddWithValue("@FechaIngreso", troza.FechaIngreso.ToShortDateString());
            ins.Parameters.AddWithValue("@Codigo", troza.Codigo);
            ins.Parameters.AddWithValue("@Consecutivo", troza.Consecutivo);
            ins.Parameters.AddWithValue("@Cruz1", troza.Cruz1);
            ins.Parameters.AddWithValue("@Cruz2", troza.Cruz2);
            ins.Parameters.AddWithValue("@PMT1", Redondear(troza.PMT1));
            ins.Parameters.AddWithValue("@Tipo", "Cipres");
            if (troza.PMT2.Equals("") == true) { ins.Parameters.AddWithValue("@PMT2", 0.0); } else { ins.Parameters.AddWithValue("@PMT2", Redondear(troza.PMT2)); }
            if (troza.PMT3.Equals("") == true) { ins.Parameters.AddWithValue("@PMT3", 0.0); } else { ins.Parameters.AddWithValue("@PMT3", Redondear(troza.PMT3)); }
            if (troza.PMT1.Equals("") == true) { ins.Parameters.AddWithValue("@LargoPulgadas1", 0.0); } else { ins.Parameters.AddWithValue("@LargoPulgadas1", troza.LargoPulgadas1); }
            if (troza.PMT2.Equals("") == true) { ins.Parameters.AddWithValue("@LargoPulgadas2", 0.0); } else { ins.Parameters.AddWithValue("@LargoPulgadas2", troza.LargoPulgadas2); }
            if (troza.PMT3.Equals("") == true) { ins.Parameters.AddWithValue("@LargoPulgadas3", 0.0); } else { ins.Parameters.AddWithValue("@LargoPulgadas3", troza.LargoPulgadas3); }
            ins.Parameters.AddWithValue("@D1", troza.D1);
            if (troza.D2.Equals("") == true) { ins.Parameters.AddWithValue("@D2", 0.0); } else { ins.Parameters.AddWithValue("@D2", troza.D2); }
            if (troza.D3.Equals("") == true) { ins.Parameters.AddWithValue("@D3", 0.0); } else { ins.Parameters.AddWithValue("@D3", troza.D3); }
            ins.Parameters.AddWithValue("@LargoMetrosBruto1", troza.LargoMetrosBruto1);
            if (troza.LargoMetrosBruto2.Equals("") == true) { ins.Parameters.AddWithValue("@LargoMetrosBruto2", 0.0); } else { ins.Parameters.AddWithValue("@LargoMetrosBruto2", troza.LargoMetrosBruto2); }
            if (troza.LargoMetrosBruto3.Equals("") == true) { ins.Parameters.AddWithValue("@LargoMetrosBruto3", 0.0); } else { ins.Parameters.AddWithValue("@LargoMetrosBruto3", troza.LargoMetrosBruto3); }
            ins.Parameters.AddWithValue("@LargoMetrosNetos1", troza.LargoMetrosNetos1);
            if (troza.LargoMetrosNetos2.Equals("") == true) { ins.Parameters.AddWithValue("@LargoMetrosNetos2", 0.0); } else { ins.Parameters.AddWithValue("@LargoMetrosNetos2", troza.LargoMetrosNetos2); }
            if (troza.LargoMetrosNetos3.Equals("") == true) { ins.Parameters.AddWithValue("@LargoMetrosNetos3", 0.0); } else { ins.Parameters.AddWithValue("@LargoMetrosNetos3", troza.LargoMetrosNetos3); }
            ins.Parameters.AddWithValue("@Talla1", troza.Talla1);
            if (troza.Talla2.Equals("") == true) { ins.Parameters.AddWithValue("@Talla2", "-"); } else { ins.Parameters.AddWithValue("@Talla2", troza.Talla2); }
            if (troza.Talla3.Equals("") == true) { ins.Parameters.AddWithValue("@Talla3", "-"); } else { ins.Parameters.AddWithValue("@Talla3", troza.Talla3); }
            ins.Parameters.AddWithValue("@TallaD1", troza.TallaD1);
            if (troza.TallaD2.Equals("") == true) { ins.Parameters.AddWithValue("@TallaD2", "-"); } else { ins.Parameters.AddWithValue("@TallaD2", troza.TallaD2); }
            if (troza.TallaD3.Equals("") == true) { ins.Parameters.AddWithValue("@TallaD3", "-"); } else { ins.Parameters.AddWithValue("@TallaD3", troza.TallaD3); }
            ins.Parameters.AddWithValue("@SmalianNeto1", Redondear(troza.SmalianNeto1));
            if (troza.SmalianNeto2.Equals("") == true) { ins.Parameters.AddWithValue("@SmalianNeto2", 0.0); } else { ins.Parameters.AddWithValue("@SmalianNeto2", Redondear(troza.SmalianNeto2)); }
            if (troza.SmalianNeto3.Equals("") == true) { ins.Parameters.AddWithValue("@SmalianNeto3", 0.0); } else { ins.Parameters.AddWithValue("@SmalianNeto3", Redondear(troza.SmalianNeto3)); }
            ins.Parameters.AddWithValue("@DiametroPromedio", Redondear(troza.DiametroPromedio));
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public ModelCipres TrozasDetails(int id)
        {
            ModelCipres troza = new ModelCipres();
            SqlCommand sel = new SqlCommand("Select * from dbo.TrozaCipres where Id=@Id");
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
                    troza.FechaIngreso = Convert.ToDateTime(read["FechaIngreso"]);
                    troza.Codigo = (read["Codigo"]).ToString();
                    troza.Consecutivo = Convert.ToInt32(read["Consecutivo"]);
                    troza.PMT1 = Convert.ToDouble(read["PMT1"]);
                    troza.PMT2 = Convert.ToDouble(read["PMT2"]);
                    troza.PMT3 = Convert.ToDouble(read["PMT3"]);
                    troza.LargoPulgadas1 = Convert.ToDouble(read["LargoPulgadas1"]);
                    troza.LargoPulgadas2 = Convert.ToDouble(read["LargoPulgadas2"]);
                    troza.LargoPulgadas3 = Convert.ToDouble(read["LargoPulgadas3"]);
                    troza.D1 = Convert.ToDouble(read["D1"]);
                    troza.D2 = Convert.ToDouble(read["D2"]);
                    troza.D3 = Convert.ToDouble(read["D3"]);
                    troza.LargoMetrosNetos1 = Convert.ToDouble(read["LargoMetrosNetos1"]);
                    troza.LargoMetrosNetos2 = Convert.ToDouble(read["LargoMetrosNetos2"]);
                    troza.LargoMetrosNetos3 = Convert.ToDouble(read["LargoMetrosNetos3"]);
                    troza.LargoMetrosBruto1 = Convert.ToDouble(read["LargoMetrosBruto1"]);
                    troza.LargoMetrosBruto2 = Convert.ToDouble(read["LargoMetrosBruto2"]);
                    troza.LargoMetrosBruto3 = Convert.ToDouble(read["LargoMetrosBruto3"]);
                    troza.Talla1 = (read["Talla1"]).ToString();
                    troza.Talla2 = (read["Talla2"]).ToString();
                    troza.Talla3 = (read["Talla3"]).ToString();
                    troza.TallaD1 = (read["TallaD1"]).ToString();
                    troza.TallaD2 = (read["TallaD2"]).ToString();
                    troza.TallaD3 = (read["TallaD3"]).ToString();
                    troza.SmalianNeto1 = Convert.ToDouble(read["SmalianNeto1"]);
                    troza.SmalianNeto2 = Convert.ToDouble(read["SmalianNeto2"]);
                    troza.SmalianNeto3 = Convert.ToDouble(read["SmalianNeto3"]);
                    troza.DiametroPromedio = Convert.ToDouble(read["DiametroPromedio"]);
                }
            }
            connection.Close();
            return troza;
        }
        public void EditTroza(ModelCipres troza)
        {
            SqlCommand ins = new SqlCommand();
            ins.CommandText = "UPDATE dbo.TrozaCipres SET Codigo=@Codigo,Consecutivo=@Consecutivo,PMT1=@PMT1,PMT2=@PMT2,PMT3=@PMT3,LargoPulgadas1=@LargoPulgadas1,LargoPulgadas2=@LargoPulgadas2,LargoPulgadas3=@LargoPulgadas3,D1=@D1,D2=@D2,D3=@D3" +
                ",LargoMetrosNetos1=@LargoMetrosNetos1,LargoMetrosNetos2=@LargoMetrosNetos2,LargoMetrosNetos3=@LargoMetrosNetos3,LargoMetrosBruto1=@LargoMetrosBruto1,LargoMetrosBruto2=@LargoMetrosBruto2" +
                ",LargoMetrosBruto3=@LargoMetrosBruto3,SmalianNeto1=@SmalianNeto1,SmalianNeto2=@SmalianNeto2,SmalianNeto3=@SmalianNeto3,DiametroPromedio=@DiametroPromedio WHERE id = @id)";
            ins.Parameters.AddWithValue("@PMT1", troza.PMT1);
            if (troza.PMT2.Equals("") == true) { troza.PMT2 = 0.0; } else { ins.Parameters.AddWithValue("@PMT2", troza.PMT2); }
            if (troza.PMT3.Equals("") == true) { troza.PMT3 = 0.0; } else { ins.Parameters.AddWithValue("@PMT3", troza.PMT3); }
            ins.Parameters.AddWithValue("@LargoPulgadas1", troza.LargoPulgadas1);
            if (troza.PMT2.Equals("") == true) { troza.LargoPulgadas2 = 0.0; } else { ins.Parameters.AddWithValue("@LargoPulgadas2", troza.LargoPulgadas2); }
            if (troza.PMT3.Equals("") == true) { troza.LargoPulgadas3 = 0.0; } else { ins.Parameters.AddWithValue("@LargoPulgadas3", troza.LargoPulgadas3); }
            ins.Parameters.AddWithValue("@D1", troza.D1);
            if (troza.D2.Equals("") == true) { troza.D2 = 0.0; } else { ins.Parameters.AddWithValue("@D2", troza.D2); }
            if (troza.D3.Equals("") == true) { troza.D3 = 0.0; } else { ins.Parameters.AddWithValue("@D3", troza.D3); }
            ins.Parameters.AddWithValue("@LargoMetrosBruto1", troza.LargoMetrosBruto1);
            if (troza.LargoMetrosBruto2.Equals("") == true) { troza.LargoMetrosBruto2 = 0.0; } else { ins.Parameters.AddWithValue("@LargoMetrosBruto2", troza.LargoMetrosBruto2); }
            if (troza.LargoMetrosBruto3.Equals("") == true) { troza.LargoMetrosBruto3 = 0.0; } else { ins.Parameters.AddWithValue("@LargoMetrosBruto3", troza.LargoMetrosBruto3); }
            ins.Parameters.AddWithValue("@LargoMetrosNetos1", troza.LargoMetrosNetos1);
            if (troza.LargoMetrosNetos2.Equals("") == true) { troza.LargoMetrosNetos2 = 0.0; } else { ins.Parameters.AddWithValue("@LargoMetrosNetos2", troza.LargoMetrosNetos2); }
            if (troza.LargoMetrosNetos3.Equals("") == true) { troza.LargoMetrosNetos3 = 0.0; } else { ins.Parameters.AddWithValue("@LargoMetrosNetos3", troza.LargoMetrosNetos3); }
            ins.Parameters.AddWithValue("@Talla1", troza.Talla1);
            if (troza.Talla2.Equals("") == true) { troza.Talla2 = ""; } else { ins.Parameters.AddWithValue("@Talla2", troza.Talla2); }
            if (troza.Talla3.Equals("") == true) { troza.Talla3 = ""; } else { ins.Parameters.AddWithValue("@Talla3", troza.Talla3); }
            ins.Parameters.AddWithValue("@TallaD1", troza.TallaD1);
            if (troza.TallaD2.Equals("") == true) { troza.TallaD3 = ""; } else { ins.Parameters.AddWithValue("@TallaD2", troza.TallaD2); }
            if (troza.TallaD3.Equals("") == true) { troza.TallaD3 = ""; } else { ins.Parameters.AddWithValue("@TallaD3", troza.TallaD3); };
            ins.Parameters.AddWithValue("@SmalianNeto1", troza.SmalianNeto1);
            if (troza.SmalianNeto2.Equals("") == true) { troza.SmalianNeto2 = 0.0; } else { ins.Parameters.AddWithValue("@SmalianNeto2", troza.SmalianNeto2); }
            if (troza.SmalianNeto3.Equals("") == true) { troza.SmalianNeto3 = 0.0; } else { ins.Parameters.AddWithValue("@SmalianNeto3", Redondear(troza.SmalianNeto3)); }
            ins.Connection = connection;
            connection.Open();
            ins.ExecuteNonQuery();
            connection.Close();
        }
        public List<ModelCipres> ListTrozas()
        {
            List<ModelCipres> List = new List<ModelCipres>();
            SqlCommand sel = new SqlCommand("Select * from dbo.TrozaCipres");
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelCipres
                    {
                        id = Convert.ToInt32(read["id"]),
                        FechaIngreso = Convert.ToDateTime(read["FechaIngreso"]),
                        Codigo = (read["Codigo"]).ToString(),
                        Consecutivo = Convert.ToInt32(read["Consecutivo"]),
                        Cruz1 = Convert.ToDouble(read["Cruz1"]),
                        Cruz2 = Convert.ToDouble(read["Cruz2"]),
                        PMT1 = Convert.ToDouble(read["PMT1"]),
                        PMT2 = Convert.ToDouble(read["PMT2"]),
                        PMT3 = Convert.ToDouble(read["PMT3"]),
                        LargoPulgadas1 = Convert.ToDouble(read["LargoPulgadas1"]),
                        LargoPulgadas2 = Convert.ToDouble(read["LargoPulgadas2"]),
                        LargoPulgadas3 = Convert.ToDouble(read["LargoPulgadas3"]),
                        D1 = Convert.ToDouble(read["D1"]),
                        D2 = Convert.ToDouble(read["D2"]),
                        D3 = Convert.ToDouble(read["D3"]),
                        LargoMetrosNetos1 = Convert.ToDouble(read["LargoMetrosNetos1"]),
                        LargoMetrosNetos2 = Convert.ToDouble(read["LargoMetrosNetos2"]),
                        LargoMetrosNetos3 = Convert.ToDouble(read["LargoMetrosNetos3"]),
                        LargoMetrosBruto1 = Convert.ToDouble(read["LargoMetrosBruto1"]),
                        LargoMetrosBruto2 = Convert.ToDouble(read["LargoMetrosBruto2"]),
                        LargoMetrosBruto3 = Convert.ToDouble(read["LargoMetrosBruto3"]),
                        Talla1 = (read["Talla1"]).ToString(),
                        Talla2 = (read["Talla2"]).ToString(),
                        Talla3 = (read["Talla3"]).ToString(),
                        TallaD1 = (read["TallaD1"]).ToString(),
                        TallaD2 = (read["TallaD2"]).ToString(),
                        TallaD3 = (read["TallaD3"]).ToString(),
                        SmalianNeto1 = Convert.ToDouble(read["SmalianNeto1"]),
                        SmalianNeto2 = Convert.ToDouble(read["SmalianNeto2"]),
                        SmalianNeto3 = Convert.ToDouble(read["SmalianNeto3"]),
                        DiametroPromedio = Convert.ToDouble(read["DiametroPromedio"]),
                    });
                }
            }
            connection.Close();
            return List;
        }
        public List<ModelCipres> ListaInsertadosHoy(DateTime fecha, string Codigo)
        {
            List<ModelCipres> List = new List<ModelCipres>();
            SqlCommand sel = new SqlCommand("Select * from dbo.TrozaCipres where FechaIngreso=@FechaIngreso and Codigo=@Codigo");
            sel.Parameters.AddWithValue("@FechaIngreso", fecha);
            sel.Parameters.AddWithValue("@Codigo", Codigo);
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelCipres
                    {
                        id = Convert.ToInt32(read["id"]),
                        FechaIngreso = Convert.ToDateTime(read["FechaIngreso"]),
                        Codigo = (read["Codigo"]).ToString(),
                        Consecutivo = Convert.ToInt32(read["Consecutivo"]),
                        Cruz1 = Convert.ToDouble(read["Cruz1"]),
                        Cruz2 = Convert.ToDouble(read["Cruz2"]),
                        PMT1 = Convert.ToDouble(read["PMT1"]),
                        PMT2 = Convert.ToDouble(read["PMT2"]),
                        PMT3 = Convert.ToDouble(read["PMT3"]),
                        LargoPulgadas1 = Convert.ToDouble(read["LargoPulgadas1"]),
                        LargoPulgadas2 = Convert.ToDouble(read["LargoPulgadas2"]),
                        LargoPulgadas3 = Convert.ToDouble(read["LargoPulgadas3"]),
                        D1 = Convert.ToDouble(read["D1"]),
                        D2 = Convert.ToDouble(read["D2"]),
                        D3 = Convert.ToDouble(read["D3"]),
                        LargoMetrosNetos1 = Convert.ToDouble(read["LargoMetrosNetos1"]),
                        LargoMetrosNetos2 = Convert.ToDouble(read["LargoMetrosNetos2"]),
                        LargoMetrosNetos3 = Convert.ToDouble(read["LargoMetrosNetos3"]),
                        LargoMetrosBruto1 = Convert.ToDouble(read["LargoMetrosBruto1"]),
                        LargoMetrosBruto2 = Convert.ToDouble(read["LargoMetrosBruto2"]),
                        LargoMetrosBruto3 = Convert.ToDouble(read["LargoMetrosBruto3"]),
                        Talla1 = (read["Talla1"]).ToString(),
                        Talla2 = (read["Talla2"]).ToString(),
                        Talla3 = (read["Talla3"]).ToString(),
                        TallaD1 = (read["TallaD1"]).ToString(),
                        TallaD2 = (read["TallaD2"]).ToString(),
                        TallaD3 = (read["TallaD3"]).ToString(),
                        SmalianNeto1 = Convert.ToDouble(read["SmalianNeto1"]),
                        SmalianNeto2 = Convert.ToDouble(read["SmalianNeto2"]),
                        SmalianNeto3 = Convert.ToDouble(read["SmalianNeto3"]),
                        DiametroPromedio = Convert.ToDouble(read["DiametroPromedio"]),
                    });
                }
            }
            connection.Close();
            return List;
        }
        public List<ModelCipres> ListaInsertadosUltima()
        {
            List<ModelCipres> List = new List<ModelCipres>();
            SqlCommand sel = new SqlCommand("Select * from dbo.TrozaCipres tc " +
            "inner join(select max(FechaIngreso) as MaxDate from TrozaCipres t) tm on  tc.FechaIngreso = tm.MaxDate");
            sel.Connection = connection;
            connection.Open();
            SqlDataReader read = sel.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    List.Add(new ModelCipres
                    {
                        id = Convert.ToInt32(read["id"]),
                        FechaIngreso = Convert.ToDateTime(read["FechaIngreso"]),
                        Codigo = (read["Codigo"]).ToString(),
                        Consecutivo = Convert.ToInt32(read["Consecutivo"]),
                        Cruz1 = Convert.ToDouble(read["Cruz1"]),
                        Cruz2 = Convert.ToDouble(read["Cruz2"]),
                        PMT1 = Convert.ToDouble(read["PMT1"]),
                        PMT2 = Convert.ToDouble(read["PMT2"]),
                        PMT3 = Convert.ToDouble(read["PMT3"]),
                        LargoPulgadas1 = Convert.ToDouble(read["LargoPulgadas1"]),
                        LargoPulgadas2 = Convert.ToDouble(read["LargoPulgadas2"]),
                        LargoPulgadas3 = Convert.ToDouble(read["LargoPulgadas3"]),
                        D1 = Convert.ToDouble(read["D1"]),
                        D2 = Convert.ToDouble(read["D2"]),
                        D3 = Convert.ToDouble(read["D3"]),
                        LargoMetrosNetos1 = Convert.ToDouble(read["LargoMetrosNetos1"]),
                        LargoMetrosNetos2 = Convert.ToDouble(read["LargoMetrosNetos2"]),
                        LargoMetrosNetos3 = Convert.ToDouble(read["LargoMetrosNetos3"]),
                        LargoMetrosBruto1 = Convert.ToDouble(read["LargoMetrosBruto1"]),
                        LargoMetrosBruto2 = Convert.ToDouble(read["LargoMetrosBruto2"]),
                        LargoMetrosBruto3 = Convert.ToDouble(read["LargoMetrosBruto3"]),
                        Talla1 = (read["Talla1"]).ToString(),
                        Talla2 = (read["Talla2"]).ToString(),
                        Talla3 = (read["Talla3"]).ToString(),
                        TallaD1 = (read["TallaD1"]).ToString(),
                        TallaD2 = (read["TallaD2"]).ToString(),
                        TallaD3 = (read["TallaD3"]).ToString(),
                        SmalianNeto1 = Convert.ToDouble(read["SmalianNeto1"]),
                        SmalianNeto2 = Convert.ToDouble(read["SmalianNeto2"]),
                        SmalianNeto3 = Convert.ToDouble(read["SmalianNeto3"]),
                        DiametroPromedio = Convert.ToDouble(read["DiametroPromedio"]),
                    });
                }
            }
            connection.Close();
            return List;
        }
        public double Redondear(double numero)
        {
            double test = Math.Round(numero, 3, MidpointRounding.AwayFromZero);
            numero = test;
            return numero;
        }

    }

}