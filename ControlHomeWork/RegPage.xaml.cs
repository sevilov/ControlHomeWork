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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void ButtonReg_Click(object sender, RoutedEventArgs e)
        {
            if (!(TextBoxRegLogin.Text == "") & !(PasswordBoxRegPassword.Password == ""))
                WriteToXMLDocument(defpath, TextBoxRegLogin.Text, PasswordBoxRegPassword.Password);
            else MessageBox.Show("Введите имя пользователя и пароль");
            NavigationService.GoBack();
        }

        public string defpath = "users.xml";

        public void CreateXMLDocument(string filepath) //создание xml файла
        {
            XmlTextWriter xtw = new XmlTextWriter(filepath, Encoding.UTF32);
            xtw.WriteStartDocument();
            xtw.WriteStartElement("users");
            xtw.WriteEndDocument();
            xtw.Close();
        }

        private void LoginPage_Load(object sender, EventArgs e)
        {
            if (!File.Exists(defpath)) CreateXMLDocument(defpath);
        }

        private string MaxID(string filepath) //вычисление max id
        {
            List<int> idList = new List<int>();
            int id;
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);
            XmlNodeList list = xd.GetElementsByTagName("user");
            if (list.Count > 0)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    XmlElement user = (XmlElement)xd.GetElementsByTagName("user")[i];
                    id = Convert.ToInt32(user.GetAttribute("id"));
                    idList.Add(id);
                }
                int result = 0;
                foreach (int j in idList)
                    if (j > result)
                        result = j;
                result++;
                fs.Close();
                return result.ToString();
            }
            else
            {
                fs.Close();
                return "1";
            }
        }

        private void WriteToXMLDocument(string filepath, string name, string pwd) //добавление записи
        {
            if (!File.Exists(defpath)) CreateXMLDocument(defpath);
            string id = MaxID(filepath);
            XmlDocument xd = new XmlDocument();
            FileStream fs = new FileStream(filepath, FileMode.Open);
            xd.Load(fs);

            XmlElement user = xd.CreateElement("user");
            user.SetAttribute("id", id);

            XmlElement login = xd.CreateElement("login");
            XmlElement pass = xd.CreateElement("password");

            XmlText tLogin = xd.CreateTextNode(name);
            XmlText tPassword = xd.CreateTextNode(pwd);

            login.AppendChild(tLogin);
            pass.AppendChild(tPassword);

            user.AppendChild(login);
            user.AppendChild(pass);

            xd.DocumentElement.AppendChild(user);

            fs.Close();
            xd.Save(filepath);
        }

        

       
    }
}
