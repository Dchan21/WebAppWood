using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppWood.Models;


namespace WebAppWood.Controllers
{
    public class WoodController : Controller
    {
        ModelPersona vendedor = new ModelPersona();
        public ActionResult InsertTroza()
        {
            return View(vendedor.ListPersonasVendedores());
        }
        [HttpPost]
        public ActionResult InsertTroza(FormCollection fc)
        {
            int tipo = Convert.ToInt32(fc["Tipo"]);
            int idvendedor = Convert.ToInt32(fc["Vendedor"]);
            if (tipo == 1)
            {
                return RedirectToAction("InsertCipres", "Cipres", new { id = idvendedor });
            }
            else if (tipo == 2)
            {
                return RedirectToAction("InsertTroza", "Otros", new { id = tipo, vendedor = idvendedor });
            }
            else if (tipo == 3)
            {
                return RedirectToAction("InsertTroza", "Otros", new { id = tipo, vendedor = idvendedor });
            }
            else if (tipo == 4)
            {
                return RedirectToAction("InsertTroza", "Otros", new { id = tipo, vendedor = idvendedor });
            }
            return View(vendedor.ListPersonasVendedores());
        }

        /*---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------*/

        //public double ConvertToHoppus(ModelCipres wood)
        //{
        //    double talla = 0.0;
        //    talla = ((wood.Diametro1 * wood.Diametro1) * wood.Largos) / 160.000;
        //    return talla;
        //}
        public double ConvertToVaras(double cm)
        {
            return cm / 64;
        }
        public double ConvertToCm(double varas)
        {
            return varas * 64;
        }

    }
}