using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

namespace Recursos_Lorena_Sanchez
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //since rctStatic (rectangleStatic) is a static resource, we need to apply the gradient when the button is clicked
        private void btnApply_Click(object sender, RoutedEventArgs e)
        {
            rctStatic.Fill =  (Brush) rctStatic.FindResource("MiGradiente"); // needed cast or it's not going to work properly

        }

        private void sldGradient_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double sliderValue = sldGradient.Value; // from 0 to 10

            lblClock.Content = (int) (7 + (sliderValue / 10) * 16);
            //from 7 AM to 23 PM (16 + 7 = 23)

            LinearGradientBrush gradient = new LinearGradientBrush
            {
                StartPoint = new Point(0.5, 0), //same start & endpoint as the dictionary's brush
                EndPoint = new Point(0.5, 1)
            };

            double fadeRate = 0.23; //make the colors fade slower

            //Modifying the gradientStops based on the current slider value
            gradient.GradientStops.Add(new GradientStop(Color.FromRgb(121, 21, 91), 0));
            gradient.GradientStops.Add(new GradientStop(Color.FromRgb(255, 186, 134), sliderValue * fadeRate));
            gradient.GradientStops.Add(new GradientStop(Color.FromRgb(246, 99, 92), sliderValue * fadeRate * 0.629));
            gradient.GradientStops.Add(new GradientStop(Color.FromRgb(194, 51, 115), sliderValue * fadeRate * 0.277));

            //Replaces current "MiGradiente"
            gridCont.Resources.Clear();
            gridCont.Resources.Add("MiGradiente", gradient); //1 param: gradient that'll be added (replaced), 2 param: brush
        }
    }
}
