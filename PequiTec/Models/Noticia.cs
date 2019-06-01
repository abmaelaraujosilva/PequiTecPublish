using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PequiTec.Models
{
    public class Noticia
    {
        public int ID_Noticia { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public DateTime Data_Noticia { get; set; }
        public string Anexo { get; set; }
    }
}