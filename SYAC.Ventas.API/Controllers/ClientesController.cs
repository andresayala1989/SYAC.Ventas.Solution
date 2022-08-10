using DevExtreme.AspNet.Mvc;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using SYAC.Ventas.DAL.ViewModels;
using SYAC.Ventas.BLL.DAO;

namespace SYAC.Ventas.API.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/Clientes/Get", Name = "ClientesApi")]
    public class ClientesController : ApiController
    {
        /// <summary>
        /// Obtiene todos los clientes
        /// </summary>
        /// <param name="loadOptions"></param>
        /// <returns></returns>
        [HttpGet]
        public List<ClienteViewModel> Get(DataSourceLoadOptions loadOptions) {
            List<ClienteViewModel> lstCliente = new List<ClienteViewModel>();
            lstCliente = ClienteDAO.Instance.Get();
            return lstCliente;
        }



    }
}