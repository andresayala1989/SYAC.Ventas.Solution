using SYAC.Ventas.BLL.DAO;
using SYAC.Ventas.DAL.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace SYAC.Ventas.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        //Product NewProduct = new Product();
        //Product selectedProduct = new Product();
        public MainWindow()
        {

            InitializeComponent();
            GetOrders();
            GetProducts();
            GetClients();
                //NewProductGrid.DataContext = NewProduct;
        }
        private void GetOrders()
        {
            OrdenDG.ItemsSource = OrdenesDAO.Instance.Get().ToList();
        }
        private void GetClients()
        {
            List<ClienteViewModel> lstCliente = ClienteDAO.Instance.Get().ToList();
            this.cmbCountryList.DisplayMemberPath = "Nombre";
            this.cmbCountryList.SelectedValuePath = "Id";
            this.cmbCountryList.ItemsSource = lstCliente;
            this.cmbCountryList.Text = "Escoger Cliente";
        }

        private void GetProducts()
        {
            List<ProductoViewModel> lstProducts = OrdenesDAO.Instance.GetProducts().ToList();
            ProductsAdd.ItemsSource = lstProducts;
        }

        public void GetAllOrder(int id)
        {
            OrdenPedidoViewModel lstOrder = OrdenesDAO.Instance.GetbyId(id);
            List<ClienteViewModel> lstCliente = ClienteDAO.Instance.Get().ToList();
            this.cmbCountryList_Copy.DisplayMemberPath = "Nombre";
            this.cmbCountryList_Copy.SelectedValuePath = "Id";
            this.cmbCountryList_Copy.ItemsSource = lstCliente;
            this.cmbCountryList_Copy.Text = "Escoger Cliente";
            cmbCountryList_Copy.SelectedValue = lstOrder.IdCliente;
            this.txtIdOrder.Text = lstOrder.Id.ToString();
            List<ProductoViewModel> lstProducts = OrdenesDAO.Instance.GetProducts().ToList();
            foreach (var item in lstProducts)
            {
                foreach (var item2 in lstOrder.lstOrdenPedidoDetalle)
                {
                    if (item.Id == item2.IdProducto)
                    {
                        item.IsSelected = true;
                        item.Cantidad = item2.Cantidad;
                    }
                }
            }
            ProductsEdit.ItemsSource = lstProducts;
        }
        private void AddItem(object s, RoutedEventArgs e)
        {
            OrdenPedidoViewModel oOrdenPedido = new OrdenPedidoViewModel();
            int idCliente = ((SYAC.Ventas.DAL.ViewModels.ClienteViewModel)this.cmbCountryList.ItemContainerGenerator.Items[this.cmbCountryList.SelectedIndex]).Id;
            oOrdenPedido.IdCliente = idCliente;
            var lstProducts = ProductsAdd.ItemsSource;
            var lstTemp = lstProducts.Cast<ProductoViewModel>().Where(x => x.IsSelected).ToList();
            List<OrdenPedidoDetalleViewModel> lstOrdeDetalle = new List<OrdenPedidoDetalleViewModel>();
            foreach (var item in lstTemp)
            {
                OrdenPedidoDetalleViewModel oPedidoDetalle = new OrdenPedidoDetalleViewModel();
                oPedidoDetalle.IdProducto = item.Id;
                oPedidoDetalle.IdOrdenPedido = 0;
                oPedidoDetalle.Cantidad = item.Cantidad == null ? 0 : item.Cantidad.Value;
                oPedidoDetalle.Estado = true;
                lstOrdeDetalle.Add(oPedidoDetalle);
            }

            oOrdenPedido.lstOrdenPedidoDetalle = lstOrdeDetalle;
            bool result = OrdenesDAO.Instance.UpdateOrCreate(oOrdenPedido);
            if(result)
            {
                cmbCountryList_Copy.SelectedIndex = -1;
                cmbCountryList_Copy.SelectedValue = 0;
                List<ProductoViewModel> lstProducts2 = OrdenesDAO.Instance.GetProducts().ToList();
                foreach (var item in lstProducts2)
                {
                    item.IsSelected = false;
                }
                ProductsAdd.ItemsSource = lstProducts2;
            }
            GetOrders();
        }
        private void UpdateItem(object s, RoutedEventArgs e)
        {
            OrdenPedidoViewModel oOrdenPedido = new OrdenPedidoViewModel();

            int idCliente = ((SYAC.Ventas.DAL.ViewModels.ClienteViewModel)this.cmbCountryList_Copy.ItemContainerGenerator.Items[this.cmbCountryList_Copy.SelectedIndex]).Id;
            oOrdenPedido.IdCliente = idCliente;
            oOrdenPedido.Id = Convert.ToInt32(this.txtIdOrder.Text);
            var lstProducts = ProductsEdit.ItemsSource;
            var lstTemp = lstProducts.Cast<ProductoViewModel>().Where(x => x.IsSelected).ToList();
            List<OrdenPedidoDetalleViewModel> lstOrdeDetalle = new List<OrdenPedidoDetalleViewModel>();
            foreach (var item in lstTemp)
            {
                OrdenPedidoDetalleViewModel oPedidoDetalle = new OrdenPedidoDetalleViewModel();
                oPedidoDetalle.IdProducto = item.Id;
                oPedidoDetalle.IdOrdenPedido = Convert.ToInt32(this.txtIdOrder.Text);
                oPedidoDetalle.Cantidad = item.Cantidad == null? 0 : item.Cantidad.Value;
                oPedidoDetalle.Estado = true;
                lstOrdeDetalle.Add(oPedidoDetalle);
            }

            oOrdenPedido.lstOrdenPedidoDetalle = lstOrdeDetalle;
            bool result = OrdenesDAO.Instance.UpdateOrCreate(oOrdenPedido);
            if (result)
            {
                cmbCountryList_Copy.SelectedIndex = -1;
                cmbCountryList_Copy.SelectedValue = 0;
                List<ProductoViewModel> lstProducts2 = OrdenesDAO.Instance.GetProducts().ToList();
                foreach (var item in lstProducts2)
                {
                    item.IsSelected = false;
                }
                ProductsEdit.ItemsSource = lstProducts2;
                this.txtIdOrder.Text = "";
            }
            GetOrders();
        }
        private void SelectProductToEdit(object s, RoutedEventArgs e)
        {
            GetAllOrder(((SYAC.Ventas.DAL.ViewModels.OrdenPedidoViewModel)OrdenDG.SelectedItem).Id);
            
        }
        private void DeleteProduct(object s, RoutedEventArgs e)
        {
            
            GetOrders();
        }

        private void ProductDG_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}