using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAppWood.Models;
using WebAppWood.Models.JsonModels;

namespace WebAppWood.Controllers
{
    public class MedirController : Controller
    {
        ModelMedidaFincas Medida = new ModelMedidaFincas();
        ModelPalos arbol = new ModelPalos();
        // GET: Buy
        public ActionResult CrearMedidaFinca()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CrearMedidaFinca(FormCollection fc)
        {
            Medida.Finca = fc["Finca"];
            Medida.Ubicacion = fc["Ubicacion"];
            Medida.Responsable = fc["Responsable"];
            Medida.Fecha = Convert.ToDateTime(fc["Fecha"]);
            Medida.Tipo = fc["Tipo"];
            Medida.id=Medida.CreateCompra(Medida);
            return RedirectToAction("InsertarMedidaArboles", "Medir", new { id =Medida.id });
        }
        public ActionResult InsertarMedidaArboles(int id)
        {
            Medida = Medida.ComprasDetails(id);
            arbol.Compra = id;
            arbol.Fecha = Medida.Fecha;
            arbol.Tipo = Medida.Tipo;
            arbol.Ubicacion = Medida.Ubicacion;
            arbol.Encargado = Medida.Responsable;
            arbol.Finca = Medida.Finca;
            return View(arbol);
        }
        [HttpPost]
        public ActionResult InsertMedida(List<JsonMedida> jsonPost)
        {
            foreach (var item in jsonPost)
            {
                arbol.Compra = item.id;
                arbol.Numero = item.numero;
                arbol.Tipo = item.tipo;
                arbol.AltoMetros = item.altura;
                arbol.CircunferenciaCM = item.circunferencia;
                //arbol.Talla = calcularTalla();
                arbol.Talla = "";
                arbol.CreateCompra(arbol);
            }
            return RedirectToAction("InsertarMedidaArboles", "Medir", new { id = arbol.Compra });
        }
        public ActionResult EditBuy(int id)
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditBuy(FormCollection fc)
        {
            Medida.Finca = fc["Finca"];
            Medida.Ubicacion = fc["Ubicacion"];
            Medida.Responsable = fc["Responsable"];
            Medida.Fecha = Convert.ToDateTime(fc["Fecha"]);
            Medida.EditCompra(Medida);
            return View();
        }
        public ActionResult BuyDetails(int id)
        {
            return View();
        }
        public ActionResult BuyList()
        {
            return View();
        }

    }
}