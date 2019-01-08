using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppWood.Models.JsonModels;

namespace WebAppWood.Controllers
{
    public class DashboardController : Controller
    {
        ModelDashboard Data = new ModelDashboard();
        // GET: Dashboard
        public ActionResult Dashboard()
        {
            Data.ListaCipres = Data.Cipres.ListaInsertadosUltima();
            Data.ListaGMelina = Data.GMelina.ListaGMelinaUltima();
            Data.ListaPino = Data.Pino.ListaPinoUltima();
            Data.ListaTeca = Data.Teca.ListaTecaUltima();
            Data.ListaMedidas = Data.Medida.UltimaMedida();
            return View(Data);
        }
    }
}