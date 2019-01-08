using System;
using System.Web.Mvc;
using WebAppWood.Models;

namespace WebAppWood.Controllers
{
    public class CipresController : Controller
    {
        ModelCipres Cipres = new ModelCipres();
        ModelPersona Vendedor = new ModelPersona();
        // GET: Cipres
        public ActionResult InsertCipres(int id)
        {
            Vendedor = Vendedor.VendedorDetails(id);
            Cipres.Vendedor = id;
            Cipres.Nombre = Vendedor.Nombre + " " + Vendedor.Apellido1 + " " + Vendedor.Apellido2;
            Cipres.Codigo = Vendedor.Codigo;
            Cipres.Consecutivo = Vendedor.Consecutivo;
            Cipres.Cedula = Vendedor.Cedula;
            Cipres.FechaIngreso = Convert.ToDateTime(TempData["Fecha"]);

            if (Cipres.FechaIngreso.ToShortDateString().Equals("1/1/0001") != true)
            {
                Cipres.ListaCipres = Cipres.ListaInsertadosHoy(Convert.ToDateTime(TempData["Fecha"]), Cipres.Codigo);
            }
            else { Cipres.FechaIngreso = DateTime.Now; }
            return View(Cipres);
        }
        [HttpPost]
        public ActionResult InsertCipres(FormCollection fc)
        {
            Cipres.Vendedor = Convert.ToInt32(fc["id"]);
            Cipres.Nombre = fc["Nombre"];
            Cipres.Codigo = fc["Codigo"];
            Cipres.Cedula = fc["Cedula"];
            int cont = Convert.ToInt32(fc["Consecutivo"]);
            Cipres.FechaIngreso = Convert.ToDateTime(fc["Fecha"]);
            Cipres.Codigo = (fc["Codigo"]);
            Cipres.Consecutivo = cont + 1;
            Cipres.LargoPulgadas1 = Convert.ToDouble(fc["LargoPulgadas1"]);
            Cipres.Cruz1 = Convert.ToDouble(fc["Cruz1"]);
            Cipres.Cruz2 = Convert.ToDouble(fc["Cruz2"]);
            Cipres.D1 = Convert.ToDouble(fc["D1"]);
            Cipres.LargoMetrosBruto1 = Convert.ToDouble(fc["LargoMetrosBruto1"]);
            Cipres.LargoMetrosNetos1 = 2.5;
            if (fc["D2"].Equals("") == false) { Cipres.D2 = Convert.ToDouble(fc["D2"]); } else { Cipres.LargoMetrosBruto2 = 0.0; }
            if (fc["D3"].Equals("") == false) { Cipres.D3 = Convert.ToDouble(fc["D3"]); } else { Cipres.LargoMetrosBruto2 = 0.0; }
            if (fc["LargoMetrosBruto2"].Equals("") == false) { Cipres.LargoMetrosBruto2 = Convert.ToDouble(fc["LargoMetrosBruto2"]); } else { Cipres.LargoMetrosBruto2 = 0.0; }
            if (fc["LargoMetrosBruto3"].Equals("") == false) { Cipres.LargoMetrosBruto3 = Convert.ToDouble(fc["LargoMetrosBruto3"]); } else { Cipres.LargoMetrosBruto3 = 0.0; }
            if (fc["LargoPulgadas2"].Equals("") == false) { Cipres.LargoPulgadas2 = Convert.ToDouble(fc["LargoPulgadas2"]); } else { Cipres.LargoPulgadas2 = 0.0; }
            if (fc["LargoPulgadas3"].Equals("") == false) { Cipres.LargoPulgadas3 = Convert.ToDouble(fc["LargoPulgadas3"]); } else { Cipres.LargoPulgadas3 = 0.0; }
            if (Cipres.LargoPulgadas2 != 0.0) { Cipres.LargoMetrosNetos2 = 5; } else { Cipres.LargoMetrosNetos2 = 0.0; }
            if (Cipres.LargoPulgadas3 != 0.0) { Cipres.LargoMetrosNetos3 = 7.5; } else { Cipres.LargoMetrosNetos3 = 0.0; }
            InsertTroza(Cipres);
            TempData["Fecha"] = Cipres.FechaIngreso;
            Vendedor.UpdateConsecutivo(Cipres.Consecutivo, Cipres.Vendedor);
            return RedirectToAction("InsertCipres", "Cipres", new { id = Cipres.Vendedor });
        }
        public ActionResult ListCipres()
        {
            return View(Cipres.ListTrozas());
        }
        public ActionResult DetailWood(int id)
        {
            return View(Cipres.TrozasDetails(id));
        }
        /*------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        public void InsertTroza(ModelCipres troza)
        {

            Cipres.PMT1 = GetPMT(Cipres.LargoPulgadas1);
            Cipres.PMT2 = GetPMT(Cipres.LargoPulgadas2);
            Cipres.PMT3 = GetPMT(Cipres.LargoPulgadas3);
            Cipres.SmalianNeto1 = ConvertToSmalian(Cipres.D1, Cipres.LargoMetrosNetos1);
            Cipres.SmalianNeto2 = ConvertToSmalian(Cipres.D2, Cipres.LargoMetrosNetos2);
            Cipres.SmalianNeto3 = ConvertToSmalian(Cipres.D3, Cipres.LargoMetrosNetos3);
            Cipres.DiametroPromedio = GetDiametroPromedio(Cipres.D1, Cipres.D2, Cipres.D3);
            Cipres.Talla1 = GetTallaVenta(Cipres.LargoPulgadas1);
            Cipres.Talla2 = GetTallaVenta(Cipres.LargoPulgadas2);
            Cipres.Talla3 = GetTallaVenta(Cipres.LargoPulgadas3);
            Cipres.TallaD1 = GetTallaCompra(Cipres.D1);
            Cipres.TallaD2 = GetTallaCompra(Cipres.D2);
            Cipres.TallaD3 = GetTallaCompra(Cipres.D3);
            Cipres.TotalLargos = (Cipres.LargoPulgadas1 + Cipres.LargoPulgadas2 + Cipres.LargoPulgadas3);
            Cipres.CreateTroza(Cipres);
        }
        public string GetTallaVenta(double Largos)
        {
            if (7 <= Largos && Largos < 9)
            {
                return "Amarillo";
            }
            else if (9 <= Largos && Largos <= 9.5)
            {
                return "Naranja";
            }
            else if (9.6 <= Largos && Largos < 15)
            {
                return "Verde";
            }
            else if (15 <= Largos)
            {
                return "Azul";
            }
            return "";
        }
        public string GetTallaCompra(double Largos)
        {
            if (0.250 <= Largos && Largos < 0.260)
            {
                return "Amarillo";
            }
            else if (0.260 <= Largos && Largos < 0.300)
            {
                return "Naranja";
            }
            else if (0.300 <= Largos && Largos < 0.500)
            {
                return "Verde";
            }
            else if (0.500 <= Largos)
            {
                return "Azul";
            }
            return "";
        }
        public double GetPMT(double largo)
        {
            return (Math.Pow(largo, 2) * 0.75);
        }
        public double ConvertToSmalian(double dm, double largo)
        {
            return (Math.Pow(dm, 2) * largo) * 0.7854;
        }
        public double GetDiametro(double largo)
        {
            return (((Math.Pow(largo, 2) * 2.54) / 3.15) / 100);
        }
        public double GetDiametroPromedio(double dm1, double dm2, double dm3)
        {
            if (dm2 == 0.0)
            {
                return dm1;
            }
            else if (dm2 != 0.0 && dm3 == 0.0)
            {
                return (dm1 + dm2) / 2;
            }
            return (dm1 + dm2 + dm3) / 3;

        }
        public void insertDataLog(string username, string table, string data)
        {

        }
    }
}