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
    public partial class ChatWindow : Window
    {

        public string Title { get; private set; }
        private MessageSubject subject;
       

        public ChatWindow(MessageSubject subject, string title)
        {
            DataContext = this;
            InitializeComponent();
            Title = title;
            this.subject = subject;
        }
    }
}
