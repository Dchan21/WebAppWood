using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAppWood.Models.JsonModels
{
    public class JsonMedida
    {
        [JsonProperty("id")]
        public int id { get; set; }
        [JsonProperty("tipo")]
        public string tipo { get; set; }
        [JsonProperty("numero")]
        public int numero { get; set; }
        [JsonProperty("alto")]
        public double altura { get; set; }
        [JsonProperty("circunferencia")]
        public double circunferencia { get; set; }
    }
    public class JsonListaCompra {
        public IEnumerable<JsonMedida> ListMedidaArbol { get; set; }
    }
}