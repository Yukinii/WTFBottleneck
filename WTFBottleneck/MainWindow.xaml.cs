using System.Windows;
using System.Windows.Controls;
using WTFHardwareInterface.Core.Hardware;

namespace WTFBottleneck
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

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await HardwareInterface.Initialize();
            var Block = new TextBlock();

            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());
            Block.Text = string.Format("CPU Temp: {0}", await CPU.GetTempAsync());

            Stackpanel.Children.Add(Block);
        }
    }
}
