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

namespace Speichern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

    

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            FileStream s = new FileStream(@"C:\Users\Cami\Documents\HelloWorld.txt", FileMode.Open,FileAccess.Read);
            string temp = " ";

            using (StreamReader reader = new StreamReader(s, Encoding.Unicode))
            {
                //while ((input = reader.ReadLine()) != null)
                //{
                //    Output.Text = input;
                //}
                string currentInput;
                while ((currentInput = reader.ReadLine()) != null)
                {
                    temp += currentInput;
                }

            }
            Output.Text = temp;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            //Wo liegt das File und wie greifen wir darauf zu
            FileStream s = new FileStream(@"C:\Users\Cami\Documents\HelloWorld.txt", FileMode.OpenOrCreate, FileAccess.Write);
            using (StreamWriter writer = new StreamWriter(s,Encoding.Unicode))
            {
                writer.WriteLine("-----------------");
                writer.WriteLine(Input.Text);

               //Close() wird von using automatisch ausgefuehrt
               //for the already in use error when a file is open
                // writer.Close();
            }

        }
    }
}