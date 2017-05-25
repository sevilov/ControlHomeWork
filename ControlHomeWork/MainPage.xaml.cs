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
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace ControlHomeWork
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page

    {
       
        List<NoteInfo> notes = new List<NoteInfo>();
        List<NoteInfo> findednotes = new List<NoteInfo>();

       

        public MainPage()
        {
            InitializeComponent();
            DeserializeData();
        }

        
       
        public void NoteInfoAdded(NoteInfo noteinfo)
        {
            notes.Add(noteinfo);
            ListViewToDo.ItemsSource = null;
            ListViewToDo.ItemsSource = notes;
        }

       

        private void ButtonAddition_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.DealPage);
           
        }


        private void RefreshListView()
        {
            ListViewToDo.ItemsSource = null;
            ListViewToDo.ItemsSource = notes;
        }

        private void ButtonDone_Click(object sender, RoutedEventArgs e)
        {
            if (ListViewToDo.SelectedIndex != -1)
            {
                notes.RemoveAt(ListViewToDo.SelectedIndex);
                RefreshListView();
                
            }
        }

        private void SearchToDo_TextChanged(object sender, TextChangedEventArgs e)
        {
            findednotes.Clear();
            string str = SearchToDo.Text;
            findednotes = notes.FindAll(x => x.Note.Contains(str));
            ListViewToDo.ItemsSource = null;
            ListViewToDo.ItemsSource = findednotes;

            if (string.IsNullOrEmpty(str) == true)
            {
                ListViewToDo.ItemsSource = null;
                ListViewToDo.ItemsSource = notes;
            } 
        }

        private void ListViewToDo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           

        }






        private void ButtonSearch_Click(object sender, RoutedEventArgs e)
        {
           // Ser();

        }


        public void Ser()
        {
            NoteData data = new NoteData();
            data.NotesInfo = notes;


            using (var fs = new FileStream("students.xml", FileMode.Create))
            {
                XmlSerializer xml = new XmlSerializer(typeof(NoteData));
                xml.Serialize(fs, data);
            }

        }

        private void DeserializeData()
        {
            NoteData data;
            using (var fs = new FileStream("students.xml", FileMode.Open))
            {
                XmlSerializer xml = new XmlSerializer(typeof(NoteData));
                data = (NoteData)xml.Deserialize(fs);
                notes = data.NotesInfo;
            }

            ListViewToDo.ItemsSource = notes;
            
        }

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(Pages.LoginPage);
        }

       
    }

   
}
