using ClockObserver;
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

namespace Chatter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IObserver
    {
        private Subject subject = new Subject();

        public string ClientName => "Server";
        public string TopicsOfInterest => throw new NotImplementedException();

        public MainWindow()
        {
          
            InitializeComponent();

            subject.Attach(this);

            SetClientCount(0);
        }

        public void ClientAttached(string name)
        {
            SetClientCount(subject.NrObservers - 1);

            ClientLogListView.Items.Add($"{DateTime.Now.ToLongTimeString()} {name}: attached");
        }

        public void ClientDetached(string name)
        {
            SetClientCount(subject.NrObservers - 1);

            ClientLogListView.Items.Add($"{DateTime.Now.ToLongTimeString()} {name}: detached");
        }

        public void Update(Message msg)
        {
            MessagesListView.Items.Add(msg.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var name = ClientNameTextBox.Text;
            if (name.Length == 0) return;
            ClientNameTextBox.Clear();


            new ChatWindow(subject, name).Show();
        }

        private void SetClientCount(int c)
        {
            ClientCountLabel.Content = $"{c} Clients connected";
        }
    }
}
