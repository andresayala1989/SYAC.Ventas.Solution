using SYAC.Ventas.BLL.Model;
using SYAC.Ventas.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYAC.Ventas.BLL.DAO
{
    public class OrdenesDAO
    {
        #region Singleton
        /// <summary>
        /// Se crea una instancia privada para la clase OrdenesDAO.
        /// Ha sido declarada como "volatile" para asegurar que la asignación de la instancia de la variable se complete luego de que ha sido accedida.
        /// </summary>
        private static volatile OrdenesDAO instance;

        /// <summary>
        /// Permite asegurar que solo una instancia ha sido creada y solo cuando sea necesaria.
        /// En lugar de bloquearse así mismo, evita que ocurran otros bloqueos.
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// Se crea una instancia publica de la clase OrdenesDAO.
        /// Permitiendo una conexión unica y accesible por cualquiera.
        /// </summary>
        public static OrdenesDAO Instance
        {
            get
            {
                //Corrige varios erros que podrían ocurrir de no tener un único hilo.
                if (instance == null)
                {
                    //Permite un unico hilo, por lo cual se bloquea, cuando la instancia de la clase no se ha creado.
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new OrdenesDAO();
                        }
                    }
                }
                return instance;
            }
        }
        /// <summary>
        /// Constructor de la clase OrdenesDAO
        /// </summary>
        private OrdenesDAO() { }
        #endregion

        private VentasEntities _context = new VentasEntities();

        public OrdenesDAO(VentasEntities context)
        {
            _context = context;
        }
        /// <summary>
        /// Obtiene todas las ordenes
        /// </summary>
        /// <returns></returns>
        public List<OrdenPedidoViewModel> Get()
        {
            var ordenes = _context.GetAllOrdenes().Select(i => new OrdenPedidoViewModel() {
                Id = i.Id,
                Prioridad = i.Prioridad,
                Cliente = i.Nombre,
                ValorTotal = i.ValorTotal,
                EstadoPedido = i.EstadoPedido,
                FechaRegistro = i.FechaRegistro
            }).ToList();

            return ordenes;
        }
        /// <summary>
        /// obtiene todos los productos
        /// </summary>
        /// <returns></returns>
        public List<ProductoViewModel> GetProducts()
        {
            var ordenes = _context.Productos.Select(i => new ProductoViewModel()
            {
                Id = i.Id,
                Nombre = i.Nombre,
                Codigo = i.Codigo,
                Estado = i.Estado,
                ValorUnitario = i.ValorUnitario
            }).ToList();

            return ordenes;
        }
        /// <summary>
        /// /Obtiene la orden con respecto al id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public OrdenPedidoViewModel GetbyId(int id)
        {
            OrdenPedidoViewModel lstOrdenes = new OrdenPedidoViewModel();
            lstOrdenes = _context.OrdenPedido.Where(x => x.Estado == true && x.Id == id).Select(i => new OrdenPedidoViewModel()
            {
                Id = i.Id,
                Prioridad = i.Prioridad,
                IdCliente = i.IdCliente,
                ValorTotal = i.ValorTotal,
                DireccionEntrega = i.DireccionEntrega,
                FechaRegistro = i.FechaRegistro
            }).FirstOrDefault();
            lstOrdenes.lstOrdenPedidoDetalle = new List<OrdenPedidoDetalleViewModel>();
            lstOrdenes.lstOrdenPedidoDetalle = _context.GetAllProducts().Where(x => x.IdOrdenPedido == id).Select(i => new OrdenPedidoDetalleViewModel{
            Id = i.Id,
            Cantidad = i.Cantidad,
            IdOrdenPedido = i.IdOrdenPedido,
            Estado = i.Estado ,
            IdProducto = i.IdProducto,
            ValorParcial = i.ValorParcial,
            Producto = i.Nombre
            }).ToList();
            return lstOrdenes;
        }
        /// <summary>
        /// Actualiza el estado de la orden
        /// </summary>
        /// <param name="id"></param>
        /// <param name="estado"></param>
        /// <returns></returns>
        public bool Update(int id,string estado)
        {
            bool result = false; 
            var oOrden = _context.OrdenPedido.Where(x => x.Id == id).FirstOrDefault();
            oOrden.EstadoPedido = estado;
            _context.Entry(oOrden).State = EntityState.Modified;
            _context.SaveChanges();
            result = true;
            return result;
        }
        /// <summary>
        /// Crea o actualiza una orden
        /// </summary>
        /// <param name="orden"></param>
        /// <returns></returns>
        public bool UpdateOrCreate(OrdenPedidoViewModel orden)
        {
            OrdenPedido oOrdenPedido = new OrdenPedido();
            oOrdenPedido.IdCliente = orden.IdCliente;
            bool result = false;
            if (orden.Id != 0)
            {
                oOrdenPedido = _context.OrdenPedido.Where(x => x.Id == orden.Id).FirstOrDefault();
            } else
            {
                oOrdenPedido.FechaRegistro = DateTime.Now;
                Clientes oCliente = _context.Clientes.Where(x => x.Id == orden.IdCliente).FirstOrDefault();
                oOrdenPedido.DireccionEntrega = oCliente.Direccion;
            }
            
            oOrdenPedido.EstadoPedido = "Registrado";
            oOrdenPedido.Estado = true;
            
            decimal ValorTotal = 0;

            foreach (var item in orden.lstOrdenPedidoDetalle)
            {
                Productos oProducto = _context.Productos.Where(x => x.Id == item.IdProducto).FirstOrDefault();
                ValorTotal += (oProducto.ValorUnitario * item.Cantidad);
            }
            if(ValorTotal <= 500)
            {
                oOrdenPedido.Prioridad = "Baja";
            } else if(ValorTotal > 500 && ValorTotal <= 1000)
            {
                oOrdenPedido.Prioridad = "Media";
            }
            else
            {
                oOrdenPedido.Prioridad = "Alta";
            }
            oOrdenPedido.ValorTotal = ValorTotal;
            if (orden.Id != 0)
            {
                _context.Entry(oOrdenPedido).State = EntityState.Modified;
                var lstDetalle = _context.OrdenPedidoDetalle.Where(x => x.IdOrdenPedido == orden.Id).ToList();
                lstDetalle.ForEach(x => x.Estado = false);
            } else
            {
                _context.OrdenPedido.Add(oOrdenPedido);
            }
            _context.SaveChanges();

            

            foreach (var item in orden.lstOrdenPedidoDetalle)
            {
                Productos oProducto = _context.Productos.Where(x => x.Id == item.IdProducto).FirstOrDefault();
                
                OrdenPedidoDetalle oPedidoDetalle = new OrdenPedidoDetalle();
                oPedidoDetalle.Cantidad = item.Cantidad;
                oPedidoDetalle.IdOrdenPedido = oOrdenPedido.Id;
                oPedidoDetalle.IdProducto = item.IdProducto;
                oPedidoDetalle.Estado = true;
                oPedidoDetalle.ValorParcial = oProducto.ValorUnitario * item.Cantidad;
                _context.OrdenPedidoDetalle.Add(oPedidoDetalle);
                _context.SaveChanges();
            }

            
            result = true;
            return result;
        }

    }
}
