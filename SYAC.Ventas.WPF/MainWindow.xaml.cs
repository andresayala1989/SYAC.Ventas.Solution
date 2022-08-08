using SYAC.Ventas.BLL.DAO;
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
            GetProducts();
            //NewProductGrid.DataContext = NewProduct;
        }
        private void GetProducts()
        {
            ProductDG.ItemsSource = OrdenesDAO.Instance.Get().ToList();
        }
        private void AddItem(object s, RoutedEventArgs e)
        {
            //context.Products.Add(NewProduct);
            //context.SaveChanges();
            GetProducts();
            //NewProduct = new Product();
            //NewProductGrid.DataContext = NewProduct;
        }
        private void UpdateItem(object s, RoutedEventArgs e)
        {
            //context.Update(selectedProduct);
            //context.SaveChanges();
            GetProducts();
        }
        private void SelectProductToEdit(object s, RoutedEventArgs e)
        {
            //selectedProduct = (s as FrameworkElement).DataContext as Product;
            //UpdateProductGrid.DataContext = selectedProduct;
        }
        private void DeleteProduct(object s, RoutedEventArgs e)
        {
            //var productToDelete = (s as FrameworkElement).DataContext as Product;
            //context.Products.Remove(productToDelete);
            //context.SaveChanges();
            GetProducts();
        }
    }
}