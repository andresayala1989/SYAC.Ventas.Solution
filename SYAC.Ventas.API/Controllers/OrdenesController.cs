using DevExtreme.AspNet.Mvc;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using SYAC.Ventas.DAL.ViewModels;
using SYAC.Ventas.BLL.DAO;

namespace SYAC.Ventas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    
    public class OrdenesController : ApiController
    {
        /// <summary>
        /// /Obtiene todas las ordenes de pedido
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/Ordenes/Get")]
        public List<OrdenPedidoViewModel> Get(DataSourceLoadOptions loadOptions) {
            List<OrdenPedidoViewModel> lstOrdenes= new List<OrdenPedidoViewModel>();
            lstOrdenes = OrdenesDAO.Instance.Get();
            return lstOrdenes;
        }
        /// <summary>
        /// Actualiza el estado de las ordenes
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="Estado"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("api/Ordenes/Put")]
        public bool Put(int Id, string Estado)
        {
            
            bool result = OrdenesDAO.Instance.Update(Id, Estado);
            return result;
        }

    }
}