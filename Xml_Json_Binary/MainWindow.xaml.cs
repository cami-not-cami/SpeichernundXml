using Microsoft.Win32;
using System.DirectoryServices.ActiveDirectory;
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
using System.Xml.Serialization;

namespace Xml_Json_Binary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _path = @"C:\Users\Cami\Documents\helloWorld.xml";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            //werte für object geben von input
            Person temp = new Person();
            temp.Name= tbx_name.Text;
            temp.Email= tbx_email.Text;
            temp.Taetigkeit = tbx_taetigkeit.Text;

            XmlLoader.WriteToXmlFile<Person>(_path, temp,false);
        }

        private void LoadClick(object sender, RoutedEventArgs e)
        {


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml Datei (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
            openFileDialog.FileName = _path;

            Person loadPerson = null;

            if (openFileDialog.ShowDialog() == true)
            {
               loadPerson= XmlLoader.ReadFromXmlFile<Person>(_path);
                tbl_output.Text = loadPerson.ToString();

            }

        }

        private void SaveAtClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml Datei (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
            saveFileDialog.DefaultExt = ".xml";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultDirectory = "C:" ;
            saveFileDialog.FileName = "MeineDatei";

            Person temp = new Person();
            temp.Name = tbx_name.Text;
            temp.Email = tbx_email.Text;
            temp.Taetigkeit = tbx_taetigkeit.Text;

            if (saveFileDialog.ShowDialog() == true)
            {
                //update to the last document saved
                _path = saveFileDialog.FileName;
                XmlLoader.WriteToXmlFile(saveFileDialog.FileName, temp,false);
            }

        }
    }
}