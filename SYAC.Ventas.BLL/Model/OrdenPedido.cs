//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SYAC.Ventas.BLL.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrdenPedido
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrdenPedido()
        {
            this.OrdenPedidoDetalle = new HashSet<OrdenPedidoDetalle>();
        }
    
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Prioridad { get; set; }
        public string DireccionEntrega { get; set; }
        public System.DateTime FechaRegistro { get; set; }
        public decimal ValorTotal { get; set; }
        public bool Estado { get; set; }
        public string EstadoPedido { get; set; }
    
        public virtual Clientes Clientes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdenPedidoDetalle> OrdenPedidoDetalle { get; set; }
    }
}
