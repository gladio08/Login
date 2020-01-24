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
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Configuration configuration;
        private const string db = @"Data Source=DESKTOP-CJJ68JS;Initial Catalog=Bootcamp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
        public MainWindow()
        {
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            var check = con.QueryAsync<Login>("exec SP_Retrieve_Login @Username, @Password",
                new {Username = tbEmail.Text, Password = tbPass.Password}).Result.SingleOrDefault();
            if (check != null)
            {
                UserManager Manage = new UserManager();
                Manage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Maaf data Anda Tidak Ditemukan");
            }
        }
    }
}
