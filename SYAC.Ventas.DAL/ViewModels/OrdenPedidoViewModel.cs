using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYAC.Ventas.DAL.ViewModels
{
    /// <summary>
    /// Viewmodel de ordenes de pedido
    /// </summary>
    public class OrdenPedidoViewModel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Prioridad { get; set; }
        public string DireccionEntrega { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Estado { get; set; }

        public string EstadoPedido { get; set; }
        public List<OrdenPedidoDetalleViewModel> lstOrdenPedidoDetalle { get; set; }
    }
}
