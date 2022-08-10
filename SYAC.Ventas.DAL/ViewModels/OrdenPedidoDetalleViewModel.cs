using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYAC.Ventas.DAL.ViewModels
{
    public class OrdenPedidoDetalleViewModel
    {
        public int Id { get; set; }
        public int IdOrdenPedido { get; set; }
        public int IdProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal ValorParcial { get; set; }
        public bool Estado { get; set; }

        public string Producto { get; set; }    
    }
}
