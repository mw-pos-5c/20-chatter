using ClockObserver;
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
using System.Windows.Shapes;

namespace Chatter
{
    /// <summary>
    /// Interaktionslogik für ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window, IObserver
    {
        private Subject subject;

        public string ClientName { get; }
        public string TopicsOfInterest => throw new NotImplementedException();

        public ChatWindow(Subject subject, string name)
        {
            InitializeComponent();
            ClientName = name;
            Title = $"ChatClient: {ClientName}";
            ClientNameLabel.Content = ClientName;
            
            this.subject = subject;
            this.subject.Attach(this);
        }

        public void ClientAttached(string name)
        {
        }

        public void ClientDetached(string name)
        {
        }


        public void Update(Message msg)
        {
            MessagesListView.Items.Add(msg.ToString());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var msg = ChatInputTextBox.Text;
            if (msg.Length == 0) return;

            subject.Notify(new Message
            {
                Content = msg,
                Date = DateTime.Now,
                Name = ClientName,
            });
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            subject.Detach(this);
        }
    }
}
