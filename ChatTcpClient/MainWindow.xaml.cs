using SimpleTCP;
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

namespace ChatTcpClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SimpleTcpClient simpleTcpClient;
        string addingMessange;
        public MainWindow()
        {
            InitializeComponent();
            simpleTcpClient = new SimpleTcpClient();
            try
            {
                simpleTcpClient.Connect("localhost", 8080);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вы не смогли подключится\n" + ex.Message);
                Environment.Exit(1);
            }
            simpleTcpClient.DataReceived += NewMassandereceived;
        }

        private void NewMassandereceived(object? sender, Message e)
        {
            addingMessange = e.MessageString;
            this.Dispatcher.Invoke(AddAddindMassange);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var messange = NewMessangeText.Text;
            if (messange == "")
            {
                return;
            }
            MessageList.Children.Add(ChatMessangeWapper.GetTextBoxForYourMessange(messange));
            if(messange[0] != '/')
                messange = "/msg " + messange;
            simpleTcpClient.Write(messange + "\n");
            NewMessangeText.Text = "";
        }
        private void AddAddindMassange()
        {
            if (addingMessange == null)
                return;
            MessageList.Children.Add(ChatMessangeWapper.GetTextBlockFornewMessange(addingMessange));
            addingMessange = null;
        }
    }
}
