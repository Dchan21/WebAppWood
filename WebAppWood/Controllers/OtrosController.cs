using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppWood.Models;

namespace WebAppWood.Controllers
{
    public class OtrosController : Controller
    {
        // GET: Otros
        ModelOtherWood Other = new ModelOtherWood();
        ModelPersona Vendedor = new ModelPersona();
        
        // GET: Cipres
        public ActionResult InsertTroza(int id, int vendedor)
        {
            Vendedor = Vendedor.VendedorDetails(vendedor);
            Other.Vendedor = vendedor;
            Other.Tipo = id;
            Other.Nombre = Vendedor.Nombre + " " + Vendedor.Apellido1 + " " + Vendedor.Apellido2;
            Other.Codigo = Vendedor.Codigo;
            Other.Consecutivo = Vendedor.Consecutivo;
            Other.Cedula = Vendedor.Cedula;
            Other.FechaIngreso = Convert.ToDateTime(TempData["Fecha"]);

            if (Other.FechaIngreso.ToShortDateString().Equals("1/1/0001") != true)
            {
                Other.ListaOtros = Other.ListaInsertadosHoy(Other.FechaIngreso, Other.Codigo, Other.Tipo);
            }
            else
            {
                Other.FechaIngreso = DateTime.Now;
                Other.ListaOtros = new List<ModelOtherWood>();
            }
            return View(Other);
        }
        [HttpPost]
        public ActionResult InsertTroza(FormCollection fc)
        {
            Other.Tipo = Convert.ToInt32(fc["Tipo"]);
            Other.Vendedor = Convert.ToInt32(fc["id"]);
            Other.Consecutivo = Convert.ToInt32(fc["Consecutivo"])+1;
            Other.Codigo = fc["Codigo"];
            Other.FechaIngreso = Convert.ToDateTime(fc["Fecha"]);
            Other.LargosMetros = Convert.ToDouble(fc["LargosMetros"]);
            Other.Girth = Convert.ToDouble(fc["Girth"]);
            Other.Hoppus = GetHoppus(Other.Girth, Other.LargosMetros);
            Other.Talla = GetTalla(Other.Hoppus * 100, Other.Tipo);
            TempData["Fecha"] = Other.FechaIngreso;
            Other.CreateTroza(Other);
            Vendedor.UpdateConsecutivo(Other.Consecutivo,Other.Vendedor);
            return RedirectToAction("InsertTroza", "Otros", new { id = Other.Tipo, vendedor = Other.Vendedor });
        }

        public ActionResult DetailWood(int id)
        {
            return View();
        }
        public ActionResult ListWoodGMelina()
        {
            return View(Other.ListTrozasGMelina());
        }
        public ActionResult ListWoodPino()
        {
            return View(Other.ListTrozasPino());
        }
        public ActionResult ListWoodTeca()
        {
            return View(Other.ListTrozasTeca());
        }

        /*---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/
        public double GetHoppus(double girth, double largo)
        {
            return (Math.Pow(girth, 2) * 10) / 160000;
        }
        public string GetTalla(double Hoppus, int tipo)
        {
            if (tipo == 2 || tipo == 3)
            {
                if (80 <= Hoppus && Hoppus <= 100)
                {
                    return "Amarillo";
                }
                else if (100 < Hoppus && Hoppus <= 120)
                {
                    return "Verde";
                }
                else if (120 < Hoppus)
                {
                    return "Azul";
                }

            }
            else if (tipo == 4)
            {
                if (50 <= Hoppus && Hoppus <= 59)
                {
                    return "50-59";
                }
                else if (60 <= Hoppus && Hoppus <= 69)
                {
                    return "60-69";
                }
                else if (70 <= Hoppus && Hoppus <= 79)
                {
                    return "70-79";
                }
                else if (80 <= Hoppus && Hoppus <= 89)
                {
                    return "80-89";
                }
                else if (90 <= Hoppus && Hoppus <= 99)
                {
                    return "90-99";
                }
                else if (100 <= Hoppus && Hoppus <= 109)
                {
                    return "100-109";
                }
                else if (110 <= Hoppus && Hoppus <= 119)
                {
                    return "110-119";
                }
                else if (120 <= Hoppus)
                {
                    return "120+";
                }

            }
            return "Error";

        }
    }
}