using Microsoft.Win32;
using System.Windows;

namespace Xml_Json_Binary
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _path = @"C:\Users\Cami\Documents\helloWorld.bin";
        public MainWindow()
        {
            InitializeComponent();

        }

        private void SaveClick(object sender, RoutedEventArgs e)
        {
            //werte für object geben von input
            Person temp = new Person();
            temp.Name = tbx_name.Text;
            temp.Email = tbx_email.Text;
            temp.Taetigkeit = tbx_taetigkeit.Text;

            ComplexClass girlie = new ComplexClass();
            girlie.Name = "Cici";
            girlie.Age = 43;
            girlie.ShoeSize =37.5d;
            girlie.IsAlive= true;
            girlie.Initial = 'C';
            girlie.Height = 1.70f;
            girlie.Money =2341.141m;
            girlie.Exes = new List<Person>{temp,temp};
            girlie.ChildrenAge = new int[] { 3, 12, 66, 23 };

            XmlLoader.WriteToXmlFile<ComplexClass>(_path, girlie,false);
            //BinaryLoader.WriteToBinary<Person>(_path, temp,false);
            //JsonLoader.WriteToJsonFile<Person>(_path, temp,false);
            //XmlLoader.WriteToXmlFile<Person>(_path, temp, false);
        }

        private void LoadClick(object sender, RoutedEventArgs e)
        {


            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "xml Datei (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
            openFileDialog.FileName = _path;

            Person loadPerson = null;


            if (openFileDialog.ShowDialog() == true)
            {

                //loadPerson = BinaryLoader.ReadFromBinary<Person>(_path);
                //loadPerson = XmlLoader.ReadFromXmlFile<Person>(_path);
                loadPerson = JsonLoader.ReadFromJsonFile<Person>(_path);
                tbl_output.Text = loadPerson.ToString();

            }

        }

        private void SaveAtClick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "xml Datei (*.xml)|*.xml|Alle Dateien (*.*)|*.*";
            saveFileDialog.DefaultExt = ".xml";
            saveFileDialog.AddExtension = true;
            saveFileDialog.DefaultDirectory = "C:";
            saveFileDialog.FileName = "MeineDatei";

            Person temp = new Person();
            temp.Name = tbx_name.Text;
            temp.Email = tbx_email.Text;
            temp.Taetigkeit = tbx_taetigkeit.Text;

            if (saveFileDialog.ShowDialog() == true)
            {
                //update to the last document saved
                _path = saveFileDialog.FileName;
                XmlLoader.WriteToXmlFile(saveFileDialog.FileName, temp, false);
            }

        }
    }
}