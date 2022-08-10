using SYAC.Ventas.BLL.Model;
using SYAC.Ventas.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SYAC.Ventas.BLL.DAO
{
    /// <summary>
    /// Clase de Clientes
    /// </summary>
    public class ClienteDAO
    {
        #region Singleton
        /// <summary>
        /// Se crea una instancia privada para la clase ClienteDAO.
        /// Ha sido declarada como "volatile" para asegurar que la asignación de la instancia de la variable se complete luego de que ha sido accedida.
        /// </summary>
        private static volatile ClienteDAO instance;

        /// <summary>
        /// Permite asegurar que solo una instancia ha sido creada y solo cuando sea necesaria.
        /// En lugar de bloquearse así mismo, evita que ocurran otros bloqueos.
        /// </summary>
        private static object syncRoot = new Object();

        /// <summary>
        /// Se crea una instancia publica de la clase ClienteDAO.
        /// Permitiendo una conexión unica y accesible por cualquiera.
        /// </summary>
        public static ClienteDAO Instance
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
                            instance = new ClienteDAO();
                        }
                    }
                }
                return instance;
            }
        }
        /// <summary>
        /// Constructor de la clase ClienteDAO
        /// </summary>
        private ClienteDAO() { }
        #endregion

        private VentasEntities _context = new VentasEntities();

        public ClienteDAO(VentasEntities context)
        {
            _context = context;
        }
        /// <summary>
        /// Obtiene los clientes
        /// </summary>
        /// <returns></returns>
        public List<ClienteViewModel> Get()
        {
            var clientes = _context.Clientes.Select(i => new ClienteViewModel() {
                Id = i.Id,
                Identificacion = i.Identificacion,
                Nombre = i.Nombre,
                Direccion = i.Direccion,
                Estado = i.Estado
            }).ToList();

            return clientes;
        }



    }
}
