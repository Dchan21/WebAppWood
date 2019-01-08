using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppWood.Models.JsonModels
{
    public class ModelDashboard
    {
        public ModelCipres Cipres = new ModelCipres();
        public ModelOtherWood GMelina = new ModelOtherWood();
        public ModelOtherWood Pino = new ModelOtherWood();
        public ModelOtherWood Teca = new ModelOtherWood();
        public ModelPersona Vendedor = new ModelPersona();
        public ModelPersona Comprador = new ModelPersona();
        public ModelContainer Contenedor = new ModelContainer();
        public ModelMedidaFincas Medida = new ModelMedidaFincas();
        public ModelBuy Compra = new ModelBuy();
        public ModelVenta Venta = new ModelVenta();
        public List<ModelCipres> ListaCipres = new List<ModelCipres>();
        public List<ModelOtherWood> ListaGMelina = new List<ModelOtherWood>();
        public List<ModelOtherWood> ListaPino = new List<ModelOtherWood>();
        public List<ModelOtherWood> ListaTeca = new List<ModelOtherWood>();
        public List<ModelPersona> ListaVendedor = new List<ModelPersona>();
        public List<ModelPersona> ListaComprador = new List<ModelPersona>();
        public List<ModelContainer> ListaContenedor = new List<ModelContainer>();
        public List<ModelPalos> ListaMedidas = new List<ModelPalos>();
        public List<ModelBuy> ListaCompras = new List<ModelBuy>();
        public List<ModelVenta> ListaVentas = new List<ModelVenta>();
    }
}