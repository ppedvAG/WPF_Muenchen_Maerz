using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ColorPickerUserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ColorPicker : UserControl, INotifyPropertyChanged
    {

        //Snippet: propdb
        public Brush Farbe
        {
            get { return (Brush)GetValue(FarbeProperty); }
            //Der Setter wird nur aufgerufen wenn die Property per Code geändert wird
            //jedoch nicht mittels XAML. Daher besser die propertyChangedCallback-Methode 
            //in der Register-Methode verwenden.
            set { SetValue(FarbeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FarbeProperty =
            DependencyProperty.Register(nameof(Farbe), typeof(Brush), typeof(ColorPicker), new PropertyMetadata(Brushes.Black,PropertyChangeCallback));

        private static void PropertyChangeCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ColorPicker).PasseSliderAn((Brush)e.NewValue);
            (d as ColorPicker).FarbeChanged?.Invoke(d, EventArgs.Empty);
        }

        public event EventHandler FarbeChanged = null;

        private void PasseSliderAn(Brush neuerBrush)
        {
            Color neueFarbe = ((SolidColorBrush)neuerBrush).Color;

            sliderRed.Value = neueFarbe.R;
            sliderGreen.Value = neueFarbe.G;
            sliderBlue.Value = neueFarbe.B;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ColorPicker()
        {
            InitializeComponent();
        }

        private void StackPanel_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            //Farbe neu berechnen
            byte r = 0, g = 0, b = 0;

            if (sliderRed.Value is double dred)
            {
                r = (byte)dred;
            }

            if (sliderGreen.Value is double dgreen)
            {
                g = (byte)dgreen;
            }
            if (sliderBlue.Value is double dblue)
            {
                b = (byte)dblue;
            }

            Farbe = new SolidColorBrush(Color.FromRgb(r, g, b));
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Farbe)));
        }
    }
}
