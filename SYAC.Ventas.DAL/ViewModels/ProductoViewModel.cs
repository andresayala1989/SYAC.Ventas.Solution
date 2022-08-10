using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYAC.Ventas.DAL.ViewModels
{
    public class ProductoViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public decimal ValorUnitario { get; set; }
        public bool Estado { get; set; }
        public int? Cantidad { get; set; }  
        public bool IsSelected { get; set; }
        
    }
}
