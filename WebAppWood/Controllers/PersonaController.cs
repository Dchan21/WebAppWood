using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppWood.Models;

namespace WebAppWood.Controllers
{
    public class PersonaController : Controller
    {
        ModelPersona vendedor = new ModelPersona();
        ModelPersona comprador = new ModelPersona();
        // GET: Persona
        public ActionResult CreateVendedor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateVendedor(FormCollection fc)
        {
            string test = crearCodigo();
            vendedor.Cedula = (fc["Cedula"]);
            vendedor.Nombre = (fc["Nombre"]);
            vendedor.Apellido1 = (fc["Apellido1"]);
            vendedor.Apellido2 = (fc["Apellido2"]);
            vendedor.Correo = (fc["Correo"]);
            vendedor.Codigo = crearCodigo();
            vendedor.Consecutivo = 0;
            vendedor.Telefono = (fc["Telefono"]);
            vendedor.Celular = (fc["Celular"]);
            vendedor.Pais = (fc["Pais"]);
            vendedor.CreateVendedor(vendedor);
            return View();
        }
        public ActionResult CreateComprador()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateComprador(FormCollection fc)
        {
            string test = crearCodigo();
            vendedor.Cedula = (fc["Cedula"]);
            vendedor.Nombre = (fc["Nombre"]);
            vendedor.Apellido1 = (fc["Apellido1"]);
            vendedor.Apellido2 = (fc["Apellido2"]);
            vendedor.Correo = (fc["Correo"]);
            vendedor.Codigo = crearCodigo();
            vendedor.Consecutivo = 0;
            vendedor.Telefono = (fc["Telefono"]);
            vendedor.Celular = (fc["Celular"]);
            vendedor.Pais = (fc["Pais"]);
            vendedor.CreateVendedor(vendedor);
            return View();
        }
        public ActionResult EditVendedor()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditVendedor(FormCollection fc)
        {
            return View();
        }
        public ActionResult EditComprador()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EditComprador(FormCollection fc)
        {
            return View();
        }
        public ActionResult DetalleVendedor(int id)
        {
            return View(vendedor.VendedorDetails(id));
        }
        public ActionResult DetalleComprador(int id)
        {
            return View(comprador.CompradorDetails(id));
        }
        public ActionResult ListaVendedor()
        {
            return View(vendedor.ListPersonasVendedores());
        }
        public string crearCodigo() {
            string codigo = "";
            Random rnd = new Random();
            int codelenght = 4;
            string[] letters = new string[26] { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J",
                "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};
            for (int i = 0; i < codelenght; i++)
            {
                if (i == 0) {
                    codigo = codigo + "V";
                } else { 
                codigo = codigo + "" + letters[rnd.Next(26)];
                }
            }
            return codigo;
        }
    }
}