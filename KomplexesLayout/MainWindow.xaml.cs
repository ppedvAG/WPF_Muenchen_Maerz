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

namespace KomplexesLayout
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string lieblingsfarbe = "keine Angabe";

        public List<Familienstände> liste = new List<Familienstände>();

        public enum Familienstände
        {
            Verheiratet, Verwitwet, Ledig
        }

        public MainWindow()
        {
            InitializeComponent();

            //Alternative Möglichkeit die ComboBox zu befüllen
            //foreach(Familienstände item in Enum.GetValues(typeof(Familienstände))) {
            //    liste.Add(item);
            //}
            //cbFamilienstand.ItemsSource = liste;
        }

        private void FormButtonClick(object sender, RoutedEventArgs e)
        {
            //Informationen sammeln
            string name = tbName.Text;
            double alter = sliderAlter.Value;

            string familienstand = "keine Angabe";

            
            //Prüfung und Casting in einem Ausdruck
            if(cbFamilienstand.SelectedItem is ComboBoxItem box)
            {
                familienstand = box.Content.ToString(); 
            }



            MessageBox.Show($"{name} Alter({alter}), Familienstand: {familienstand}" +
                $", Lieblingsfarbe: {lieblingsfarbe}");
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            //OriginalSource steht für das Control, was das Ereignis ursprünglich ausgelöst hat
            if(e.OriginalSource is RadioButton radio)
            {
                lieblingsfarbe = radio.Content.ToString();
            }
        }

        private void sliderAlter_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            if (e.OriginalSource is Slider slider)
            {
                if (sender is DockPanel dock)
                {
                    tbAlter.Text = $"Alter: ({slider.Value.ToString()})";
                }
                else
                {
                    this.Title = slider.Value.ToString();
                }
            } 
            
        }
    }
}
