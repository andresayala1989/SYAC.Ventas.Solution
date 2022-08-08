using DevExtreme.AspNet.Mvc;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using SYAC.Ventas.DAL.ViewModels;
using SYAC.Ventas.BLL.DAO;

namespace SYAC.Ventas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/Ordenes/Get", Name = "OrdenesApi")]
    public class OrdenesController : ApiController
    {

        [HttpGet]
        public List<OrdenPedidoViewModel> Get(DataSourceLoadOptions loadOptions) {
            List<OrdenPedidoViewModel> lstOrdenes= new List<OrdenPedidoViewModel>();
            lstOrdenes = OrdenesDAO.Instance.Get();
            return lstOrdenes;
        }



    }
}