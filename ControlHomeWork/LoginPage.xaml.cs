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
using System.IO;
using System.Xml;

namespace ControlHomeWork
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page


    {
        //static void Main (string [] args) { using (SQLiteConnection connection = new SQLiteConnection()) }

        
        public LoginPage()
        {
            InitializeComponent();
        }

        public string defpath = "users.xml";

        private void ReadXMLDocument(string filepath, string loget, string passget)
        {
            string name, pwd;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);
            XmlNodeList list = xd.GetElementsByTagName("user");
            for (int i = 0; i < list.Count; i++)
            {
                XmlElement user = (XmlElement)xd.GetElementsByTagName("login")[i];
                XmlElement pass = (XmlElement)xd.GetElementsByTagName("password")[i];
                name = user.InnerText;
                pwd = pass.InnerText;
                if ((loget == name) & (passget == pwd))
                {
                    NavigationService.Navigate(Pages.MainPage);
                    break;
                }
                else if (i == list.Count - 1) MessageBox.Show("Неверный логин или пароль");
            }
            fs.Close();
        }

       






        private void ButtonRegister_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.RegPage);
        }

        private void ButtonOK_Click(object sender, RoutedEventArgs e)
        {
            if (!(TextBoxLogin.Text == "") & !(PasswordBoxPassword.Password == ""))
            {
                ReadXMLDocument(defpath, TextBoxLogin.Text, PasswordBoxPassword.Password);
            }
        }
    }
}
