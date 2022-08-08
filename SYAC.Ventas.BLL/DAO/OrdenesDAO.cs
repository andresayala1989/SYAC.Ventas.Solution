using SYAC.Ventas.BLL.Model;
using SYAC.Ventas.DAL.ViewModels;
using System;
using System.Collections.Generic;
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

        public List<OrdenPedidoViewModel> Get()
        {
            var clientes = _context.GetAllOrdenes().Select(i => new OrdenPedidoViewModel() {
                Id = i.Id,
                Prioridad = i.Prioridad,
                Cliente = i.Nombre,
                ValorTotal = i.ValorTotal,
                EstadoPedido = i.EstadoPedido,
                FechaRegistro = i.FechaRegistro
            }).ToList();

            return clientes;
        }



    }
}
