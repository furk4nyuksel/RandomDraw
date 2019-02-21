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

namespace Draw
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            btnRemove.Click += BtnRemove_Click;
            btnDraw.Click += BtnDraw_Click;
            btnDraw.IsEnabled = false;
            btnRemove.IsEnabled = false;
            btnDraw.Visibility = Visibility.Hidden;
            ListBxDraw.Visibility = Visibility.Hidden;
        }



        List<string> listName = new List<string>();
        private void BtnNameSave_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                listName.Add(txtName.Text);
                MessageBox.Show("Kayıt Eklendi");
                txtName.Text = string.Empty;
            }
            else
            {
                MessageBox.Show("Lütfen Alanı Boş Bırakmayınız.");
            }
            UpdateListbox();
           
        }

        private void BtnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (ListBx.SelectedItem!=null)
            {
                if (MessageBox.Show(ListBx.SelectedItem.ToString() + " Adlı Kişiyi Silmek İstiyormusunuz ?", "Silme İşlemi", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    listName.Remove(ListBx.SelectedItem.ToString());
                    UpdateListbox();
                }
            }
            else
            {
                MessageBox.Show("Seçim Yapınız");
            }
          
         
        }
 
        public void UpdateListbox()
        {
            if (listName.Count() > 0)
            {
                btnRemove.IsEnabled = true;
            }
            ListBx.ItemsSource = listName.ToList();
            if (listName.Count() >1)
            {
        
                btnDraw.IsEnabled = true;
                btnDraw.Visibility = Visibility.Visible;
                ListBxDraw.Visibility = Visibility.Visible;
            }
        }
        private void BtnDraw_Click(object sender, RoutedEventArgs e)
        {
            ListBxDraw.ItemsSource = listName.ToList().OrderBy(s => Guid.NewGuid());
        }
    }
}
