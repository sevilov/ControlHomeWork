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
using System.Xml.Serialization;
using System.IO;

namespace ControlHomeWork
{
    /// <summary>
    /// Логика взаимодействия для DealPage.xaml
    /// </summary>
    public partial class DealPage : Page
    {
        public DealPage()
        {
            InitializeComponent();
        }

        NoteInfo noteinfo;

        
       

        private void day_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void mounth_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void year_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void note_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       

        
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            DateTime date;
            int priority = 5;

            if (DateTime.TryParse(AddedDate.Text, out date) == false)
            {
                MessageBox.Show("Некорректное значение даты");
                return;
            }



            if (string.IsNullOrWhiteSpace(TextBoxNote.Text))
            {
                MessageBox.Show("Необходимо ввести ввести текст заметки");
                TextBoxNote.Focus();
                return;
            }
            if (!int.TryParse(TextBoxPriority.Text, out priority))
            {
                MessageBox.Show("Некорректное значение приоритета");
                TextBoxPriority.Focus();
                return;
            }
            if (priority < 0 || priority > 10)
            {
                MessageBox.Show("Приоритет должен быть от 0 до 10 включительно");
                TextBoxPriority.Focus();
                return;
            }

            noteinfo = new NoteInfo(date.Date, TextBoxNote.Text, priority);

           
                Pages.MainPage.NoteInfoAdded(noteinfo);
                NavigationService.GoBack();

            TextBoxNote.Clear();
            TextBoxPriority.Clear();

            
        }
        


        private void TextBoxPriority_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
