using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CSVLoader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> People { get; set; }

     
        public MainWindow()
        {
            People = new ObservableCollection<Person>();
            InitializeComponent();
            this.DataContext = this;

        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person();
            person.Email = tbx_email.Text;
            person.Vorname = tbx_vorname.Text;
            person.Nachname = tbx_nachname.Text;
            person.GebDat = dtp_gebdat.SelectedDate ==null ? new DateTime():(DateTime)dtp_gebdat.SelectedDate;
            int temp = 0;
            int.TryParse(tbx_id.Text,out temp);
            person.ID = temp;

            People.Add(person);
            
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.DefaultExt = ".csv";
            saveFileDialog.Filter = "CSV file (*.csv)|*.csv|Text file (*.txt) | *.txt | All files (*.*)|*.* ";
            saveFileDialog.AddExtension = true;
            if(saveFileDialog.ShowDialog()==true)
            { 
                File.WriteAllLines(saveFileDialog.FileName,CSVConverter.OutputCSV(People));
            }
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter= "CSV file (*.csv)|*.csv|Text file (*.txt) | *.txt | All files (*.*)|*.* ";
            if (openFileDialog.ShowDialog() == true)
            {
                foreach (var item in CSVConverter.ImportCSV(File.ReadAllLines(openFileDialog.FileName)) )
                {
                    People.Add(item);
                }
            }
        }
    }
}