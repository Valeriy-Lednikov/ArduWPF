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
using System.IO.Ports;

namespace ArduWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static SerialPort serialPort;
        public MainWindow()
        {
            InitializeComponent();
        }


        private void ScanButton_Click(object sender, RoutedEventArgs e)
        {
            PortsCombo.Items.Clear();
            string[] portNames = SerialPort.GetPortNames();

            foreach (string portName in portNames)
            {
                PortsCombo.Items.Add(portName);
            }
        }

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
        {
            string selectedPort = PortsCombo.SelectedItem.ToString();  
            serialPort = new SerialPort(selectedPort, 9600, Parity.None, 8, StopBits.One);

            try
            {
                serialPort.Open();
                StatusConnection.Content = "Ok";
                serialPort.DataReceived += SerialPortDataReceived;

            }
            catch (Exception ex)
            {
                StatusConnection.Content = ex.Message;
            }
        }


        private void UpdateDataForm(string data)
        {
            string[] partsData = data.Split(';');

            Var1TextBox.Text = partsData[0];
            Var2TextBox.Text = partsData[1];
            Var3TextBox.Text = partsData[2];
            Var4TextBox.Text = partsData[3];
            Var5TextBox.Text = partsData[4];
        }

        private void SerialPortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                string data = serialPort.ReadLine();
                Dispatcher.Invoke(() => UpdateDataForm(data));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при чтении данных: {ex.Message}");
            }
        }
    }
}
